using eCommerce.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.UI.Controllers
{
    public class ApiUsingController : Controller
    {
        // GET: ApiKullanimi
        public ActionResult Index() //Category Listeleme Sayfası...
        {
            WebClient musteri = new WebClient { Encoding = System.Text.Encoding.UTF8 };
            var json = musteri.DownloadString("http://localhost:54952/api/Category/");
            var category = JsonConvert.DeserializeObject<List<Category>>(json);
            return View(category);
        }

        public ActionResult Products() //Products Listeleme Sayfası...
        {
            WebClient musteri = new WebClient { Encoding = System.Text.Encoding.UTF8 };
            var json = musteri.DownloadString("http://localhost:54952/api/Product/");
            var product = JsonConvert.DeserializeObject<List<Product>>(json);
            return View(product);
        }

        public ActionResult Users() //Users Listeleme Sayfası...
        {
            WebClient musteri = new WebClient { Encoding = System.Text.Encoding.UTF8 };
            var json = musteri.DownloadString("http://localhost:54952/api/User/");
            var user = JsonConvert.DeserializeObject<List<User>>(json);
            return View(user);
        }
    }
}