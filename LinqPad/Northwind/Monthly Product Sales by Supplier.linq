<Query Kind="Expression">
  <Connection>
    <ID>c3c442ec-7d55-4319-843f-d9fffadc6a63</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// Monthly Product Sales by Supplier
from data in OrderDetails
group data by new {data.Product.Supplier, data.Order.OrderDate.Value.Month, data.Order.OrderDate.Value.Year}
  into gdata
orderby gdata.Key.Year, gdata.Key.Month  
select new
{
    Supplier = new { Name = gdata.Key.Supplier.CompanyName, ID = gdata.Key.Supplier.SupplierID },
    OrderPeriod = new { Year = gdata.Key.Year, Month = gdata.Key.Month },
    OrderItems = from item in gdata
                 group item by item.Product into gitem
                 select new
                 {
                     ProductID = gitem.Key.ProductID,
                     ProductName = gitem.Key.ProductName,
                     UnitPrice = gitem.Average(i => i.UnitPrice),
                     UnitPriceMax = gitem.Max(i => i.UnitPrice),
                     Quantity = gitem.Sum(i => i.Quantity)
                 }
}