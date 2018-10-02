<Query Kind="Expression">
  <Connection>
    <ID>2f871659-b227-4d65-a411-ef19b1c695a8</ID>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// Group all the menu items by the menu category
from food in Items
group food by food.MenuCategoryID
// The following does the same thing, but places the grouped data into
// another variable called "result"
/*
from food in Items
group food by food.MenuCategoryID into result
select result
*/