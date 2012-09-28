USE master
GO

IF NOT EXISTS (SELECT name 
			   FROM master.dbo.sysdatabases 
			   WHERE name = N'Satchpack')
CREATE DATABASE Satchpack
GO

-- Invoice Aggregate
--    - Invoice
--    - Customer
--    - InvoiceStatus
--    - ShippingMethod


-- Admin Aggregate
--    - User


-- Product Aggregate
--    - Product
--    - Inventory