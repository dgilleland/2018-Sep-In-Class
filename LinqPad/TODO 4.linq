<Query Kind="Expression">
  <Connection>
    <ID>e5af68a8-d464-4274-880d-fcab824d01aa</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// TODO: 4) Suppliers and their Products (with category photo and category name)
from vendor in Suppliers
select new
{
	SupplierName = vendor.CompanyName, // somewhat similar to getting the "key" of a group
	AveragePrice = vendor.Products.Average(item => item.UnitPrice),
	Products = from item in vendor.Products
	           select new
				{
				    ProductName  = item.ProductName,
					CategoryName = item.Category.CategoryName,
					Photo        = item.Category.Picture         .ToImage()
				}
}