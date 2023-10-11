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

        public ActionResult RenderCategory()
        {
            List<CategoryByGender> categoryByGenders = db.CategoryByGenders.ToList();
            return PartialView("_listCategory", categoryByGenders);
        }

        public ActionResult RenderProductInHome()
        {
            List<Product> products = db.Products.Take(10).ToList();
            return PartialView("_listProductInHome", products);
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