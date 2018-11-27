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
using WebApp.Admin.Security.DTOs;
using WebApp.Admin.Security.Pocos;
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

        #region Private helper methods
        private void CheckResult(IdentityResult result)
        {
            if (!result.Succeeded)
                throw new Exception($@"Security changes were not applied:<ul>
                                       {string.Join(string.Empty,
                                                    result.Errors
                                                    .Select(x => $"<li>{x}</li>"))}</ul>");
        }
        #endregion

        #region ApplicationUser CRUD
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<RegisteredUser> ListUsers()
        {
            // Adapt the list of ApplicationUser objects from the UserManager
            // to a collection of RegisteredUser objects
            var result = from person in UserManager.Users.ToList()
                         select new RegisteredUser
                         {
                             UserId = person.Id,
                             UserName = person.UserName,
                             Email = person.Email,
                             PhoneNumber = person.PhoneNumber,
                             UserType = person.EmployeeId.HasValue ? UserType.Employee
                                      : string.IsNullOrWhiteSpace(person.CustomerId) ? UserType.Customer
                                      :  (UserType?) null,
                             UserRoles = from role in person.Roles
                                         select new RegisteredUser.UserRole
                                         {
                                             RoleId = role.RoleId,
                                             RoleName = RoleManager.FindById(role.RoleId).Name
                                         }
                         };
            return result.ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void AddUser(RegisteredUser user)
        {
            // NOTE: Ideally, we should be doing this in a TransactionScope to ensure
            //       that it all succeeds or fails as a group.
            var appUser = new ApplicationUser
            {
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
            IdentityResult result = UserManager.Create(appUser, ConfigurationManager.AppSettings["newUserPassword"]);
            CheckResult(result);

            if (user.UserRoles.Any()) // Faster than user.UserRoles.Count() > 0
            {
                // Note that the ID of the role should be treated as the "more reliable"
                // truth about the role as supplied from the presentation layer.
                var roles = from role in user.UserRoles
                            select RoleManager.FindById(role.RoleId).Name;
                result =
                    UserManager.AddToRoles(UserManager.FindByName(appUser.UserName).Id,
                                           roles.ToArray());
                CheckResult(result);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void UpdateUser(RegisteredUser user)
        {
            // NOTE: Ideally, we should be doing this in a TransactionScope to ensure
            //       that it all succeeds or fails as a group.
            var existing = UserManager.FindById(user.UserId);
            if (existing == null)
                throw new Exception("The specified user was not found");
            if (existing.UserName == ConfigurationManager.AppSettings["adminUserName"] &&
                existing.UserName != user.UserName)
                throw new Exception("You are not allowed to modify the website administrator's user name");
            var adminRoleId = RoleManager.FindByName(ConfigurationManager.AppSettings["adminRole"]).Id;
            if (existing.UserName == ConfigurationManager.AppSettings["adminUserName"] &&
                !user.UserRoles.Any(x => x.RoleId == adminRoleId))
                throw new Exception("You are not allowed to remove the website administrator from their administration role");

            // Change certain parts of the found user
            existing.Email = user.Email;
            existing.PhoneNumber = user.PhoneNumber;
            existing.UserName = user.UserName; // Generally NOT a good idea to change this!
            var result = UserManager.Update(existing);
            CheckResult(result);

            // Remove from any roles not in the list supplied
            var removeRoles = existing.Roles
                             .Where(x => !user.UserRoles.Any(y => x.RoleId == y.RoleId))
                             .Select(x => RoleManager.FindById(x.RoleId).Name);
            if (removeRoles.Any())
            {
                result = UserManager.RemoveFromRoles(user.UserId,
                                                     removeRoles.ToArray());
                CheckResult(result);
            }

            // Add to roles any that are new
            var currentRoles = existing.Roles
                              .Where(x => user.UserRoles.Any(y => x.RoleId == y.RoleId));
            var newRoles = user.UserRoles
                           .Where(x => !currentRoles.Any(y => x.RoleId == y.RoleId))
                           .Select(x => RoleManager.FindById(x.RoleId).Name);
            if (newRoles.Any())
            {
                result = UserManager.AddToRoles(user.UserId,
                                                newRoles.ToArray());
                CheckResult(result);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void DeleteUser(RegisteredUser user)
        {
            var existing = UserManager.FindById(user.UserId);
            if (existing == null)
                throw new Exception("The specified user was not found");
            if (existing.UserName == ConfigurationManager.AppSettings["adminUserName"])
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

        #region Employee/Customer IDs
        public int? GetCurrentUserEmployeeId(string userName)
        {
            int? id = null;
            var request = HttpContext.Current.Request;
            if (request.IsAuthenticated)
            {
                var manager = request.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var appUser = manager.Users.SingleOrDefault(x => x.UserName == userName);
                if (appUser != null)
                    id = appUser.EmployeeId;
            }
            return id;
        }

        public string GetCurrentUserCustomerId(string userName)
        {
            string id = null;
            var request = HttpContext.Current.Request;
            if (request.IsAuthenticated)
            {
                var manager = request.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var appUser = manager.Users.SingleOrDefault(x => x.UserName == userName);
                if (appUser != null)
                    id = appUser.CustomerId;
            }
            return id;
        }
        #endregion
    }
}