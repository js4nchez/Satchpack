USE Satchpack
GO

CREATE PROCEDURE [dbo].[UpdateInventory]
	@id INT,
	@productId INT,
	@quantity INT
AS
BEGIN

	UPDATE dbo.Inventory
	SET Quantity = @quantity
	WHERE Id = @id AND
		  ProductId = @productId

END
GO