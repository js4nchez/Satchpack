USE Satchpack
GO

-- Creates the Inventory table if it doesn't exist.
IF NOT EXISTS (SELECT 1
		   FROM INFORMATION_SCHEMA.TABLES
		   WHERE TABLE_NAME = 'Inventory')
CREATE TABLE Inventory (
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ProductId INT NOT NULL REFERENCES Product(Id),
	Color NVARCHAR(30) NOT NULL,
	Quantity SMALLINT NOT NULL
)
GO

-- Get rid of color