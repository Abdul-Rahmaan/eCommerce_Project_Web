using eCommerceProjectWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceProjectWeb.Controllers
{
    public class CategoryController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly ProjectDBAccess _Db;
        public CategoryController(ProjectDBAccess Db)

        {
            _Db = Db;
        }
        public IActionResult CategoryList()
        {
            return View(_Db.tblCategory.ToList());
        }
        public async Task<IActionResult> AddCategory(CategoryEntity obj)
        {
            return View(obj);
        }
        public async Task<IActionResult> SaveCategory(CategoryEntity obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.CategoryId == 0)
                    {
                        _Db.tblCategory.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }

                    return RedirectToAction("CategoryList");
                }

                return View(obj);
            }
            catch (Exception ex)
            {

                return RedirectToAction("CategoryList");
            }
        }

        public async Task<IActionResult> DeleteCategory(int CategoryId)
        {
            try
            {
                var item = await _Db.tblCategory.FindAsync(CategoryId)

;
                if (item != null)
                {
                    _Db.tblCategory.Remove(item);
                    await _Db.SaveChangesAsync();
                }

                return RedirectToAction("CategoryList");
            }
            catch (Exception ex)
            {

                return RedirectToAction("CategoryList");
            }
        }

    }
}
