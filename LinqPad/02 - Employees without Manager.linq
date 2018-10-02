<Query Kind="Expression">
  <Connection>
    <ID>e5af68a8-d464-4274-880d-fcab824d01aa</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

/* Northwind 2018 - Demo
   - List all the employees who do not have a manager
     (i.e.: they do not report to anyone).
*/
from person in Employees
//   thing      thing[] 
where person.ReportsTo == null
//   thing     thing 
select new
{
  Name = person.FirstName + " " + person.LastName
}