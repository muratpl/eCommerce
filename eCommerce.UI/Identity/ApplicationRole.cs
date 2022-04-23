using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerce.UI.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public string Aciklama { get; set; }

        public ApplicationRole()
        {

        }

        public ApplicationRole(string rolIsmi, string aciklama)
        {
            this.Name = rolIsmi;
            this.Aciklama = aciklama;
        }
    }

    
}