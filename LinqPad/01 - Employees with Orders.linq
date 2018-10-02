<Query Kind="Expression">
  <Connection>
    <ID>e5af68a8-d464-4274-880d-fcab824d01aa</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

/* Northwind 2018 - Demo
   - List all the employees who have been involved in processing customer orders.
*/
from person in Employees
where person.Orders.Count > 0
select new
{
  Name = person.FirstName + " " + person.LastName
}