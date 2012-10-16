USE Satchpack
GO

CREATE PROCEDURE [dbo].[DeleteInventory]
	@id INT
AS
BEGIN

	DELETE FROM dbo.Inventory
	WHERE Id = @id

END
GO