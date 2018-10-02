<Query Kind="Expression">
  <Connection>
    <ID>b259f03f-eca9-4227-8758-27a4159af87d</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// List employees who have an "an" in their first name
from person in Employees
where person.FirstName.Contains("an")
select person