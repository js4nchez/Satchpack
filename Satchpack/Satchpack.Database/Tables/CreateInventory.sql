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

-- Deletes the 'Color' column if it exists.
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
		   WHERE TABLE_NAME = 'Inventory' AND
				 COLUMN_NAME = 'Color')
ALTER TABLE Inventory DROP COLUMN Color
GO