<Query Kind="Program">
  <Connection>
    <ID>950e92a1-69a5-4196-87e5-6a1c87c3f8d0</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

void Main()
{
	var data = from cat in Categories
			   orderby cat.CategoryName
			   select new Category
			   {
			   	   Name = cat.CategoryName,
				   Items = from item in cat.Products
				           where !item.Discontinued
						   orderby item.ProductName
						   select new InventoryItem
						   {
						   	   Product = item.ProductName,
							   Price = item.UnitPrice.Value,
							   QtyPerUnit = item.QuantityPerUnit,
							   InStock = item.UnitsInStock
						   }
			   };
    data.Dump();
}

// Define other methods and classes here
public class Category // A DTO - Data Transfer Object
{
    public string Name { get; set; }
	public IEnumerable<InventoryItem> Items { get; set; }
}
public class InventoryItem // A POCO - Plain Old CLR Object
{
    public string Product { get; set;}
	public decimal Price { get; set; }
	public int? InStock { get; set; }
	public string QtyPerUnit { get; set; }
}














