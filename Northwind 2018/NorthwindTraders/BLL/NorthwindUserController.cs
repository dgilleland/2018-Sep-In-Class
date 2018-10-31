using NorthwindTraders.DAL;
using NorthwindTraders.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTraders.BLL
{
    public class NorthwindUserController
    {
        public List<UserProfile> ListUsers()
        {
            using (var context = new NorthwindContext())
            {
                var employees = from emp in context.Employees
                                select new UserProfile
                                {
                                    Id = emp.EmployeeID.ToString(),
                                    Name = emp.FirstName,
                                    OtherName = emp.LastName,
                                    UserType = UserType.Employee
                                };
                var customers = from cust in context.Customers
                                select new UserProfile
                                {
                                    Id = cust.CustomerID,
                                    Name = cust.ContactName,
                                    OtherName = cust.CompanyName,
                                    UserType = UserType.Customer
                                };
                var result = employees.Union(customers);
                return result.ToList();
            }
        }
    }
}
