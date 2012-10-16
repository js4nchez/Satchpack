USE Satchpack
GO

CREATE PROCEDURE [dbo].[RetrieveOrderItemById]
	@id INT
AS
BEGIN

	SELECT * FROM dbo.OrderItem
	WHERE Id = @id

END
GO