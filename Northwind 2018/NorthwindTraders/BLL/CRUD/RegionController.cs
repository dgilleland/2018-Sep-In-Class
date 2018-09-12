﻿using NorthwindTraders.DAL;
using NorthwindTraders.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace NorthwindTraders.BLL.CRUD
{
    [DataObject]
    public class RegionController
    {
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
    }
}