<Query Kind="Expression">
  <Connection>
    <ID>a7b38f44-278c-490b-9f25-1e0c71246a63</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

//  Customer Order Histories, grouped by Customer
from row in Orders
group row by row.Customer.CompanyName into customerOrders
select new
{
    Company = customerOrders.Key,
    Orders = from data in customerOrders
             orderby data.OrderDate
             select new
             {
                OrderDate = data.OrderDate,
                FreightCharge = data.Freight,
                TotalCost = (from item in data.OrderDetails
                            select item.Quantity * item.UnitPrice).Sum(),
                OrderItems = (from item in data.OrderDetails
                            select new // OrderDetailSummary()
                            {
                                Product = item.Product.ProductName,
                                Quantity = item.Quantity,
                                UnitPrice = item.UnitPrice,
                                Unit = item.Product.QuantityPerUnit
                            }).ToList()
              }
}