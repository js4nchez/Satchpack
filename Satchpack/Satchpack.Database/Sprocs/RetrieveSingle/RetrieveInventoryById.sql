USE Satchpack
GO

CREATE PROCEDURE [dbo].[RetrieveInventoryById]
	@id INT
AS
BEGIN

	SELECT * FROM dbo.Inventory
	WHERE Id = @id

END
GO