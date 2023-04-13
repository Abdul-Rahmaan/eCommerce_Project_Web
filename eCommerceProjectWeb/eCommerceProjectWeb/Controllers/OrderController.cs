using eCommerceProjectWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;

namespace eCommerceProjectWeb.Controllers
{
    public class OrderController : Controller
    {






        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly ProjectDBAccess _Db;
        public OrderController(ProjectDBAccess Db)

        {
            _Db = Db;
        }

        //Method to Load Categories in Add Item View Page

        private void loadPro()
        {
            try
            {
                List<ProductEntity> ProList = new List<ProductEntity>();
                ProList = _Db.tblProduct.ToList();

                ProList.Insert(0, new ProductEntity { ProId = 0, ProName = "Please Select" });

                ViewBag.ProList = ProList;

            }
            catch (Exception ex)
            {


            }
        }
        private void loadCost()
        {
            try
            {
                List<CustomerEntity> CostList = new List<CustomerEntity>();
                CostList = _Db.tblCustomer.ToList();

                CostList.Insert(0, new CustomerEntity { CostId = 0, CostName = "Please Select" });

                ViewBag.CostList = CostList;

            }
            catch (Exception ex)
            {


            }
        }


        private void loadSeller()
        {
            try
            {
                List<SellerEntity> SellerList = new List<SellerEntity>();
                SellerList = _Db.tblSeller.ToList();

                SellerList.Insert(0, new SellerEntity { SellerId = 0, SellerName = "Please Select" });

                ViewBag.SellerList = SellerList;

            }
            catch (Exception ex)
            {


            }
        }


        public IActionResult OrderList()
        {
            //return View(_Db.tblOrder.ToList());

            try
            {


                var OrderList = from a in _Db.tblOrder
                                  join b in _Db.tblProduct
                                  on a.ProId equals b.ProId
                                  into Order
                                  from b in Order.DefaultIfEmpty()




                                  select new OrderEntity
                                  {

                                      ProId = a.ProId,
                                      ProName = b == null ? "" : b.ProName,
                                      CostId = a.CostId,
                                      SellerId = a.SellerId,
                                      OrderTotal = a.OrderTotal,
                                      OrderStatus = a.OrderStatus,
                                      PaymentStatus = a.PaymentStatus,
                                      OrderDate = a.OrderDate

                                  };


                return View(OrderList);
            }
            catch (Exception ex)
            {
                return View();

            }

        }
        public async Task<IActionResult> AddOrder(OrderEntity obj)
        {
            loadPro();
            loadCost();
            loadSeller();
            return View(obj);
        }
        public async Task<IActionResult> SaveOrder(OrderEntity obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.OrderId == 0)
                    {
                        _Db.tblOrder.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }

                    return RedirectToAction("OrderList");
                }

                return View(obj);
            }
            catch (Exception ex)
            {

                return RedirectToAction("OrderList");
            }
        }

        public async Task<IActionResult> DeleteOrder(int OrderId)
        {
            try
            {
                var item = await _Db.tblOrder.FindAsync(OrderId)

;
                if (item != null)
                {
                    _Db.tblOrder.Remove(item);
                    await _Db.SaveChangesAsync();
                }

                return RedirectToAction("OrderList");
            }
            catch (Exception ex)
            {

                return RedirectToAction("OrderList");
            }
        }
    }
}
