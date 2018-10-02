<Query Kind="Expression">
  <Connection>
    <ID>950e92a1-69a5-4196-87e5-6a1c87c3f8d0</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

/* Northwind 2018 - Demo
   - List all the customers and the name, qty & unit price
     of each of the items they purchased.
*/
from data in Customers
//  Customer   Customer[]
select new
{
    CompanyName = data.CompanyName,
	Sales = from purchase in data.Orders
//                Order             Order[]
	        from lineItem in purchase.OrderDetails
//               OrderDetail              OrderDetail[]
			select new
			{
				Name = lineItem.Product.ProductName,
				Qty = lineItem.Quantity,
				UnitPrice = lineItem.UnitPrice
			}
}








