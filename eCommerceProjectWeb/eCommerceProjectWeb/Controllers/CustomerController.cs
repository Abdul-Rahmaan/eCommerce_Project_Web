using eCommerceProjectWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace eCommerceProjectWeb.Controllers
{
    public class CustomerController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly ProjectDBAccess _Db;
        public CustomerController(ProjectDBAccess Db)

        {
            _Db = Db;
        }
        public IActionResult CustomerList()
        {
            return View(_Db.tblCustomer.ToList());
        }
        public async Task<IActionResult> AddCustomer(CustomerEntity obj)
        {
            return View(obj);
        }
        public async Task<IActionResult> SaveCustomer(CustomerEntity obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.CostId == 0)
                    {
                        _Db.tblCustomer.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }

                    return RedirectToAction("CustomerList");
                }

                return View(obj);
            }
            catch (Exception ex)
            {

                return RedirectToAction("CustomerList");
            }
        }

        public async Task<IActionResult> DeleteCustomer(int CustomerId)
        {
            try
            {
                var item = await _Db.tblCustomer.FindAsync(CustomerId)

;
                if (item != null)
                {
                    _Db.tblCustomer.Remove(item);
                    await _Db.SaveChangesAsync();
                }

                return RedirectToAction("CustomerList");
            }
            catch (Exception ex)
            {

                return RedirectToAction("CustomerList");
            }
        }
    }
}
