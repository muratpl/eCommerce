using eCommerce.BLL;
using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private ProductService ps = new ProductService();


        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = ps.GetAll();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            Product product = ps.GetById(id);
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(new CategoryService().GetAll(), "Id", "Name", 1);
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                bool basariliMi = ps.Create(product);
                if (basariliMi)
                    return RedirectToAction("Index");
                else
                    throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = ps.GetById(id);
            ViewBag.CategoryId = new SelectList(new CategoryService().GetAll(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                bool basariliMi = ps.Update(product);
                if (basariliMi)
                    return RedirectToAction("Index");
                else
                    throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            Product product = ps.GetById(id);
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                bool basariliMi = ps.Delete(id);
                if (basariliMi)
                    return RedirectToAction("Index");
                else
                    throw new Exception();
            }
            catch
            {
                return View();
            }
        }
    }
}