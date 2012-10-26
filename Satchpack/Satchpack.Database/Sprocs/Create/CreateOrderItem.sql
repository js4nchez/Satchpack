USE Satchpack
GO

CREATE PROCEDURE [dbo].[CreateOrderItem]
	@invoiceId INT,
	@productId INT,
	@quantity INT,
	@id INT = 0
AS
BEGIN

	INSERT INTO dbo.OrderItem (InvoiceId, ProductId, Quantity)
	VALUES (@invoiceId, @productId, @quantity)

	SELECT SCOPE_IDENTITY();

END
GO