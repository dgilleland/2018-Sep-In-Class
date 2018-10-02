using NorthwindTraders.DAL;
using NorthwindTraders.Entities.DTOs;
using NorthwindTraders.Entities.POCOs;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace NorthwindTraders.BLL
{
    [DataObject]
    public class ProductCatalogueController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ProductCategory> AllProductsByCategory()
        {
            using (var context = new NorthwindContext())
            {
                // Produce a list of all the Products by Category for Northwind Traders
                var result = from cat in context.Categories // the query starts with the Database Entity
                             orderby cat.CategoryName
                             select new ProductCategory
                             {
                                 Name = cat.CategoryName,
                                 Description = cat.Description,
                                 Picture = cat.Picture,
                                 Products = from item in cat.Products // build subquery off of the cat item
                                            orderby item.ProductName
                                            where item.Discontinued == false
                                            select new ProductInfo
                                            {
                                                ID = item.ProductID,
                                                Name = item.ProductName,
                                                QuantityPerUnit = item.QuantityPerUnit,
                                                Price = item.UnitPrice,
                                                InStock = item.UnitsInStock
                                            }
                             };
                return result.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<InventoryStatus> GetInventoryStatus()
        {
            using (var context = new NorthwindContext())
            {
                var results = from data in context.Products
                              where !data.Discontinued
                              select new InventoryStatus
                              {
                                  Supplier = data.Supplier.CompanyName,
                                  Category = data.Category.CategoryName,
                                  Product = data.ProductName,
                                  UnitPrice = data.UnitPrice,
                                  InStockQuantity = data.UnitsInStock,
                                  QuantityPerUnit = data.QuantityPerUnit,
                                  OnOrderQuantity = data.UnitsOnOrder,
                                  ReorderLevel = data.ReorderLevel
                              };
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<KeyValueOption> ListSuppliers()
        {
            using (var context = new NorthwindContext())
            {
                var result =
                    context
                    .Suppliers
                    .Select(x => 
                            new KeyValueOption
                            {
                                Key = x.SupplierID.ToString(),
                                Text = x.CompanyName
                            });
                return result.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<InventoryStatus> GetInventoryStatusBySupplier(int supplierId)
        {
            const int ALL_SUPPLIERS = 0;
            using (var context = new NorthwindContext())
            {
                var results = from data in context.Products
                              where !data.Discontinued
                              && (supplierId == ALL_SUPPLIERS
                                  || (data.SupplierID.HasValue && data.SupplierID.Value == supplierId)
                                 )
                              select new InventoryStatus
                              {
                                  Supplier = data.Supplier.CompanyName,
                                  Category = data.Category.CategoryName,
                                  Product = data.ProductName,
                                  UnitPrice = data.UnitPrice,
                                  InStockQuantity = data.UnitsInStock,
                                  QuantityPerUnit = data.QuantityPerUnit,
                                  OnOrderQuantity = data.UnitsOnOrder,
                                  ReorderLevel = data.ReorderLevel
                              };
                return results.ToList();
            }
        }
    }
}
