using NorthwindTraders.DAL;
using NorthwindTraders.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTraders.BLL.CRUD
{
    [DataObject]
    public class SupplierController
    {
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<Supplier> ListAllSuppliers()
        {
            using (var context = new NorthwindContext())
            {
                return context.Suppliers.ToList();
            }
        }
    }
}
