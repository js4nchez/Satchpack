USE Satchpack
GO

CREATE PROCEDURE [dbo].[CreateInventory]
	@productId INT,
	@quantity INT
AS
BEGIN

	INSERT INTO dbo.Inventory (ProductId, Quantity)
	VALUES (@productId, @quantity)

END
GO