using eCommerce.BLL;
using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace eCommerce.WebService
{
    /// <summary>
    /// Summary description for eCommerceWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class eCommerceWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string YasSoyle(string ad, int dogumYili)
        {
            return "Merhaba " + ad + " Yaşın: " + (DateTime.Now.Year - dogumYili).ToString();
        }

        [WebMethod]
        public List<User> getUsers()
        {
            return new UserService().GetAll();
        }
    }
}
