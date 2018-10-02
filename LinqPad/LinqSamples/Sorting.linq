<Query Kind="Expression">
  <Connection>
    <ID>2f871659-b227-4d65-a411-ef19b1c695a8</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

from food in Items
//orderby food.Description descending
orderby food.CurrentPrice descending, food.Calories ascending
select food