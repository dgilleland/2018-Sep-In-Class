<Query Kind="Expression">
  <Connection>
    <ID>a7b38f44-278c-490b-9f25-1e0c71246a63</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// Employees, by Manager
from person in Employees
group person by person.ReportsToEmployee
    into managedEmployees
select new
{
    Manager = managedEmployees.Key.FirstName + " " + managedEmployees.Key.LastName,
    Photo = managedEmployees.Key.Photo.ToImage(),
    Employees = from employee in managedEmployees
                select new
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Photo = employee.Photo.ToImage()
                }
}
