using eCommerce.BLL;
using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.UI.Areas.Admin.Controllers
{
    [Authorize(Roles ="admin")]
    public class CategoryController : Controller
    {
        private CategoryService cs = new CategoryService();


        // GET: Category
        public ActionResult Index()
        {
            //var Categories = new Repository<Category, int>().GetAll();   
            //Genericlerin kullanimini gostermek icin.. Alttaki kulanilir normalde...
            List<Category> Categories = cs.GetAll();
            return View(Categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            Category Category = cs.GetById(id);
            return View(Category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category Category)
        {
            try
            {
                bool basariliMi = cs.Create(Category);
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

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            Category Category = cs.GetById(id);
            return View(Category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category Category)
        {
            try
            {
                bool basariliMi = cs.Update(Category);
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

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            Category Category = cs.GetById(id);
            return View(Category);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                bool basariliMi = cs.Delete(id);
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