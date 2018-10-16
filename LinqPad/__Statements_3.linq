<Query Kind="Statements">
  <Connection>
    <ID>950e92a1-69a5-4196-87e5-6a1c87c3f8d0</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// Get the following from the Orders table for a specific month:
// OrderDate, ID, count of distinct items, total sale
// for items that have been shipped
// Then display the total income for the month and the average line items.
DateTime searchPeriod = new DateTime(1998,1,1);
var billsForMonth = from item in Orders
					where item.ShippedDate.HasValue
					&& item.OrderDate.Value.Month == searchPeriod.Month
					&& item.OrderDate.Value.Year == searchPeriod.Year
					orderby item.OrderDate descending
					select new
					{
						OrderDate = item.OrderDate,
						OrderId = item.OrderID,
						DistinctItems = item.OrderDetails.Count,
						TotalSale = item.OrderDetails
						            .Sum(od => od.Quantity * od.UnitPrice)
					};

var title = string.Format("Total income for {0} {1}", searchPeriod.ToString("MMMM"), searchPeriod.Year);
billsForMonth.Sum(bill => bill.TotalSale).ToString("C").Dump(title, true);
billsForMonth.Average(bill => bill.DistinctItems).Dump("Average Line Items", true);








