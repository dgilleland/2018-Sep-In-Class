using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Admin.Security.DTOs
{
    public class RegisteredUser
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public UserType? UserType { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }
            = new List<UserRole>();

        public class UserRole
        {
            public string RoleId { get; set; }
            public string RoleName { get; set; }
        }
    }

    public enum UserType { Employee, Customer }
}