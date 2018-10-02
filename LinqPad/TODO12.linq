<Query Kind="Expression">
  <Connection>
    <ID>e5af68a8-d464-4274-880d-fcab824d01aa</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// TODO 12) Select orders that have not been shipped.
//          Display the Company Name, ID, Order Date, Required Date,
//          Destination City, and Freight Company.
//          Sort the results by required date.
//          Provide two answers, one with Method Syntax and the other with query syntax
from order in Orders.ToList() // .ToList() will pull all the orders from Db into local memory
where !order.ShippedDate.HasValue
orderby order.RequiredDate
select new
{
  Company = order.Customer.CompanyName,
  OrderDate = order.OrderDate.Value.ToString("MMM d, yyyy"),
  RequiredDate = order.RequiredDate.Value.ToString("MMM d, yyyy (ddd)"),
  Destination = order.ShipCity,
  FreightCompany = order.ShipViaShipper.CompanyName
}

/*
Orders.Where(order => !order.ShippedDate.HasValue)
      .OrderBy (order => order.RequiredDate)
      .ToList()  // What happens if you comment out this line?
      .Select(order => new
        {
            Company = order.Customer.CompanyName,
            OrderDate = order.OrderDate.Value.ToString("MMM d, yyyy"),
            RequiredDate = order.RequiredDate.Value.ToString("MMM d, yyyy (ddd)"),
            Destination = order.ShipCity,
            FreightCompany = order.ShipViaShipper.CompanyName
        })
*/