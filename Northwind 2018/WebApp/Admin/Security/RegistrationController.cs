using NorthwindTraders.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using WebApp.Admin.Security.Pocos;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using NorthwindTraders.Entities.POCOs;
using WebApp.Models;
using System.Configuration;

namespace WebApp.Admin.Security
{
    [DataObject]
    public class RegistrationController
    {
        #region Business Process Operations
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<UnregisteredUser> ListAllUnregisteredUsers()
        {
            // Make an in-memory list of employees & customers who have login accounts
            var userManager = HttpContext.Current.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var registered = from user in userManager.Users
                             where user.EmployeeId.HasValue
                                || user.CustomerId != null
                             select new
                             {
                                 UserName = user.UserName,
                                 NorthwindId = user.EmployeeId.HasValue
                                             ? user.EmployeeId.ToString()
                                             : user.CustomerId
                             };

            // List Northwind Users (employees & customers)
            var controller = new NorthwindUserController();
            var northwindUsers = controller.ListUsers();

            // Determine who's not yet registered (assigning default usernames/emails)
            var unregistered = from person in northwindUsers
                               where !registered.Any(x => x.NorthwindId == person.Id)
                               select new UnregisteredUser()
                               {
                                   Id = person.Id,
                                   Name = person.Name,
                                   OtherName = person.OtherName,
                                   UserType = person.UserType,
                                   AssignedUserName = person.UserType == UserType.Employee
                                                    ? $"{person.Name}.{person.OtherName}".Replace(" ", "")
                                                    : null,
                                   AssignedEmail = person.UserType == UserType.Employee
                                                 ? $"{person.Name}.{person.OtherName}@Northwind.tba".Replace(" ", "")
                                                 : null
                               };
            return unregistered.ToList();
        }

        public void RegisterUser(UnregisteredUser userInfo)
        {
            // Basic validation
            if (userInfo == null)
                throw new ArgumentNullException(nameof(userInfo), "Data for unregistered users is required");
            if (string.IsNullOrEmpty(userInfo.AssignedUserName))
                throw new ArgumentException("New users must have a username", nameof(userInfo.AssignedUserName));

            var userAccount = new ApplicationUser()
            {
                UserName = userInfo.AssignedUserName,
                Email = userInfo.AssignedEmail
            };
            switch (userInfo.UserType)
            {
                case UserType.Customer:
                    userAccount.CustomerId = userInfo.Id;
                    break;
                case UserType.Employee:
                    userAccount.EmployeeId = int.Parse(userInfo.Id);
                    break;
            }

            var userManager = HttpContext.Current.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var identityResult = userManager.Create(userAccount, ConfigurationManager.AppSettings["newUserPassword"]); // or randomPassword
            if (identityResult.Succeeded)
            {
                switch (userInfo.UserType)
                {
                    case UserType.Employee:
                        userManager.AddToRole(userAccount.Id, ConfigurationManager.AppSettings["employeeRole"]);
                        break;
                    case UserType.Customer:
                        userManager.AddToRole(userAccount.Id, ConfigurationManager.AppSettings["customerRole"]);
                        break;
                }
            }
            else
            {
                throw new Exception($@"Security changes were not applied:<ul> 
                                       {string.Join(string.Empty,
                                                    identityResult.Errors
                                                    .Select(x => $"<li>{x}</li>"))}</ul>");
            }
        }
        #endregion
    }
}