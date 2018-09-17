using NorthwindTraders.Entities.POCOs;
using System;
using System.Collections.Generic;

namespace NorthwindTraders.Entities.DTOs
{
    public class StaffProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public DateTime? HireDate { get; set; }
        public byte[] Photo { get; set; }
        public IEnumerable<StaffTerritory> Territories { get; set; }
    }
}
