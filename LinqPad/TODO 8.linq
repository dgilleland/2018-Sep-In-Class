<Query Kind="Expression">
  <Connection>
    <ID>e5af68a8-d464-4274-880d-fcab824d01aa</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// TODO: 8) Market Area information: A union query listing all the cities of suppliers and customers, with two columns, one for the city name and the other for whether it is a customer or supplier.
(
from vendor in Suppliers
select new
{
	City = vendor.City,
	Type = "Supplier"
}
).Union(
from customer in Customers
select new
{
	City = customer.City,
	Type = "Customer"
}
)
.OrderBy(info => info.City)