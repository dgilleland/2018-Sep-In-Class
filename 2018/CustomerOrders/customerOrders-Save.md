---
title: Saving an Order
---
# Saving Customer Orders

Saving a customer order is done to preserve changes to an order while keeping it open (i.e., not setting the `OrderDate`). The customer order to be saved may be a new order or an existing open order. Both of these are handled by a single public BLL method, which internally shunts the main work of saving to two alternate private methods.

```csharp
public void Save(EditCustomerOrder order)
{
    // Always ensure you have been given data to work with
    if (order == null)
        throw new ArgumentNullException("order", "Cannot save order; order information was not supplied.");

    // Business validation rules
    if (order.OrderDate.HasValue)
        throw new Exception($"An order date of {order.OrderDate.Value.ToLongDateString()} has been supplied. The order date should only be supplied when placing orders, not saving them.");

    // Decide whether to add new or update
    //  NOTE: Notice that no db activity is occuring yet.
    if (order.OrderId == 0)
        AddPendingOrder(order);
    else
        UpdatePendingOrder(order);
}
```

The `Save()` method performs initial validation, ensuring that the order exists and that the order date is not set. In either case, the order is open (or "pending"), and the work of saving changes ir routed to two separate methods, each of which ensure that the order is **processed as a *single* transaction**.

```csharp
private void AddPendingOrder(EditCustomerOrder order)
{
    using (var context = new NorthwindContext())
    {
        var orderInProcess = context.Orders.Add(new Order());
        // Make the orderInProcess match the customer order as given...
        // A) The general order information
        orderInProcess.CustomerID = order.CustomerId;
        orderInProcess.EmployeeID = order.EmployeeId;
        orderInProcess.OrderDate = order.OrderDate;
        orderInProcess.ShipVia = order.ShipperId;
        orderInProcess.Freight = order.FreightCharge;
        // B) Add order details
        foreach (var item in order.OrderItems)
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

        // C) Save the changes (one save, one transaction)
        context.SaveChanges();
    }
}
```

```csharp
private void UpdatePendingOrder(EditCustomerOrder order)
{
    using (var context = new NorthwindContext())
    {
        var orderInProcess = context.Orders.Find(order.OrderId);
        // Make the orderInProcess match the customer order as given...
        // A) The general order information
        orderInProcess.CustomerID = order.CustomerId;
        orderInProcess.EmployeeID = order.EmployeeId;
        orderInProcess.OrderDate = order.OrderDate;
        orderInProcess.ShipVia = order.ShipperId;
        orderInProcess.Freight = order.FreightCharge;

        // B) Add/Update/Delete order details
        //    Loop through the items as known in the database (to update/remove)
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
        //    Loop through the new items to add to the database
        foreach (var item in order.OrderItems)
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

        // C) Save the changes (one save, one transaction)
        context.Entry(orderInProcess).State = EntityState.Modified;
        context.SaveChanges();
    }
}
```
