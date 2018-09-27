<Query Kind="Expression">
  <Connection>
    <ID>d622f89f-d3b6-49d8-968e-11e2333aa3f9</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//The Kitchen Staff needs the following information:
// Items to prepare for orders that have been placed 
// but are not ready, grouped by the table number(s) 
// and menu category description. Omit beverage items 
// as the kitchen staff do not handle these items.

from foodItem in BillItems
where foodItem.Bill.OrderPlaced.HasValue
   && foodItem.Bill.OrderReady.HasValue == false
   && foodItem.Item.MenuCategory.Description != "Beverage"
   //&& foodItem.Bill.Reservation == null
group foodItem by new {foodItem.Bill.TableID,
                       foodItem.Item.MenuCategory.Description}
into orderedItems
select new
{
	Table = orderedItems.Key.TableID,
	Type = orderedItems.Key.Description,
	Preps = from food in orderedItems
            select new
			{
				Description = food.Item.Description,
				Quantity = food.Quantity,
				Notes = food.Notes
			}
}