<Query Kind="Expression">
  <Connection>
    <ID>7af7928c-3f71-48ca-b27f-f0859df8db95</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>NorthwindExtended</Database>
  </Connection>
</Query>

// List all the Region and Territory names in a "flat" list
from data in Territories
// Here's how I would sort the results
orderby data.Region.RegionDescription, data.TerritoryDescription
select new
{
    Region = data.Region.RegionDescription,
	Territory = data.TerritoryDescription
}