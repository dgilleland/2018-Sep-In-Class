<Query Kind="Expression">
  <Connection>
    <ID>0a4eef58-58a6-4938-bb05-b1d81a27bdfc</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// TODO: 2) Employee Bio
from person in Employees
//foreach(var person in Employees)
select new
{
    FullName = person.FirstName + " " + person.LastName,
	JobTitle = person.Title,
	CompanyPhoneExtension = person.Extension,
	Photo = person.Photo.ToImage(),
	MimeType = person.PhotoMimeType,
	Supervisor = person.ReportsToEmployee.FirstName + " "
	           + person.ReportsToEmployee.LastName, // TODO: Change for Visual Studio
	Bio = person.Notes
}
