USE Satchpack
GO

-- Creates the Product table if it doesn't exist.
IF NOT EXISTS (SELECT 1
		   FROM INFORMATION_SCHEMA.TABLES
		   WHERE TABLE_NAME = 'Product')
CREATE TABLE Product (
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	SKU NVARCHAR(30) NOT NULL UNIQUE,
	Name NVARCHAR(30) NOT NULL,
	Description NVARCHAR(200) NULL,
	Weight DECIMAL(18, 2) NOT NULL,
	Price DECIMAL(18, 2) NOT NULL
)
GO

-- Adds the 'Color' column if it doesn't exist.
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
		   WHERE TABLE_NAME = 'Product' AND
				 COLUMN_NAME = 'Color')
ALTER TABLE Product
ADD Color NVARCHAR(30) NULL
GO