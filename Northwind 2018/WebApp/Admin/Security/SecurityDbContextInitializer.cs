using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Admin.Security
{
    // You can learn about Database Initialization Strategies in EF6 via
    // http://www.entityframeworktutorial.net/code-first/database-initialization-strategy-in-code-first.aspx

    public class SecurityDbContextInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {

        protected override void Seed(ApplicationDbContext context)
        {
            #region Seed the roles
            string adminRole = ConfigurationManager.AppSettings["adminRole"];
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            roleManager.Create(new IdentityRole { Name = adminRole });
            var startupRoles = ConfigurationManager.AppSettings["startupRoles"].Split(';');
            foreach(var role in startupRoles)
                roleManager.Create(new IdentityRole { Name = role });
            #endregion

            #region Seed the users
            string adminUser = ConfigurationManager.AppSettings["adminUserName"];
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var result = userManager.Create(new ApplicationUser
            {
                UserName = adminUser,
                Email = ConfigurationManager.AppSettings["adminEmail"]
            }, ConfigurationManager.AppSettings["adminPassword"]);
            if (result.Succeeded)
                userManager.AddToRole(userManager.FindByName(adminUser).Id, adminRole);
            #endregion

            // ... etc. ...

            base.Seed(context);
        }
    }
}