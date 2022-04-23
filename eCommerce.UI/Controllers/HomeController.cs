using eCommerce.BLL;
using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var products = new ProductService().GetAll();

            return View(products);
        }

        /*
        //DENEMEK İÇİN..
        public ActionResult CategorySorgu()
        {
            var BirinciProduct = new ProductService().GetById(1);
            return View(BirinciProduct);
        }

        //DENEMEK İÇİN..
        public ActionResult CategoryEkle()
        {
            Category Category = new Category()
            {
                Id = 90,
                Ad = "Yeni"
            };

            var CategoryEkle = new CategoryService().Create(Category);
            return View(CategoryEkle);
        }
        */
    }
}