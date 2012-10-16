USE Satchpack
GO

CREATE PROCEDURE [dbo].[RetrieveShippingMethodById]
	@id INT
AS
BEGIN

	SELECT * FROM dbo.ShippingMethod
	WHERE Id = @id

END
GO