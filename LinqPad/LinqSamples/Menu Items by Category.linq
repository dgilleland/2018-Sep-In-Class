<Query Kind="Program">
  <Connection>
    <ID>2f871659-b227-4d65-a411-ef19b1c695a8</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

void Main()
{
	var data = from aCategory in MenuCategories
	           orderby aCategory.Description
	           select new CategoryWithItems()
				{
				   Description = aCategory.Description,
				   MenuItems = from item in aCategory.Items
				              orderby item.Description
				              select new MenuItem()
							  {
							    Description = item.Description,
								Price = item.CurrentPrice,
								Calories = item.Calories,
								Comment = item.Comment
							  }
				};
    data.Dump("Menu Categories + Items");
}

// Define other methods and classes here
public class CategoryWithItems
{
    public string Description { get; set; }
	public IEnumerable MenuItems { get; set; } // TODO: Change from IEnumerable
}

public class MenuItem
{
    public string Description { get; set; }
	public decimal Price { get; set; }
	public int? Calories { get; set; }
	public string Comment { get; set; }
}






