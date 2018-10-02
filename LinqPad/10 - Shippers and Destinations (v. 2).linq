<Query Kind="Expression">
  <Connection>
    <ID>a7b38f44-278c-490b-9f25-1e0c71246a63</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// Shippers, and the countries they ship to
from row in Shippers
select new
{
    Shipper = row.CompanyName,
    Countries = from order in row.ShipViaOrders
                orderby order.ShipCountry
                group order by order.ShipCountry into countries
                select countries.Key
}