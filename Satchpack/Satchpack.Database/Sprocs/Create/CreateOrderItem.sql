USE Satchpack
GO

CREATE PROCEDURE [dbo].[CreateOrderItem]
	@id INT,
	@invoiceId INT,
	@productId INT,
	@quantity INT
AS
BEGIN

	INSERT INTO dbo.OrderItem (InvoiceId, ProductId, Quantity)
	VALUES (@invoiceId, @productId, @quantity)

	SELECT SCOPE_IDENTITY();

END
GO