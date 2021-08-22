using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace BlogSitesi.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            if (!context.Roles.Any(m => m.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole()
                {
                    Name = "admin",
                    Description = "adminrolu"
                };
                manager.Create(role);

            }

            if (!context.Roles.Any(m => m.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole()
                {
                    Name = "user",
                    Description = "userrolu"
                };
                manager.Create(role);
            }
            if (!context.Users.Any(m => m.Name == "zenginzorbey"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                {
                    Name = "zorbey",
                    SurName = "zengin",
                    UserName = "zenginzorbey",
                    Email = "huseyinzorbey34@gmail.com"
                };
                manager.Create(user, "15031993");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");


            }

            if (!context.Users.Any(m => m.Name == "huseyinzengin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                {
                    Name = "huseyin",
                    SurName = "zengin",
                    UserName = "huseyinzengin",
                    Email = "huseyinzengin@gmail.com"
                };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "user");

            }


            base.Seed(context);

        }
    }
}