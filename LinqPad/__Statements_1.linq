<Query Kind="Statements">
  <Connection>
    <ID>950e92a1-69a5-4196-87e5-6a1c87c3f8d0</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

/* Example 1: Querying data from Northwind */
var result = from row in Products
             where row.UnitPrice > 50
			 select row;

// The following line won't work in your VS project....
result.Dump();

// Find the Orders that are due to be shipped
var toShip = from due in Orders
		     where !due.ShippedDate.HasValue
			 orderby due.RequiredDate
			 select new // declaring an "anonymous type" on-the-fly
			 {		    // using an intializer list to set the properties
			    Id = due.OrderID,
			 	RequiredOn = due.RequiredDate,
				Shipper = due.ShipViaShipper.CompanyName
			 };
toShip.Count().Dump(); // show the count of items
toShip.Take(5).Dump(); // show the first 5 items











