---
title: Placing an Order
---
# Placing Customer Orders

Placing customer orders is much like saving, except that the order date must be set.

```csharp
public void PlaceOrder(EditCustomerOrder order)
{
    // Always ensure you have been given data to work with
    if (order == null)
        throw new ArgumentNullException("order", "Cannot place order; order information was not supplied.");

    // Business validation rules
    if (!order.RequiredDate.HasValue)
        throw new Exception($"A  required date for the order is required when placing orders.");
    if (!order.OrderDate.HasValue)
        throw new Exception($"An order date is required when placing orders.");
    if (!order.ShipperId.HasValue)
        throw new Exception("A shipper must be identified before placing an order.");
    if (order.OrderItems.Count() == 0)
        throw new Exception("An order must have at least one item before it can be placed.");

    // Begin processing the order
    using (var context = new NorthwindContext())
    {
        // Prep for processing...
        var customer = context.Customers.Find(order.CustomerId);
        if (customer == null)
            throw new Exception("Customer does not exist");
        var orderInProcess = context.Orders.Find(order.OrderId);
        if (orderInProcess == null)
            orderInProcess = context.Orders.Add(new Order());
        else
            context.Entry(orderInProcess).State = EntityState.Modified;
        // Make the orderInProcess match the customer order as given...
        // A) The general order information
        orderInProcess.CustomerID = order.CustomerId;
        orderInProcess.EmployeeID = order.EmployeeId;
        orderInProcess.OrderDate = order.OrderDate;
        orderInProcess.RequiredDate = order.RequiredDate;
        orderInProcess.ShipVia = order.ShipperId;
        orderInProcess.Freight = order.FreightCharge;
        // B) Default the ship-to info to the customer's info
        orderInProcess.ShipName = customer.CompanyName;
        orderInProcess.ShipAddress = customer.Address;
        orderInProcess.ShipCity = customer.City;
        orderInProcess.ShipRegion = customer.Region;
        orderInProcess.ShipPostalCode = customer.PostalCode;

        // C) Add/Remove/Update order details
        //var toRemove = new List<OrderDetail>();
        foreach (var detail in orderInProcess.OrderDetails)
        {
            var changes = order.OrderItems.SingleOrDefault(x => x.ProductId == detail.ProductID);
            if (changes == null)
                //toRemove.Add(detail);
                context.Entry(detail).State = EntityState.Deleted; // flag for deletion
            else
            {
                detail.Discount = changes.DiscountPercent;
                detail.Quantity = changes.OrderQuantity;
                detail.UnitPrice = changes.UnitPrice;
                context.Entry(detail).State = EntityState.Modified;
            }
        }
        foreach (var item in order.OrderItems)
        {
            if (!orderInProcess.OrderDetails.Any(x => x.ProductID == item.ProductId))
            {
                // Add as a new item
                var newItem = new OrderDetail
                {
                    ProductID = item.ProductId,
                    Quantity = item.OrderQuantity,
                    UnitPrice = item.UnitPrice,
                    Discount = item.DiscountPercent
                };
                orderInProcess.OrderDetails.Add(newItem);
            }
        }

        // D) Save the changes (one save, one transaction)
        context.SaveChanges();
    }
}
```
