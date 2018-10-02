using NorthwindTraders.DAL;
using NorthwindTraders.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace NorthwindTraders.BLL.CRUD
{
    [DataObject]
    public class ProductController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Product> ListAllProducts()
        {
            using (var context = new NorthwindContext())
            {
                return context.Products
                              .Include(nameof(Product.Category))
                              .Include(nameof(Product.Supplier))
                              .ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Product> GetProductsByPartialProductName(string partialName)
        {
            using (var context = new NorthwindContext())
            {
                var result = from item in context.Products
                             where item.ProductName.Contains(partialName)
                             select item;
                // The .Include() method below needs the
                // using System.Data.Entity;
                return result.Include(nameof(Product.Category))
                             .Include(nameof(Product.Supplier))
                             .ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void AddProduct(Product item)
        {
            using (var context = new NorthwindContext())
            {
                context.Products.Add(item);
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void UpdateProduct(Product item)
        {
            using (var context = new NorthwindContext())
            {
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void DeleteProduct(Product item)
        {
            DeleteProduct(item.ProductID); // chaining overloaded method
        }

        public void DeleteProduct(int productId)
        {
            using (var context = new NorthwindContext())
            {
                context.Products.Remove(context.Products.Find(productId));
                context.SaveChanges();
            }
        }
    }
}
