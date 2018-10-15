---
title: Command Responsibility
---
# Command Responsibility

Editing the order is done by adding and removing order items as well as selecting the shipper, setting the freight, and entering the date that the order is required. None of these editing actions perform an update on the database directly. Rather, the changes are simply preserved on the form itself through the form's code-behind.

> ![Form State](./images/Form-State-Edit-Order.png)

Once all the editing is done, the user can either **Save** or **Place** the order. Both of these actions are performed as distinct transactions, meaning that all the relevant data from the form is sent to the BLL through a DTO.

> ![Save Order](./images/Command-Save-Order.png)

```csharp
public class EditOrderItem
{
    public int ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public short OrderQuantity { get; set; }
    public float DiscountPercent { get; set; }
}
```

```csharp
public class EditCustomerOrder
{
    public int OrderId { get; set; }
    public string CustomerId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? RequiredDate { get; set; }
    public int? ShipperId { get; set; }
    public decimal? FreightCharge { get; set; }
    public IEnumerable<EditOrderItem> OrderItems { get; set; }
}
```
