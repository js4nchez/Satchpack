USE Satchpack
GO

DELETE FROM dbo.OrderItem
DELETE FROM dbo.Invoice
DELETE FROM dbo.InvoiceStatus
DELETE FROM dbo.ShippingMethod
DELETE FROM dbo.[User]
DELETE FROM dbo.Inventory
DELETE FROM dbo.Product
DELETE FROM dbo.Customer
GO

DBCC CHECKIDENT ('dbo.OrderItem', RESEED, 0)
DBCC CHECKIDENT ('dbo.Invoice', RESEED, 0)
DBCC CHECKIDENT ('dbo.InvoiceStatus', RESEED, 0)
DBCC CHECKIDENT ('dbo.ShippingMethod', RESEED, 0)
DBCC CHECKIDENT ('dbo.[User]', RESEED, 0)
DBCC CHECKIDENT ('dbo.Inventory', RESEED, 0)
DBCC CHECKIDENT ('dbo.Product', RESEED, 0)
DBCC CHECKIDENT ('dbo.Customer', RESEED, 0)
GO

-- Inserts the base values that the InvoiceStatus table will hold.
EXEC dbo.CreateInvoiceStatus 'Processing', 'Order has been received and the products are being prepared for shipping.'
EXEC dbo.CreateInvoiceStatus 'Shipped', 'Order has been completed and shipped'
EXEC dbo.CreateInvoiceStatus 'On Hold', 'The order has insufficient information to be processed or there is trouble with payment'
EXEC dbo.CreateInvoiceStatus 'Canceled', 'The order has been canceled as requested by customer.'

-- Inserts the base values that the ShippingMethod table will hold.
EXEC dbo.CreateShippingMethod 'USPS', 'First-Class', 'http://webtrack.dhlglobalmail.com/?id=8028&trackingnumber=', 3.99
EXEC dbo.CreateShippingMethod 'USPS', 'First-Class International', 'http://trkcnfrm1.smi.usps.com/PTSInternetWeb/InterLabelInquiry.do?origTrackNum=', 3.99
EXEC dbo.CreateShippingMethod 'FedEx', '2Day', 'http://www.fedex.com/Tracking?tracknumber_list=', 3.99
EXEC dbo.CreateShippingMethod 'FedEx', 'Priority Overnight', 'http://www.fedex.com/Tracking?tracknumber_list=', 3.99

-- Inserts Users
EXEC dbo.CreateUser 'hosa', 'hosa'
EXEC dbo.CreateUser 'Jeworge', 'lame', 0
EXEC dbo.CreateUser 'ArrolingR', 'giant', 1

-- Inserts Products
EXEC dbo.CreateInventory 'RED', 'Satchpack', 'A very durable backpack/satchel.', 1, 90.00, 'Red'
EXEC dbo.CreateInventory 'BLUE', 'Satchpack', 'A very durable backpack/satchel.', 1, 90.00, 'Blue'
EXEC dbo.CreateInventory 'OILGREEN', 'Satchpack', 'A very durable backpack/satchel.', 1, 90.00, 'Oil Green'
EXEC dbo.CreateInventory 'SILVER', 'Satchpack', NULL, 1, 90.99, 'Silver'
EXEC dbo.CreateInventory 'PURPLE', 'Satchpack', 'A very durable backpack/satchel.', 1, 90.99, 'Purple'

-- Inserts Customers
--EXEC dbo.CreateCustomer 'Jorge', 'Sanchez', 'In da Hoodz!', 'Murray', 'UT', '84121', 'USA', 'jsanchez@yahoo.com', '891-793-1111'
--EXEC dbo.CreateCustomer 'Hosa', 'Rodriguez', '1533 E. Santiago Ln. Apt. 12', 'SLC', 'UT', '84121', 'USA', 'jerodriguez@yahoo.com', '353-232-3915'
--EXEC dbo.CreateCustomer 'Ruddy', 'Arroliga', 'Some place in the CH', 'SLC', 'UT', '84121', 'USA', 'rarroligajr@gmail.com', '555-555-5551'

-- Insert Inventory
--EXEC dbo.CreateInventory 1, 100
--EXEC dbo.CreateInventory 2, 10
--EXEC dbo.CreateInventory 3, 20
--EXEC dbo.CreateInventory 4, 30

---- Insert Invoice
--EXEC dbo.CreateInvoice 1, 1, '2012-10-01', 99.10, 1
--EXEC dbo.CreateInvoice 2, 3, '2012-10-01', 20.01, 1
--EXEC dbo.CreateInvoice 3, 2, '2012-10-01', 5.00, 1

---- Insert OrderItem
--EXEC dbo.CreateOrderItem 1, 1, 5
--EXEC dbo.CreateOrderItem 2, 5, 10
GO