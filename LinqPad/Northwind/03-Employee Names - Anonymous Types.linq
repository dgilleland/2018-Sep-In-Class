<Query Kind="Expression">
  <Connection>
    <ID>4dc8b401-4542-4b0d-b435-b01d9117ac30</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>NorthwindExtended</Database>
  </Connection>
</Query>

from person in Employees
where person.EmployeeTerritories.Count >= 4
select new //Person
{
    ID = person.EmployeeID,
	FormalName = person.LastName + ", " + person.FirstName
}