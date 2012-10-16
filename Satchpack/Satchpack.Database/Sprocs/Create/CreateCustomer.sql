USE Satchpack
GO

CREATE PROCEDURE [dbo].[CreateCustomer]
	@firstName NVARCHAR(30),
	@lastName NVARCHAR(30),
	@address1 NVARCHAR(200),
	@address2 NVARCHAR(200) = '',
	@city NVARCHAR(30),
	@state NVARCHAR(30),
	@postalCode NVARCHAR(30),
	@country NVARCHAR(30),
	@email NVARCHAR(200),
	@phone NVARCHAR(30) = ''
AS
BEGIN

	INSERT INTO dbo.Customer (FirstName, LastName, Address1, Address2, City,
							  State, PostalCode, Country, Email, Phone)
	VALUES (@firstName, @lastName, @address1, @address2, @city,
			@state, @postalCode, @country, @email, @phone)

END
GO