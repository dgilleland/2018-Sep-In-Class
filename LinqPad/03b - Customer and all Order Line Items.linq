<Query Kind="Expression">
  <Connection>
    <ID>b259f03f-eca9-4227-8758-27a4159af87d</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

/* Northwind 2018 - Demo
   - List all the customers and the name, qty & unit price of each of the items they purchased.
*/
from data in Customers
select new
{
    CompanyName = data.CompanyName,
	Sales = from purchase in data.Orders
	        from lineItem in purchase.OrderDetails
			select new
			{
				Name = lineItem.Product.ProductName,
				Qty = lineItem.Quantity,
				UnitPrice = lineItem.UnitPrice
			}
}
