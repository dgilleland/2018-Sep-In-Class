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
            RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
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
                throw new Exception($@"Security changes were not applied:<ul>
                                       {string.Join(string.Empty,
                                                    result.Errors
                                                    .Select(x => $"<li>{x}</li>"))}</ul>");
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
            if (existing == null)
                throw new Exception("The specified user was not found");
            else if (existing.UserName == ConfigurationManager.AppSettings["adminUserName"] && existing.UserName != user.UserName)
                throw new Exception("You are not allowed to modify the website administrator's user name");
            // Change certain parts of the found user
            existing.EmployeeId = user.EmployeeId;
            existing.Email = user.Email;
            existing.CustomerId = user.CustomerId;
            existing.PhoneNumber = user.PhoneNumber;
            existing.UserName = user.UserName; // Generally NOT a good idea to change this!
            var result = UserManager.Update(existing);
            CheckResult(result);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void DeleteUser(ApplicationUser user)
        {
            var existing = UserManager.FindById(user.Id);
            if (existing == null)
                throw new Exception("The specified user was not found");
            else if (existing.UserName == ConfigurationManager.AppSettings["adminUserName"])
                throw new Exception("You are not allowed to delete the website administrator");
            var result = UserManager.Delete(existing);
            CheckResult(result);
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
            var existing = RoleManager.FindById(role.Id);
            if (existing == null)
                throw new Exception("The specified role could not be found");
            else if (existing.Name == ConfigurationManager.AppSettings["adminRole"])
                throw new Exception("Cannot rename the administrator role");
            existing.Name = role.Name;
            CheckResult(RoleManager.Update(existing));
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void DeleteRole(IdentityRole role)
        {
            var existing = RoleManager.FindById(role.Id);
            if (existing == null)
                throw new Exception("The specified role could not be found");
            if (existing.Name == ConfigurationManager.AppSettings["adminRole"])
                throw new Exception("Cannot delete the administrator role");
            CheckResult(RoleManager.Delete(existing));
        }
        #endregion
    }
}