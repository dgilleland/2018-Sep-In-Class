<Query Kind="Statements">
  <Connection>
    <ID>d2680611-0859-4122-802a-895fe15d73e6</ID>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPath>.\bin\Debug\NorthwindTraders.dll</CustomAssemblyPath>
    <CustomTypeName>NorthwindTraders.DAL.NorthwindContext</CustomTypeName>
    <AppConfigPath>.\App.config</AppConfigPath>
    <CustomAssemblyPathEncoded>.\bin\Debug\NorthwindTraders.dll</CustomAssemblyPathEncoded>
  </Connection>
</Query>

Categories.Dump();
Products.Dump();
Suppliers.Dump();
Employees.Dump();
Territories.Dump();
Regions.Dump();
Customers.Dump();
Orders.Take(5).Dump();
OrderDetails.Take(5).Dump();
Shippers.Dump();