USE Satchpack
GO

-- Creates the Customer table if it doesn't exist.
IF NOT EXISTS (SELECT 1
		   FROM INFORMATION_SCHEMA.TABLES
		   WHERE TABLE_NAME = 'OrderItem')
CREATE TABLE OrderItem (
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	InvoiceId INT NOT NULL REFERENCES Invoice(Id),
	ProductId INT NOT NULL REFERENCES Product(Id),
	Quantity INT NOT NULL
)
GO