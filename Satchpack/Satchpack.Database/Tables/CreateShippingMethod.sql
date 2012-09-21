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
	TrackingNumber NVARCHAR(100) NOT NULL
)
GO

-- Changing Column 'TrackingNumber' to 'TrackingUrl'
sp_RENAME 'ShippingMethod.TrackingNumber', 'TrackingUrl', 'COLUMN'
GO