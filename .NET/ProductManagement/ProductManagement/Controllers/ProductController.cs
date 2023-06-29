using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductManagement.Models;
namespace ProductManagement.Controllers
{
    [CheckSessionExpirationAttribute]
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetData()
        {
            using (MyDatabase db = new MyDatabase())
            {
                var data = db.Products.Select(a => new ProductModel
                {
                    Id = a.Id,
                    ProductName = a.ProductName,
                    Active = a.Active
                }).ToList();
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Product()
        {
            MyDatabase db = new MyDatabase();
            List<Product> ProductList = db.Products.ToList();
            ViewBag.ListOfProduct = new SelectList(ProductList, "Id", "ProductName", "Status");
            List<Purchase> PurchaseList = db.Purchases.ToList();
            ViewBag.ListOfPurchase = new SelectList(PurchaseList, "PurchaseId", "PurchaseDate", "PurchaseQuantity");
            return View();
        }
        public JsonResult AddProduct(ProductModel pdt)
        {

            RepositoryClass repos = new RepositoryClass();
            repos.Add(pdt);
            return Json(new { success = true });
        }
        public JsonResult EditProduct(ProductModel product)
        {
            RepositoryClass repos = new RepositoryClass();
            repos.Edit(product);
            return Json(new { success = true });
        }
        
        public JsonResult GetOldProductName(int productid)
        {

            RepositoryClass repos = new RepositoryClass();
            ProductModel jsonData = repos.GetOldDetail(productid);
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}