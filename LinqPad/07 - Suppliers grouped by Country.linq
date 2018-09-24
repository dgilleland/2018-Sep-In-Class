<Query Kind="Expression">
  <Connection>
    <ID>a7b38f44-278c-490b-9f25-1e0c71246a63</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// Suppliers, by country
from row in Suppliers
group row by row.Country into vendors
select new
{
   Country = vendors.Key,
   Companies = from vendor in vendors
               select vendor.CompanyName
}