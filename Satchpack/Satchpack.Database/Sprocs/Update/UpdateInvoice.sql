USE Satchpack
GO

CREATE PROCEDURE [dbo].[UpdateInvoice]
	@id INT,
	@customerId INT,
	@shippingMethodId INT,
	@orderDate DATETIME,
	@invoiceTotal DECIMAL(18, 2),
	@invoiceStatusId INT
AS
BEGIN

	UPDATE dbo.Invoice
	SET ShippingMethodId = @shippingMethodId,
		OrderDate = @orderDate,
		InvoiceTotal = @invoiceTotal,
		InvoiceStatusId = @invoiceStatusId
	WHERE Id = @id AND
		  CustomerId = @customerId

END
GO