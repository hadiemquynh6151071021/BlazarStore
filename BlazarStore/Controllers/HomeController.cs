using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlazarStore.Models;
using PagedList;

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
            return View();
        }

        public ActionResult RenderCategory()
        {
            List<CategoryByGender> categoryByGenders = db.CategoryByGenders.ToList();
            return PartialView("_listCategory", categoryByGenders);
        }
        public ActionResult RenderAllProduct(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            List<Product> products = db.Products.ToList();
            return PartialView("_listProductInHome", products.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult RenderProduct(string id, int ?page)
        {
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            if (page == null) page = 1;
            List<Product> products = db.Products.Where(m => m.CategoryByGender.Category_by_gender == id).ToList();
            pageSize = 15;
            pageNumber = (page ?? 1);
            return PartialView("_listProductCategories", products.ToPagedList(pageNumber, pageSize));

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