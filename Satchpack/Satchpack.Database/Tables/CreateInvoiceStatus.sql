USE Satchpack
GO

-- Creates the InvoiceStatus table if it doesn't exist.
IF NOT EXISTS (SELECT 1
		   FROM INFORMATION_SCHEMA.TABLES
		   WHERE TABLE_NAME = 'InvoiceStatus')
CREATE TABLE InvoiceStatus (
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(30) NOT NULL,
	Description NVARCHAR(MAX) NOT NULL
)
GO

-- Inserts the base values that the InvoiceStatus table will hold.
INSERT INTO dbo.InvoiceStatus
VALUES('Processing', 'Order has been received and the products are being prepared for shipping.'),
	  ('Shipped', 'Order has been completed and shipped'),
	  ('On Hold', 'The order has insufficient information to be processed or there is trouble with payment'),
	  ('Canceled', 'The order has been canceled as requested by customer.')