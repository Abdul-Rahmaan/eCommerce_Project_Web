using eCommerceProjectWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace eCommerceProjectWeb.Controllers
{
    public class SellerController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly ProjectDBAccess _Db;
        public SellerController(ProjectDBAccess Db)

        {
            _Db = Db;
        }
        public IActionResult SellerList()
        {
            return View(_Db.tblSeller.ToList());
        }
        public async Task<IActionResult> AddSeller(SellerEntity obj)
        {
            return View(obj);
        }
        public async Task<IActionResult> SaveSeller(SellerEntity obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.SellerId == 0)
                    {
                        _Db.tblSeller.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }

                    return RedirectToAction("SellerList");
                }

                return View(obj);
            }
            catch (Exception ex)
            {

                return RedirectToAction("SellerList");
            }
        }

        public async Task<IActionResult> DeleteSeller(int SellerId)
        {
            try
            {
                var item = await _Db.tblSeller.FindAsync(SellerId)

;
                if (item != null)
                {
                    _Db.tblSeller.Remove(item);
                    await _Db.SaveChangesAsync();
                }

                return RedirectToAction("SellerList");
            }
            catch (Exception ex)
            {

                return RedirectToAction("SellerList");
            }
        }
    }
}
