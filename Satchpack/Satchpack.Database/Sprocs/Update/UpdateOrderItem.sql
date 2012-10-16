USE Satchpack
GO

CREATE PROCEDURE [dbo].[UpdateOrderItem]
	@id INT,
	@invoiceId INT,
	@productId INT,
	@quantity INT
AS
BEGIN

	UPDATE dbo.OrderItem
	SET Quantity = @quantity,
		ProductId = @productId
	WHERE Id = @id AND
		  InvoiceId = @invoiceId

END
GO