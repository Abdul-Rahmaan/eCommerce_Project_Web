using eCommerceProjectWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace eCommerceProjectWeb.Controllers
{
    public class login:Controller
    {
        private readonly ProjectDBAccess _Db;
        public login(ProjectDBAccess Db)

        {
            _Db = Db;
        }
        //public IActionResult LoginList()
        //{
        //    return View(_Db.tblLogin.ToList());
        //}
        //public async Task<IActionResult> Login(LoginEntity obj)
        //{
        //    return View(obj);
        //}


        public IActionResult LoginList(string username, string password)
        {
            // Validate the username and password
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError(string.Empty, "Username and password are required.");
                return View();
            }

            // Authenticate the user
            if (AuthenticateUser(username, password))
            {
                // Redirect to the dashboard if the user is authenticated
                return RedirectToAction("CustomerList", "Customer");
            }

            // Display an error message if the authentication failed
            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return RedirectToAction("LoginList", "login");
            //return View();
        }

        private bool AuthenticateUser(string username, string password)
        {
            // Replace this with your actual authentication logic
            var user = _Db.tblLogin.FirstOrDefault(u => u.userName == username && u.password == password);
            if (user != null)
            {
                // Authentication succeeded
                return true;
            }

            // Authentication failed
            return false;
        }








        public async Task<IActionResult> SaveLogin(LoginEntity obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.LoginId == 0)
                    {
                        _Db.tblLogin.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }

                    return RedirectToAction("LoginList");
                }

                return View(obj);
            }
            catch (Exception ex)
            {

                return RedirectToAction("LoginList");
            }
        }

        public async Task<IActionResult> DeleteLogin(int LoginId)
        {
            try
            {
                var item = await _Db.tblLogin.FindAsync(LoginId)

;
                if (item != null)
                {
                    _Db.tblLogin.Remove(item);
                    await _Db.SaveChangesAsync();
                }

                return RedirectToAction("LoginList");
            }
            catch (Exception ex)
            {

                return RedirectToAction("LoginList");
            }
        }
    }
}
