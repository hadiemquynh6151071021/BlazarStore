using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlazarStore.Models;

namespace BlazarStore.Controllers
{
    public class HomeController : Controller
    {
        BlazarShopEntities db = new BlazarShopEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories()
        {
            List<Product> products = db.Products.Take(10).ToList();
            return View(products);
        }

        public ActionResult RenderCategory()
        {
            List<CategoryByGender> categoryByGenders = db.CategoryByGenders.ToList();
            return PartialView("_listCategory", categoryByGenders);
        }
        public ActionResult RenderAllProduct()
        {
            List<Product> products = db.Products.Take(15).ToList();
            return PartialView("_listProductInHome", products);
        }
        public ActionResult RenderProduct(string id)
        {
            if( id == "all")
            {
                List<Product> products = db.Products.Take(15).ToList();
                return PartialView("_listProductInHome", products);
            }
            else 
            {
                List<Product> products = db.Products.Where(m => m.CategoryByGender.Category_by_gender == id).Take(15).ToList();
                return PartialView("_listProductInHome", products);
            }
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}