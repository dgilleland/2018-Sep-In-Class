<Query Kind="Expression">
  <Connection>
    <ID>7af7928c-3f71-48ca-b27f-f0859df8db95</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>NorthwindExtended</Database>
  </Connection>
</Query>

// Get the order totals and basic customer information for each order
from row in Orders
select new
// Initialization List - Google this....
{
   Company = row.Customer.CompanyName,
   Contact = row.Customer.ContactName,
   OrderTotal = (from item in row.OrderDetails
                select item.UnitPrice * item.Quantity).Sum()
				//,
//   Items = from item in row.OrderDetails
//           select new
//			{
//				ProductName = item.Product.ProductName,
//				item.UnitPrice,
//				item.Quantity,
//				item.Discount,
//				Total = item.UnitPrice * item.Quantity // todo: apply a discount
//			}
}