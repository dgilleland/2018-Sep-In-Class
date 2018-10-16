<Query Kind="Statements">
  <Connection>
    <ID>950e92a1-69a5-4196-87e5-6a1c87c3f8d0</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// TODO: 5) Most Popular products sold (qty), by year and month

// Step 1) Get the Product and total quantity sold, grouped by year and month
var ProductQuantitiesByYearAndMonth =
    from soldItem in OrderDetails
    group soldItem by new // The following anonymous object will be the KEY for my groups
                      {
                          soldItem.Order.OrderDate.Value.Year,
                          soldItem.Order.OrderDate.Value.Month
                      }
    into groupedOrderDetails
    orderby groupedOrderDetails.Key.Year, groupedOrderDetails.Key.Month
    select new //groupedOrderDetails;
    {
        Year = groupedOrderDetails.Key.Year,
        Month = groupedOrderDetails.Key.Month,
        Items = // groupedOrderDetails
                from orderDetailItem in groupedOrderDetails
                orderby orderDetailItem.Product.ProductName
                group orderDetailItem by orderDetailItem.Product.ProductName into productDetail
                // the following sorting on my group's details gives me the most popular
                orderby productDetail.Sum(item => item.Quantity) descending
                select new //productDetail //orderDetailItem
                {
                    Product = productDetail.Key,
                    QtySold = productDetail.Sum(item => item.Quantity)
                    // productDetail is a collection of OrderDetails
                    // The QtySold is the Sum of each OrderDetail item
                    // "such that" I am summing the item.Quantity
                }
    };
// see the output
ProductQuantitiesByYearAndMonth.Dump("Intermediate results");

// Step 2) From these, get the products with the greatest quantity sold
var finalResults = from item in ProductQuantitiesByYearAndMonth
                   select new
                   {
                       Year = item.Year,
                       Month = item.Month,
                       MostPopular = (from product in item.Items
                                     // compare each product's quantity for the month against
                                     // the collection's max quantity for the month
                                     where product.QtySold == item.Items.Max(x => x.QtySold)
                                     select product).First()
                   };
finalResults.Dump("Most Popular products sold (qty), by year and month");
























