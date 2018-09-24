<Query Kind="Expression">
  <Connection>
    <ID>e5af68a8-d464-4274-880d-fcab824d01aa</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

from data in Products
where !data.Discontinued
select new // InventoryStatus // POCO class
{
    data.Supplier.CompanyName,
    data.Category.CategoryName,
    data.ProductName,
    data.UnitPrice,
    data.UnitsInStock,
    data.QuantityPerUnit,
    data.UnitsOnOrder,
    data.ReorderLevel
}