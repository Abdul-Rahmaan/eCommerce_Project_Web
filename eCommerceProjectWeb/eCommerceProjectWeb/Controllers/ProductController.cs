using eCommerceProjectWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;

namespace eCommerceProjectWeb.Controllers
{
    public class ProductController : Controller
    {
       
            private readonly ProjectDBAccess _Db;
            public ProductController(ProjectDBAccess Db)

            {
                _Db = Db;
            }

        private void loadSell()
        {
            try
            {
                List<SellerEntity> SellList = new List<SellerEntity>();
                SellList = _Db.tblSeller.ToList();

                SellList.Insert(0, new SellerEntity { SellerId = 0, SellerName = "Please Select" });

                ViewBag.SellList = SellList;

            }
            catch (Exception ex)
            {


            }
        }


        public IActionResult ProductList()
            {

            try
            {


                var ProductList = from a in _Db.tblProduct
                                  join b in _Db.tblSeller
                                  on a.SellerId equals b.SellerId
                                  into Product
                                  from b in Product.DefaultIfEmpty()




                                  select new ProductEntity
                                  {
                                      ProId = a.ProId,
                                     ProName = a.ProName,
                                     ProQuantity = a.ProQuantity,
                                     ProPrice = a.ProPrice,
                                     ProCategory = a.ProCategory,

                                     SellerId = a.SellerId,
                                     SellerName  = b == null ? "" : b.SellerName

                                 };


                return View(ProductList);
            }
            catch (Exception ex)
            {
                return View();

            }



            //return View(_Db.tblProduct.ToList());
        }
            public async Task<IActionResult> AddProduct(ProductEntity obj)
            {
               loadSell();
                return View(obj);
            }
            public async Task<IActionResult> SaveProduct(ProductEntity obj)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        if (obj.ProId == 0)
                        {
                            _Db.tblProduct.Add(obj);
                            await _Db.SaveChangesAsync();
                        }
                        else
                        {
                            _Db.Entry(obj).State = EntityState.Modified;
                            await _Db.SaveChangesAsync();
                        }

                        return RedirectToAction("ProductList");
                    }

                    return View(obj);
                }
                catch (Exception ex)
                {

                    return RedirectToAction("ProductList");
                }
            }

            public async Task<IActionResult> DeleteProduct(int ProId)
            {
                try
                {
                    var item = await _Db.tblProduct.FindAsync(ProId)

    ;
                    if (item != null)
                    {
                        _Db.tblProduct.Remove(item);
                        await _Db.SaveChangesAsync();
                    }

                    return RedirectToAction("ProductList");
                }
                catch (Exception ex)
                {

                    return RedirectToAction("ProductList");
                }
            }
        

    }
}
