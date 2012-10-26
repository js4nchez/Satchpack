USE Satchpack
GO

CREATE PROCEDURE [dbo].[CreateInventory]
	@sku NVARCHAR(30),
	@name NVARCHAR(30),
	@description NVARCHAR(200) = '',
	@weight DECIMAL(18, 2),
	@price DECIMAL(18, 2),
	@color NVARCHAR(30),

	@quantity INT = 1,
	@inventoryId INT = 0,
	@productId INT = 0
AS
BEGIN

	INSERT INTO dbo.Product (SKU, Name, Description, Weight, Price, Color)
	VALUES (@sku, @name, @description, @weight, @price, @color)

	DECLARE @newProductId INT = SCOPE_IDENTITY()

	INSERT INTO dbo.Inventory (ProductId, Quantity)
	VALUES (@newProductId, @quantity)

	SELECT SCOPE_IDENTITY();

END
GO