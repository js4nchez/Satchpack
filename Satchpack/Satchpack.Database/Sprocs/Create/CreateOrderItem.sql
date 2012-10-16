USE Satchpack
GO

CREATE PROCEDURE [dbo].[CreateOrderItem]
	@invoiceId INT,
	@productId INT,
	@quantity INT
AS
BEGIN

	INSERT INTO dbo.OrderItem (InvoiceId, ProductId, Quantity)
	VALUES (@invoiceId, @productId, @quantity)

END
GO