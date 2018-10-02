<Query Kind="Expression">
  <Connection>
    <ID>e5af68a8-d464-4274-880d-fcab824d01aa</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// TODO: 7) Sales, ordered by date, including the order date, the time allowed to ship (in days), the actual time to ship (in days), and the customer name/city.
from sale in Orders
orderby sale.OrderDate
select new
{
	Customer = sale.Customer.CompanyName,
	City = sale.Customer.City,
	OrderDate = sale.OrderDate,
	TimeToShip = sale.RequiredDate.HasValue && sale.OrderDate.HasValue
	           ? (sale.RequiredDate.Value - sale.OrderDate.Value).TotalDays
			   : (double?) null,
	ActualShiptime = sale.ShippedDate.HasValue && sale.OrderDate.HasValue
	               ? (sale.ShippedDate.Value - sale.OrderDate.Value).TotalDays
			       : (double?) null
}