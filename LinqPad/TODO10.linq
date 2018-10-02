<Query Kind="Statements">
  <Connection>
    <ID>e5af68a8-d464-4274-880d-fcab824d01aa</ID>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// TODO: 10) Top selling products (by total sales quantity)
var productSales = from item in Products
                   select new
				   {
				   		Name = item.ProductName,
						Sales = item
						       .OrderDetails
							   .Sum(detail => detail.UnitPrice * detail.Quantity)
				   };
var topTen = productSales
            .OrderByDescending(sale => sale.Sales)
			.Take(10);
topTen.Dump("Top selling products (by total sales quantity)");