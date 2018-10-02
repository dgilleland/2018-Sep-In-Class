<Query Kind="Statements">
  <Connection>
    <ID>e5af68a8-d464-4274-880d-fcab824d01aa</ID>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// TODO: 5) Most Popular products sold (qty), by year and month

// Step 1) Get the Product and total quantity sold, grouped by year and month
var ProductQuantitiesByYearAndMonth =
    from soldItem in OrderDetails
	group soldItem by new 
					  {
						soldItem.Order.OrderDate.Value.Year,
						soldItem.Order.OrderDate.Value.Month
					  }
		into groupedOrderDetails
	orderby groupedOrderDetails.Key.Year, groupedOrderDetails.Key.Month
	select new
		   {
				Year = groupedOrderDetails.Key.Year,
				Month = groupedOrderDetails.Key.Month,
				Items = from orderDetailItem in groupedOrderDetails
				        group orderDetailItem
							by orderDetailItem.Product.ProductName
							into productDetail
						orderby productDetail.Sum(item => item.Quantity) descending
						select new
						{
							Product = productDetail.Key,
							QtySold = productDetail.Sum(item => item.Quantity)
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
					   MostPopular = from product in item.Items
					                 // Compare each product's quantity for the month against
									 // the collection's max quantity for the month
					                 where product.QtySold == item.Items.Max(x=>x.QtySold)
									 select product
				   };
finalResults.Dump("Most Popular products sold (qty), by year and month");				   
