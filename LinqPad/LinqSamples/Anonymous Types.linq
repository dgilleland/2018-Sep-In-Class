<Query Kind="Expression">
  <Connection>
    <ID>2f871659-b227-4d65-a411-ef19b1c695a8</ID>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// Picking and choosing what data to extract by using Anonymous Types
from food in Items
where food.MenuCategory.Description == "Entree" && food.Active
orderby food.CurrentPrice descending
select new // This is saying I want a new Anonymous type
{   // These are the properties/values in the Anonymous type
    Description = food.Description,
    Price = food.CurrentPrice,
    Calories = food.Calories
}