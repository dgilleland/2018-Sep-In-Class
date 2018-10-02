using System;
using System.Linq;

namespace NorthwindTraders.Entities.POCOs
{
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
