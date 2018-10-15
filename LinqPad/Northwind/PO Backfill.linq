<Query Kind="Program">
  <Connection>
    <ID>0a4eef58-58a6-4938-bb05-b1d81a27bdfc</ID>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

void Main()
{
	var inventoryChanges = from od in OrderDetails
	                       where od.Order.ShippedDate.HasValue
	                       orderby od.Order.ShippedDate descending
						   select new
						{
							ProductID = od.ProductID,
							Quantity = od.Quantity,
							UnitPrice = od.UnitPrice,
							ShippedDate = od.Order.ShippedDate,
							OrderDate = od.Order.OrderDate,
							RequiredDate = od.Order.RequiredDate							
						};
//	inventoryChanges.Dump();
	var p = new Dictionary<int,List<ProductOrderHistory>>();
	foreach(var item in Products)
	{
	   var ob = new ProductOrderHistory {
		ProductID = item.ProductID,
        OrderOn = DateTime.Today,
		FilledBy = DateTime.Today,
		SupplierID = item.SupplierID.Value,
		InStock = item.UnitsInStock.Value,
		ReorderLevel = item.ReorderLevel.Value
	   };
	   var lst = new List<ProductOrderHistory>();
	   lst.Add(ob);
	   p.Add(item.ProductID,lst);
	}
	foreach(var item in inventoryChanges)
	{
	   var dictP = p[item.ProductID];
	   var last = dictP.Last();
	   var next = new ProductOrderHistory {
		ProductID = item.ProductID,
        OrderOn = item.OrderDate.Value,
		FilledBy = item.ShippedDate.Value,
		SupplierID = last.SupplierID,
		InStock = last.InStock - item.Quantity,
		Diff = item.Quantity,
		ReorderLevel = last.ReorderLevel
	   };
	   dictP.Add(next);
	}
	p.Dump();
    var avg = from data in p
              select new
              {
                 ID = data.Key,
                 Avg = Math.Ceiling(data.Value.Skip(1).ToList().Average(x=>x.Diff)),
                 Reorder = data.Value.First().ReorderLevel
              };
    avg.Dump();
}

// Define other methods and classes here
class ProductOrderHistory
{
	public int ProductID {get;set;}
    public DateTime OrderOn {get;set;}
	public DateTime FilledBy {get;set;}
	public int SupplierID {get;set;}
	public int InStock {get;set;}
	public int Diff {get;set;}
	public int ReorderLevel{get;set;}
	
}