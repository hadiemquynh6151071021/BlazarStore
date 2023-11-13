using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
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
            return View(db.Products.Take(30).ToList());
        }

        public ActionResult RenderCategory()
        {
            List<CategoryByGender> categoryByGenders = db.CategoryByGenders.ToList();
            return PartialView("_listCategory", categoryByGenders);
        }
        public ActionResult RenderAllProduct()
        {
            //if (page == null) page = 1;
            //int pageSize = 15;
            //int pageNumber = (page ?? 1);
            List<Product> products = db.Products.Take(15).ToList();
            return PartialView("_listProductInHome", products);
        }
        public ActionResult RenderProduct(string id)
        {
            //int pageSize = 15;
            //int pageNumber = (page ?? 1);
            //if (page == null) page = 1;
            List<Product> products = db.Products.Where(m => m.CategoryByGender.Category_by_gender == id).Take(15).ToList();
            //pageSize = 15;
            //pageNumber = (page ?? 1);
            return PartialView("_listProductInHome", products);

        }

        public ActionResult RenderProductCategories(int? page, string categoryId)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            if (categoryId == null || categoryId == "all")
            {

                var productList = db.Products.ToList();
                IPagedList<Product> pagedProductList = productList.ToPagedList(pageNumber, pageSize);
                // Trả về PartialView với đối tượng PagedList
                return PartialView("_listProductCategories", pagedProductList);

            }
            else
            {
                // Lấy danh sách sản phẩm từ nguồn dữ liệu của bạn dựa trên categoryId
                var productList = db.Products.Where(m => m.CategoryByGender.Category_by_gender == categoryId).ToList();

                // Chuyển đổi danh sách thành một đối tượng PagedList
                IPagedList<Product> pagedProductList = productList.ToPagedList(pageNumber, pageSize);

                // Trả về PartialView với đối tượng PagedList
                return PartialView("_listProductCategories", pagedProductList);
            }
        }

        //public ActionResult RenderProductCategories(string id, int? page)
        //{
        //    int pageSize = 15;
        //    int pageNumber = (page ?? 1);
        //    if (page == null) page = 1;
        //    pageSize = 15;
        //    if (id == "all")
        //    {
        //        List<Product> products = db.Products.ToList();
        //        return PartialView("_listProductCategories", products);
        //    }
        //    else
        //    {
        //        List<Product> products = db.Products.Where(m => m.CategoryByGender.Category_by_gender == id).ToList();
        //        return PartialView("_listProductCategories", products);
        //    }

        //}

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