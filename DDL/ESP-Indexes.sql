USE [ESP-A01]
GO

-- Indexes on foreign keys
CREATE NONCLUSTERED INDEX IX_Orders_CustomerNumber
    ON Orders (CustomerNumber)
CREATE NONCLUSTERED INDEX IX_OrderDetails_OrderNumber
    ON OrderDetails (OrderNumber)
CREATE NONCLUSTERED INDEX IX_OrderDetails_ItemNumber
    ON OrderDetails (ItemNumber)

-- Other Indexes
CREATE NONCLUSTERED INDEX IX_Orders_Date
    ON Orders([Date])
