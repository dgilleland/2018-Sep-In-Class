<Query Kind="Expression">
  <Connection>
    <ID>e5af68a8-d464-4274-880d-fcab824d01aa</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// TODO: 6) Sales Regions and their Sales Representatives
from region in Regions
select new
{
	Name = region.RegionDescription,
	SalesReps = from territory in region.Territories // "from each territory in region.Territories"
	            from reps in territory.EmployeeTerritories
				group reps by reps.Employee into person
				select new
				{
					Name = person.Key.FirstName + " " + person.Key.LastName,
					Photo = person.Key.Photo.ToImage()
				}
}