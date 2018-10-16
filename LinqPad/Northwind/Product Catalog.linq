<Query Kind="Program">
  <Connection>
    <ID>fc9eedc1-4c1d-4bb2-abbb-805e5c8f954f</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

void Main()
{
	// Produce a list of all the Products by Category for Northwind Traders
	var result = from cat in Categories // the query starts with the Database Entity
	             orderby cat.CategoryName
				 select new // Start with an anonymous type, then move to using a class: ProductCategory
				{
				  Name = cat.CategoryName,
				  Description = cat.Description,
				  Picture = cat.Picture,
				  Products = from item in cat.Products // build subquery off of the cat item
				             orderby item.ProductName
							 where item.Discontinued == false
							 select new // Start with an anonymous type, then use a class: ProductInfo
							{
							  ID = item.ProductID,
							  Name = item.ProductName,
							  QuantityPerUnit = item.QuantityPerUnit,
							  Price = item.UnitPrice,
							  InStock = item.UnitsInStock
							}
				};
	result.Dump();
}

// Define other methods and classes here
public class ProductCategory
{
    public string Name { get; set; }
	public string Description { get; set; }
	public object Picture { get; set; }
	public IEnumerable<ProductInfo> Products { get; set; }
}

public class ProductInfo
{
	public int ID { get; set; }
	public string Name { get; set; }
	public string QuantityPerUnit { get; set; }
	public decimal? Price { get; set; }
	public short? InStock { get; set; }
}