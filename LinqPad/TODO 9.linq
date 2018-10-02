<Query Kind="Statements">
  <Connection>
    <ID>e5af68a8-d464-4274-880d-fcab824d01aa</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// TODO: 9) Top 5 customers (by total sales amount)
var customerSales =	from customer in Customers
					where customer.Orders.Count > 0 // see what error occurs when you comment out this line
					select new
					{
						Company = customer.CompanyName,
						Sales = customer.Orders
						                .Sum(order => order.OrderDetails
										                   .Sum(detail => detail.UnitPrice * detail.Quantity))
					};
var topFive = customerSales.OrderByDescending(cs => cs.Sales).Take(5);
topFive.Dump("Top 5 customers (by total sales amount)");