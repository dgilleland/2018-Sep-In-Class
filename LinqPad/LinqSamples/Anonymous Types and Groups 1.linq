<Query Kind="Expression">
  <Connection>
    <ID>2f871659-b227-4d65-a411-ef19b1c695a8</ID>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// Generate a Object Graph of menu items by category where the inner-data
// is in a List<T>
from food in Items
where food.MenuCategory.Description == "Entree" 
   || food.MenuCategory.Description == "Beverage"
orderby food.CurrentPrice descending
group food by food.MenuCategory into foodGroup
select new
{
    Category = foodGroup.Key.Description,
    MenuItems = foodGroup.ToList()
}