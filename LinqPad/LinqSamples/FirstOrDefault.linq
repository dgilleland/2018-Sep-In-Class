<Query Kind="Expression">
  <Connection>
    <ID>2f871659-b227-4d65-a411-ef19b1c695a8</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//Waiters.First()

//Waiters.First(person => person.FirstName.StartsWith("D"))
// |           |                string
// |         A single Waiter
// Collection of "rows"
//(from person in Waiters
//where person.FirstName.StartsWith("D")
//select person).First()

Waiters.Where(person => person.FirstName.StartsWith("D"))
//Waiters.FirstOrDefault(guy => guy.FirstName.StartsWith("W"))