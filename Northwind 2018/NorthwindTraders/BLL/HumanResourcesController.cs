using NorthwindTraders.DAL;
using NorthwindTraders.Entities;
using NorthwindTraders.Entities.DTOs;
using NorthwindTraders.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace NorthwindTraders.BLL
{
    [DataObject]
    public class HumanResourcesController
    {
        #region Business Processes
        #region Commands
        public void AssignEmployeeTerritory(TerritoryAssignment assignment)
        {
            using (var context = new NorthwindContext())
            {
                var employee = context.Employees.Find(assignment.EmployeeId);
                var territory = context.Territories.Find(assignment.TerritoryId);
                employee.Territories.Add(territory);

                context.SaveChanges();
            }
        }

        public void RemoveTerritoryAssignment(TerritoryAssignment assignment)
        {
            using (var context = new NorthwindContext())
            {
                var employee = context.Employees.Find(assignment.EmployeeId);
                var territory = context.Territories.Find(assignment.TerritoryId);
                employee.Territories.Remove(territory);

                context.SaveChanges();
            }
        }

        public void HireEmployee(NewEmployeeProfile profile)
        {
            using (var context = new NorthwindContext())
            {
                var employee = new Employee()
                {
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    Title = profile.Title,
                    TitleOfCourtesy = profile.TitleOfCourtesy,
                    BirthDate = profile.BirthDate,
                    HireDate = profile.StartDate,
                    Address = profile.Address,
                    City = profile.City,
                    Region = profile.Region,
                    PostalCode = profile.PostalCode,
                    Country = profile.Country,
                    HomePhone = profile.HomePhone,
                    Extension = profile.Extension,
                    Photo = profile.RawPhoto,
                    Notes = profile.Notes,
                    ReportsTo = profile.Supervisor
                };
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }

        public void FireEmployee(int employeeId, IEnumerable<TerritoryAssignment> reassignedTerritories, DateTime terminationDate)
        {
            using (var context = new NorthwindContext())
            {
                foreach (var assignment in reassignedTerritories)
                {
                    var employee = context.Employees.Find(assignment.EmployeeId);
                    var territory = context.Territories.Find(assignment.TerritoryId);
                    employee.Territories.Add(territory);
                }

                var firedEmployee = context.Employees.Find(employeeId);
                // TODO: FireEmployee - Required change to Employees table (add nullable ReleaseDate)
                //firedEmployee.ReleaseDate = terminationDate;
                //context.Entry(firedEmployee).State = EntityState.Modified;

                // Saves as a transaction in EF
                context.SaveChanges();
            }
        }
        #endregion
        #region Queries
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Territory> ListUnassignedTerritories()
        {
            using (var context = new NorthwindContext())
            {
                var results = from data in context.Territories
                              where data.Employees.Count == 0
                              select data;
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<KeyValueOption> ListStaffNames()
        {
            using (var context = new NorthwindContext())
            {
                var result = from data in context.Employees
                             select new KeyValueOption()
                             {
                                 Text = data.FirstName + " " + data.LastName,
                                 Key = data.EmployeeID.ToString()
                             };
                return result.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<StaffProfile> ListStaff()
        {
            using (var context = new NorthwindContext())
            {
                var result = from data in context.Employees
                             select new StaffProfile()
                             {
                                 Name = data.FirstName + " " + data.LastName,
                                 JobTitle = data.Title,
                                 HireDate = data.HireDate,
                                 Photo = data.Photo,
                                 Id = data.EmployeeID,
                                 Territories = from place in data.Territories
                                               orderby place.TerritoryDescription
                                               select new StaffTerritory()
                                               {
                                                   StaffId = data.EmployeeID,
                                                   TerritoryId = place.TerritoryID,
                                                   TerritoryName = place.TerritoryDescription
                                               }
                                               // Yearly Sales/Order count

                             };
                return result.ToList();
            }
        }

        public StaffProfile GetStaffProfile(int employeeId)
        {
            using (var context = new NorthwindContext())
            {
                var result = from data in context.Employees
                             where data.EmployeeID == employeeId
                             select new StaffProfile()
                             {
                                 Name = data.FirstName + " " + data.LastName,
                                 JobTitle = data.Title,
                                 HireDate = data.HireDate,
                                 Photo = data.Photo,
                                 Id = data.EmployeeID,
                                 Territories = from place in data.Territories
                                               orderby place.TerritoryDescription
                                               select new StaffTerritory()
                                               {
                                                   StaffId = data.EmployeeID,
                                                   TerritoryId = place.TerritoryID,
                                                   TerritoryName = place.TerritoryDescription
                                               }
                                               // Yearly Sales/Order count

                             };
                return result.SingleOrDefault();
            }
        }

        // TODO: GetEmployeeRegionalManagementReport
        #endregion
        #endregion

        #region CRUD - Sales Regions/Territories
        #region Regions
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Region> ListAllRegions()
        {
            using (var context = new NorthwindContext())
            {
                return context.Regions.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public void AddRegion(Region data)
        {
            using (var context = new NorthwindContext())
            {
                // The Region Primary Key is not auto-generated by the database
                data.RegionID = context.Regions.Max(x => x.RegionID) + 1;
                context.Regions.Add(data);
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void UpdateRegion(Region data)
        {
            using (var context = new NorthwindContext())
            {
                var existing = context.Entry(data);
                existing.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void DeleteRegion(Region data)
        {
            using (var context = new NorthwindContext())
            {
                var existing = context.Regions.Find(data.RegionID);
                context.Regions.Remove(existing);
                context.SaveChanges();
            }
        }
        #endregion

        #region Territories
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Territory> ListAllTerritories()
        {
            using (var context = new NorthwindContext())
            {
                return context.Territories.Include(x => x.Region).ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public void AddTerritory(Territory data)
        {
            using (var context = new NorthwindContext())
            {
                // The Territory Primary Key is not auto-generated by the database
                data.TerritoryID = data.TerritoryDescription.Trim().Substring(0, 20);
                context.Territories.Add(data);
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void UpdateTerritory(Territory data)
        {
            using (var context = new NorthwindContext())
            {
                var existing = context.Entry(data);
                existing.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void DeleteTerritory(Territory data)
        {
            using (var context = new NorthwindContext())
            {
                var existing = context.Territories.Find(data.TerritoryID);
                context.Territories.Remove(existing);
                context.SaveChanges();
            }
        }
        #endregion
        #endregion
    }
}
