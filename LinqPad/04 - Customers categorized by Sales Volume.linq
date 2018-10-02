<Query Kind="Expression">
  <Connection>
    <ID>e5af68a8-d464-4274-880d-fcab824d01aa</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

/* Northwind 2018 - Demo
   - List all the customers and categorize them by the volume of sales to those customers.
     Sales Volume  |  Category
	   ------------- | ---------
	                 | Low
			  	         | Moderate
				           | High
				   
*/
from data in Customers
select new
{
	CompanyName = data.CompanyName,
	Sales = (from purchase in data.Orders
	         from lineItem in purchase.OrderDetails
			 select lineItem.UnitPrice * lineItem.Quantity
			      - lineItem.UnitPrice * lineItem.Quantity * (decimal)lineItem.Discount)
}
