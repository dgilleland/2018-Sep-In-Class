<Query Kind="Expression">
  <Connection>
    <ID>7af7928c-3f71-48ca-b27f-f0859df8db95</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>NorthwindExtended</Database>
  </Connection>
</Query>

// Get the total amount from all orders groupped by customer
from row in Orders
group row by new 
             {
			     row.Customer.CompanyName,
				 row.Customer.ContactName
			 }
			 into customerOrders
//orderby row.Customer.CompanyName
select new
{
   Company = customerOrders.Key.CompanyName,
   Contact = customerOrders.Key.ContactName,
   OrderTotal = (from order in customerOrders
                 from item in order.OrderDetails
                 select item.UnitPrice * item.Quantity).Sum()
}