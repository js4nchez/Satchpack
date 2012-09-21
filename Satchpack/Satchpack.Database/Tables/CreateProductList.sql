USE Satchpack
GO

-- Creates the ProductList table if it doesn't exist.
IF NOT EXISTS (SELECT 1
		   FROM INFORMATION_SCHEMA.TABLES
		   WHERE TABLE_NAME = 'ProductList')
CREATE TABLE ProductList (
	ProductId INT NOT NULL REFERENCES Product(Id),
	InvoiceId INT NOT NULL REFERENCES Invoice(Id)
)
GO