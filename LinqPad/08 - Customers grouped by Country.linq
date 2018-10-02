<Query Kind="Expression">
  <Connection>
    <ID>a7b38f44-278c-490b-9f25-1e0c71246a63</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// Customers grouped by Country
from row in Customers
group row by row.Country into customers
orderby customers.Count() descending
select new
{
    Country = customers.Key,
    Customer = from customer in customers
               select new
               {
                   Company = customer.CompanyName,
                   City = customer.City,
                   Region = customer.Region
               }
}
