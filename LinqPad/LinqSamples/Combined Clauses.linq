<Query Kind="Expression">
  <Connection>
    <ID>2f871659-b227-4d65-a411-ef19b1c695a8</ID>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// Get the menu items for Entrees and sort them by price highest to lowest
from food in Items
where food.MenuCategory.Description == "Entree"
orderby food.CurrentPrice descending
select food

// Get the menu items for Entrees & Beverages (grouped separately)
// and sort them by price highest to lowest
from food in Items
where food.MenuCategory.Description == "Entree" 
   || food.MenuCategory.Description == "Beverage"
orderby food.CurrentPrice descending
group food by food.MenuCategory.Description into result
select result
