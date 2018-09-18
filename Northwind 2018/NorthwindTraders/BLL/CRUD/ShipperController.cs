using NorthwindTraders.DAL;
using NorthwindTraders.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace NorthwindTraders.BLL.CRUD
{
    [DataObject]
    public class ShipperController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Shipper> ListAllShippers()
        {
            using (var context = new NorthwindContext())
            {
                return context.Shippers.Include(nameof(Shipper.Orders)).ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void AddShipper(Shipper info)
        {
            using (var context = new NorthwindContext())
            {
                context.Shippers.Add(info);
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void UpdateShipper(Shipper info)
        {
            using (var context = new NorthwindContext())
            {
                // .Entry(obj) - Associate the info passed in with the db
                DbEntityEntry<Shipper> existing = context.Entry(info);
                // Tell EF that we are modifying the entire stored state with our info
                existing.State = System.Data.Entity.EntityState.Modified;
                // The SaveChanges will take this modified state and execute an update
                // on the db
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void RemoveShipper(Shipper info)
        {
            using (var context = new NorthwindContext())
            {
                var existing = context.Shippers.Find(info.ShipperID);
                context.Shippers.Remove(existing);
                context.SaveChanges();
            }
        }
    }
}