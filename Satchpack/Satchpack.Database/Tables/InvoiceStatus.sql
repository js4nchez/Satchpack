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