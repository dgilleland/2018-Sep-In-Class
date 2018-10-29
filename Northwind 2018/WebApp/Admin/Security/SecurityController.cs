using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity; // for the IdentityRole and RoleManager, etc.
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin; // for the .GetOwinContext() extension method
using WebApp; // for the .GetUserManager<T>() extension method
using WebApp.Models; // for the ApplicationUser class

namespace WebApp.Admin.Security
{
    [DataObject]
    public class SecurityController
    {
        #region Constructor & Dependencies
        private readonly ApplicationUserManager UserManager;
        private readonly RoleManager<IdentityRole> RoleManager;
        public SecurityController()
        {
            UserManager = HttpContext.Current.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
        }
        #endregion

        #region ApplicationUser CRUD
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ApplicationUser> ListUsers()
        {
            return UserManager.Users.ToList();
        }

        private void CheckResult(IdentityResult result)
        {
            if (!result.Succeeded)
                throw new Exception($"Failed to add new user:<ul> {string.Join(string.Empty, result.Errors.Select(x => $"<li>{x}</li>"))}</ul>");
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void AddUser(ApplicationUser user)
        {
            IdentityResult result = UserManager.Create(user, ConfigurationManager.AppSettings["newUserPassword"]);
            CheckResult(result);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void UpdateUser(ApplicationUser user)
        {
            var existing = UserManager.FindById(user.Id);
            if (existing != null)
            {
                var result = UserManager.Update(user);
                CheckResult(result);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void DeleteUser(ApplicationUser user)
        {
            var existing = UserManager.FindById(user.Id);
            if (existing != null)
            {
                var result = UserManager.Delete(user);
                CheckResult(result);
            }
        }
        #endregion

        #region IdentityRole CRUD
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<IdentityRole> ListRoles()
        {
            return RoleManager.Roles.ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void AddRole(IdentityRole role)
        {
            CheckResult(RoleManager.Create(role));
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void UpdateRole(IdentityRole role)
        {
            CheckResult(RoleManager.Update(role));
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void DeleteRole(IdentityRole role)
        {
            CheckResult(RoleManager.Delete(role));
        }
        #endregion
    }
}