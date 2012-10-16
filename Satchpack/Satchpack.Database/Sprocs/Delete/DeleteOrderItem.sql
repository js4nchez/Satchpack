USE Satchpack
GO

CREATE PROCEDURE [dbo].[DeleteOrderItem]
	@id INT
AS
BEGIN

	DELETE FROM dbo.OrderItem
	WHERE Id = @id

END
GO