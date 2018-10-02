<Query Kind="Expression">
  <Connection>
    <ID>e5af68a8-d464-4274-880d-fcab824d01aa</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// Most Method Syntax statements for LINQ
// take a "lambda expression" as its parameter
// I often translate the => into the phrase "such that"
Products.Where(aProduct => aProduct.UnitPrice.HasValue && aProduct.UnitPrice.Value > 50.00M)
//             \ param /   \  expression/value that is returned from your ad-hoc method   /
// The parameter for the .Where extension method is of the following data type:
// 				Func<TSource, bool>

/*
Products.Select(aProduct => new { aProduct.ProductName })
*/