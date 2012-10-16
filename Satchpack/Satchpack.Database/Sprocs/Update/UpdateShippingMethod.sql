USE Satchpack
GO

CREATE PROCEDURE [dbo].[UpdateShippingMethod]
	@id INT,
	@carrier NVARCHAR(100),
	@method NVARCHAR(100),
	@trackingUrl NVARCHAR(100),
	@price DECIMAL(18, 2)
AS
BEGIN

	UPDATE dbo.ShippingMethod
	SET Carrier = @carrier,
		Method = @method,
		TrackingUrl = @trackingUrl,
		Price = @price
	WHERE Id = @id

END
GO