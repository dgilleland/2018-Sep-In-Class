<Query Kind="Statements">
  <Connection>
    <ID>b29b701a-579b-47a9-8e8d-5622e6798669</ID>
    <Persist>true</Persist>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPathEncoded>&lt;MyDocuments&gt;\GitHub\2017-Sep-In-Class\Northwind Demo\Northwind.Data\bin\Debug\Northwind.Data.dll</CustomAssemblyPathEncoded>
    <CustomAssemblyPath>C:\Users\dgilleland\Documents\GitHub\2017-Sep-In-Class\Northwind Demo\Northwind.Data\bin\Debug\Northwind.Data.dll</CustomAssemblyPath>
    <CustomTypeName>Northwind.Data.NorthwindContext</CustomTypeName>
    <AppConfigPath>C:\Users\dgilleland\Documents\GitHub\2017-Sep-In-Class\Northwind Demo\Northwind.Data\App.config</AppConfigPath>
  </Connection>
</Query>

// Get the following from the Orders/OrderDetails for the last month of business data
// OrderDate, OrderID, # Items, Subtotal of all items, Total with freight
// Display this information along with the total income for the month and the number of orders processed.
var maxDate = Orders.Max(row => row.OrderDate);
maxDate.Value.Month.Dump();
var lastMonthOrders = from data in Orders
                      where data.OrderDate.Value.Month == maxDate.Value.Month
					     && data.OrderDate.Value.Year == maxDate.Value.Year
                      orderby data.OrderDate
					  select new
					  {
					     OrderDate = data.OrderDate,
						 OrderID = data.OrderID,
						 NumberOfItems = data.OrderDetails.Count(),
						 ItemSubtotals = (from item in data.OrderDetails
						                 select item.UnitPrice * item.Quantity).Sum(),
						 FreightCost = data.Freight,
						 Total = data.Freight + (from item in data.OrderDetails
						                         select item.UnitPrice * item.Quantity).Sum()
					  };
lastMonthOrders.Dump();
var totalIncome = lastMonthOrders.Sum(x => x.Total);
var count = lastMonthOrders.Count();
totalIncome.Dump("Total Income");
count.Dump("# of Orders Processed");
/*
Orders.Take(5) // get the first 5 Orders
Orders.Count()
from data in Orders
orderby data.OrderDate descending // newest to oldest
select new 
{
  OrderDate = data.OrderDate
}
*/