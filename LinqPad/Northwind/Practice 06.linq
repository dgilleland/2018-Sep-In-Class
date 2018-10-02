<Query Kind="Expression">
  <Connection>
    <ID>7af7928c-3f71-48ca-b27f-f0859df8db95</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>NorthwindExtended</Database>
  </Connection>
</Query>

// List all the Region and Territory names as an "object graph" - use a nested query
from data in Regions
orderby data.RegionDescription descending
select new
{
	Region = data.RegionDescription,
	Territories = from row in data.Territories
	              orderby row.TerritoryDescription
	              select row.TerritoryDescription
}