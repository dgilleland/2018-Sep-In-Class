<Query Kind="Expression">
  <Connection>
    <ID>7af7928c-3f71-48ca-b27f-f0859df8db95</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>NorthwindExtended</Database>
  </Connection>
</Query>

// Group employees by region and show the results in this format:
/* ----------------------------------------------
 * | REGION        | EMPLOYEES                  |
 * ----------------------------------------------
 * | Eastern       | ------------------------   |
 * |               | | Nancy Devalio        |   |
 * |               | | Fred Flintstone      |   |
 * |               | | Bill Murray          |   |
 * |               | ------------------------   |
 * |---------------|----------------------------|
 * | ...           |                            |
 * 
 */
from data in EmployeeTerritories
group data by data.Territory.Region.RegionDescription into regionGrp
select new
{
	Region = regionGrp.Key,
	Employees = from person in regionGrp
	            select person.Employee.FirstName + " " + person.Employee.LastName
				// foreach(var person in regionGrp)
				// {
				//     get the name from person object
				// }
}













