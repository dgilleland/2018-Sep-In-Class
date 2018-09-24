<Query Kind="Expression">
  <Connection>
    <ID>b259f03f-eca9-4227-8758-27a4159af87d</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// List the first and last name of all the employees who look after 7 or more territories
// as well as the names of all the territories they are responsible for
from person in Employees
where person.EmployeeTerritories.Count >= 7
select new
{
   First = person.FirstName,
   Last = person.LastName,
   Territories = from place in person.EmployeeTerritories
                 select place.Territory.TerritoryDescription
}