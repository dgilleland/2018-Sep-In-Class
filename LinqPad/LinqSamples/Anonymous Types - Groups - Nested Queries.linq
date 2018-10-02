<Query Kind="Expression">
  <Connection>
    <ID>2f871659-b227-4d65-a411-ef19b1c695a8</ID>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// We can use nested LINQ queries to get very expressive results
// with straight-forward and readable queries
from cat in MenuCategories
where cat.Description == "Appetizer" || cat.Description == "Entree"
orderby cat.Description
select new
{
  Description = cat.Description,
  MenuItems = from item in cat.Items
              where item.Active
              orderby item.Description
              select new
              {
                Description = item.Description,
                Price = item.CurrentPrice,
                Calories = item.Calories,
                Comment = item.Comment
              }
}