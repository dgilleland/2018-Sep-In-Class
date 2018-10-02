<Query Kind="Expression">
  <Connection>
    <ID>c3c442ec-7d55-4319-843f-d9fffadc6a63</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

from data in EmployeeTerritories
orderby data.Territory.Region.RegionDescription, data.Employee.LastName, data.Territory.TerritoryDescription
select new // RegionalManager
{
    data.Territory.Region.RegionDescription,
    data.Territory.TerritoryDescription,
    data.Territory.TerritoryID,
    data.Employee.FirstName,
    data.Employee.LastName,
    data.Employee.City,
    data.Employee.Region
}