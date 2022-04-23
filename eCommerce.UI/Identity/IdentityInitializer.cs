using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eCommerce.UI.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            if(!context.Roles.Any(i=> i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var rol = new ApplicationRole("admin", "Bu rol yönetici rolüdür.");
                manager.Create(rol);
            }

            if (!context.Roles.Any(i=> i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var rol = new ApplicationRole("user", "Bu rol normal userdir.");
                manager.Create(rol);
            }

            if(!context.Users.Any(i => i.UserName == "fatih123"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "Murat Pala", Surname = "Pala", UserName = "Shakumakavelli", Email = "muratpala007@gmail.com" };
                manager.Create(user, "murat123");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }

            if (!context.Users.Any(i => i.UserName == "ayse123"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "Ayşe Pala", Surname = "Pala", UserName = "ayse123", Email = "aysepala007@gmail.com" };
                manager.Create(user, "ayse123");
                manager.AddToRole(user.Id, "user");
            }

            base.Seed(context);
        }
    }
}