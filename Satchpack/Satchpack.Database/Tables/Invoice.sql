USE Satchpack
GO

-- Creates the Invoice table if it doesn't exist.
IF NOT EXISTS (SELECT 1
		   FROM INFORMATION_SCHEMA.TABLES
		   WHERE TABLE_NAME = 'Invoice')
CREATE TABLE Invoice (
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	CustomerId INT NOT NULL REFERENCES Customer(Id),
	ShippingMethodId INT NOT NULL REFERENCES ShippingMethod(Id),
	OrderDate DATETIME NOT NULL,
	InvoiceTotal DECIMAL NOT NULL
)
GO

-- Adds the 'InvoiceStatus' column if it doesn't exist.
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
		   WHERE TABLE_NAME = 'Invoice' AND
				 COLUMN_NAME = 'InvoiceStatusId')
ALTER TABLE Invoice
ADD InvoiceStatusId INT NULL REFERENCES InvoiceStatus(Id)
GO