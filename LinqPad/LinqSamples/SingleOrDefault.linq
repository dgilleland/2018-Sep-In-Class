<Query Kind="Expression">
  <Connection>
    <ID>2f871659-b227-4d65-a411-ef19b1c695a8</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// List ALL the waiters whose first name starts with "S"
//Waiters.Where(person => person.FirstName.StartsWith("S"))

//Waiters.Single(person => person.FirstName.StartsWith("S"))

Waiters.SingleOrDefault(person => person.FirstName.StartsWith("W"))