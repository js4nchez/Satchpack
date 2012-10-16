USE Satchpack
GO

CREATE PROCEDURE [dbo].[DeleteShippingMethod]
	@id INT
AS
BEGIN

	DELETE FROM dbo.ShippingMethod
	WHERE Id = @id

END
GO