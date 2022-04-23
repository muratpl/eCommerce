using eCommerce.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.UI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            //eCommerceWS.eCommerceWebServiceSoapClient svc = new eCommerceWS.eCommerceWebServiceSoapClient();
            eCommerceWCFService.Service1Client svc = new eCommerceWCFService.Service1Client();

            return View(svc.getUsers());
        }

        
    }
}