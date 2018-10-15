---
title: Sales Page
---
# Open the Sales Page

The first visit to the Sales page simply displays a list of existing customers the the employee can select from to view the customer's order history or to create a new order for the customer.

> ![Sales Page - First Visit](./images/First-Visit.png)

For the drop-down, only the Company Name and Customer Id are required on the form, so a simple POCO class geared to the needs of a drop-down is needed.

> ![Sales Page - Data Query for First Visit](./images/Query-First-Visit.png)

```csharp
public class KeyValueOption
{
    public string Key { get; set; }
    public string Text { get; set; }
}
```

Clicking on the [Select] button will trigger the next major view of this page: the Selected Customer.
