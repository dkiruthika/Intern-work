using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductManagement.Models;
namespace ProductManagement.Controllers
{
    [CheckSessionExpirationAttribute]
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Purchase()
        {
            MyDatabase db = new MyDatabase();
            List<Product> ProductList = db.Products.ToList();
            ViewBag.ListOfProduct = new SelectList(ProductList, "Id", "ProductName", "Active");
            List<Purchase> PurchaseList = db.Purchases.ToList();
            ViewBag.ListOfPurchase = new SelectList(PurchaseList, "Id", "PurchaseDate", "Quantity");
            return View();
        }
        public ActionResult GetPurchaseData()
        {
            using (MyDatabase db = new MyDatabase())
            {
                var data = db.Purchases.Select(a => new
                {
                    Id = a.Id,
                    ProductId = a.ProductId,
                    PurchaseDate = a.PurchaseDate,
                    Quantity = a.Quantity
                }).ToList()
                .Select(a => new PurchaseModel
                {
                    Id = a.Id,
                    ProductId = a.ProductId,
                    PurchaseDate = a.PurchaseDate.ToString("yyyy-MM-dd"),
                    Quantity = a.Quantity
                }).ToList();
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult AddPurchase(PurchaseModel purchase)
        {

            RepositoryClass repos = new RepositoryClass();
            repos.Add(purchase);
            return Json(new { success = true });
        }
    }
}