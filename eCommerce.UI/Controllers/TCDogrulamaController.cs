using eCommerce.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.UI.Controllers
{
    public class TCDogrulamaController : Controller
    {
        // GET: TCDogrulama
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KimlikDogrulama()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KimlikDogrulama(Vatandas vatandas)
        {
            //eCommerceWS.eCommerceWebServiceSoapClient svc = new eCommerceWS.eCommerceWebServiceSoapClient();
            //eCommerceWCFService.Service1Client svc = new eCommerceWCFService.Service1Client();
            TCKimlikNoServisiDogrulama.KPSPublicSoapClient svc = new TCKimlikNoServisiDogrulama.KPSPublicSoapClient();
            bool response = svc.TCKimlikNoDogrula(vatandas.TcKimlikNo, vatandas.Ad.ToUpper(), vatandas.Surname.ToUpper(), vatandas.dogumYili);
            if (response)
                ViewBag.sonuc = "Doğrulandı...";
            else
                ViewBag.sonuc = "Başarısız...";

            return View();
        }
    }
}