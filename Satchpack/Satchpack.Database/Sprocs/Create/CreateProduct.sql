USE Satchpack
GO

CREATE PROCEDURE [dbo].[CreateProduct]
	@sku NVARCHAR(30),
	@name NVARCHAR(30),
	@description NVARCHAR(200) = '',
	@weight DECIMAL(18, 2),
	@price DECIMAL(18, 2),
	@color NVARCHAR(30)
AS
BEGIN

	INSERT INTO dbo.Product (SKU, Name, Description, Weight, Price, Color)
	VALUES (@sku, @name, @description, @weight, @price, @color)

END
GO