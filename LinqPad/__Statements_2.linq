<Query Kind="Statements">
  <Connection>
    <ID>950e92a1-69a5-4196-87e5-6a1c87c3f8d0</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

var employeeCities = (from person in Employees
				      select person.City).Distinct();
employeeCities.Dump();
var customerCities = from buyer in Customers
                     select buyer.City;
customerCities.Distinct().Dump();
customerCities.Count().Dump("# of customer cities");
customerCities.Distinct().Count().Dump("# of distinct customer cities");
var combined = employeeCities.Union(customerCities.Distinct()); // the cities
combined.Count().Dump("# of cities");
combined.Distinct().Count().Dump("# distinct cities");

var shared = employeeCities.Intersect(customerCities);
shared.Dump("Cities that employees and customers have in common");

var uniqueToEmployees = employeeCities.Except(customerCities);
uniqueToEmployees.Dump("Cities with employees but no customers");