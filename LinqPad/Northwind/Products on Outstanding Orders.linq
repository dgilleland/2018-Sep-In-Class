<Query Kind="Expression">
  <Connection>
    <ID>6bdde39a-d74e-44f7-a899-485cbd501676</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

from od in OrderDetails
where !od.Order.ShippedDate.HasValue
group od by od.Product into grp
select new
{
   Product = grp.Key.ProductName,
   QOH = grp.Key.UnitsInStock,
   QOO = grp.Key.UnitsOnOrder,
   QuantityToFill = grp.Sum(x=>x.Quantity)
}