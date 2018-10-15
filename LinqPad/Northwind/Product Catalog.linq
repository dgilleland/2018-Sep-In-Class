<Query Kind="Program">
  <Connection>
    <ID>b29b701a-579b-47a9-8e8d-5622e6798669</ID>
    <Persist>true</Persist>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPathEncoded>&lt;MyDocuments&gt;\GitHub\2017-Sep-In-Class\Northwind Demo\Northwind.Data\bin\Debug\Northwind.Data.dll</CustomAssemblyPathEncoded>
    <CustomAssemblyPath>C:\Users\dgilleland\Documents\GitHub\2017-Sep-In-Class\Northwind Demo\Northwind.Data\bin\Debug\Northwind.Data.dll</CustomAssemblyPath>
    <CustomTypeName>Northwind.Data.NorthwindContext</CustomTypeName>
    <AppConfigPath>C:\Users\dgilleland\Documents\GitHub\2017-Sep-In-Class\Northwind Demo\Northwind.Data\App.config</AppConfigPath>
  </Connection>
</Query>

void Main()
{
	// Produce a list of all the Products by Category for Northwind Traders
	var result = from cat in Categories // the query starts with the Database Entity
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
	result.Dump();
}

// Define other methods and classes here
public class ProductCategory
{
    public string Name { get; set; }
	public string Description { get; set; }
	public byte[] Picture { get; set; }
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









