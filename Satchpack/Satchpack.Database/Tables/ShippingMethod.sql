USE Satchpack
GO

-- Creates the ShippingMethod table if it doesn't exist.
IF NOT EXISTS (SELECT 1
		   FROM INFORMATION_SCHEMA.TABLES
		   WHERE TABLE_NAME = 'ShippingMethod')
CREATE TABLE ShippingMethod (
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Carrier NVARCHAR(100) NOT NULL,
	Method NVARCHAR(100) NOT NULL,
	TrackingUrl NVARCHAR(100) NOT NULL
)
GO

-- Adds the 'Price' column if it doesn't exist.
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
		   WHERE TABLE_NAME = 'ShippingMethod' AND
				 COLUMN_NAME = 'Price')
ALTER TABLE ShippingMethod
ADD Price DECIMAL(18, 2) NULL
GO