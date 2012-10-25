USE Satchpack
GO

CREATE PROCEDURE [dbo].[CreateShippingMethod]
	@id INT,
	@carrier NVARCHAR(100),
	@method NVARCHAR(100),
	@trackingUrl NVARCHAR(100),
	@price DECIMAL(18, 2) 
AS
BEGIN

	INSERT INTO dbo.ShippingMethod (Carrier, Method, TrackingUrl, Price)
	VALUES (@carrier, @method, @trackingUrl, @price)

	SELECT SCOPE_IDENTITY();

END
GO