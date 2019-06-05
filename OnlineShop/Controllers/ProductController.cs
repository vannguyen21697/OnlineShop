using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDao();
            return PartialView(model.ListProductCategory());
        }
        public ActionResult Category(long cateId,int page=1,int pageSize=2)
        {
            var category = new CategoryDao().detailCategory(cateId);
            ViewBag.Category = category;

            int totalRecord = 0;
            var model = new ProductDao().ListByCategory(cateId, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage =(int) Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            
            return View(model);
        }
        public ActionResult Detail(long id)
        {
            var product = new ProductDao().ViewDetail(id);
            ViewBag.Category = new ProductCategoryDao().ViewDetail(product.CategoryId.Value);
            ViewBag.Relatedproducts = new ProductDao().ListRelatedProducts(id);
            
            return View(product);
        }
        public ActionResult ListProduct()
        {
            var product = new ProductDao().lstProduct();
            return View(product);
        }
    }
}