using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTraders.Entities.POCOs
{
    public class UserProfile
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string OtherName { get; set; }
        public UserType UserType { get; set; }
    }
    public enum UserType { Customer, Employee }
}
