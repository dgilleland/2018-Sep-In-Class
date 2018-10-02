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
    public class CategoryController
    {
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<Category> ListAllCategories()
        {
            using (var context = new NorthwindContext())
            {
                return context.Categories.ToList();
            }
        }
    }
}
