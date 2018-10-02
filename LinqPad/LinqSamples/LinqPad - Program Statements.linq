<Query Kind="Statements">
  <Connection>
    <ID>2f871659-b227-4d65-a411-ef19b1c695a8</ID>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// Now we are writing C# as a set of program statements
// like it might appear inside a method

/* Example A: Query a simple array of strings */
string[] names = {"Dan", "Don", "Sam", "Dwayne", "Laurel", "Steve", "Nathan"};
names.Dump(); // This will NOT work in Visual Studio!
var shortList = from person in names
                where person.StartsWith("D")
                select person;
shortList.Dump();

/* Example B: Querying data from eRestaurant */
var result = from row in Tables
             where row.Capacity > 3 // Tables with more than three seats
             select row;
result.Dump("List of tables that can seat more than three people");

/* Example C: Simple Data Types */
int age = 32;
age.Dump("Here is the value of the age variable");

(5 + 12 / 9.2).Dump();


