USE Satchpack
GO

CREATE PROCEDURE [dbo].[CreateInvoice]
	@firstName NVARCHAR(30),
	@lastName NVARCHAR(30),
	@address1 NVARCHAR(200),
	@address2 NVARCHAR(200) = '',
	@city NVARCHAR(30),
	@state NVARCHAR(30),
	@postalCode NVARCHAR(30),
	@country NVARCHAR(30),
	@email NVARCHAR(200),
	@phone NVARCHAR(30) = '',

	@shippingMethodId INT,
	@orderDate DATETIME,
	@invoiceTotal DECIMAL(18, 2),
	@invoiceStatusId INT
AS
BEGIN

	INSERT INTO dbo.Customer (FirstName, LastName, Address1, Address2, City,
							  State, PostalCode, Country, Email, Phone)
	VALUES (@firstName, @lastName, @address1, @address2, @city,
			@state, @postalCode, @country, @email, @phone)
	DECLARE @customerId INT = SCOPE_IDENTITY()


	INSERT INTO dbo.Invoice (CustomerId, ShippingMethodId, OrderDate,
							 InvoiceTotal, InvoiceStatusId)
	VALUES (@customerId, @shippingMethodId, @orderDate,
			@invoiceTotal, @invoiceStatusId)

	SELECT SCOPE_IDENTITY();

END
GO