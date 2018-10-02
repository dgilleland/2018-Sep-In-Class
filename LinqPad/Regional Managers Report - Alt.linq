<Query Kind="Expression">
  <Connection>
    <ID>c3c442ec-7d55-4319-843f-d9fffadc6a63</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

from emp in Employees
from data in emp.EmployeeTerritories
orderby data.Territory.Region.RegionDescription, data.Employee.LastName, data.Territory.TerritoryDescription
select new // RegionalManager
{
    data.Territory.Region.RegionDescription,
    data.Territory.TerritoryDescription,
    data.Territory.TerritoryID,
    emp.FirstName,
    emp.LastName,
    emp.City,
    emp.Region
}