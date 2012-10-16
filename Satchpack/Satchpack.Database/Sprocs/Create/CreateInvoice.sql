USE Satchpack
GO

CREATE PROCEDURE [dbo].[CreateInvoice]
	@customerId INT,
	@shippingMethodId INT,
	@orderDate DATETIME,
	@invoiceTotal DECIMAL(18, 2),
	@invoiceStatusId INT
AS
BEGIN

	INSERT INTO dbo.Invoice (CustomerId, ShippingMethodId, OrderDate,
							 InvoiceTotal, InvoiceStatusId)
	VALUES (@customerId, @shippingMethodId, @orderDate,
			@invoiceTotal, @invoiceStatusId)

END
GO