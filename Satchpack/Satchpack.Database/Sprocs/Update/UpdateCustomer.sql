USE Satchpack
GO

CREATE PROCEDURE [dbo].[UpdateCustomer]
	@id INT,
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

	UPDATE dbo.Customer
	SET FirstName = @firstName,
		LastName = @lastName,
		Address1 = @address1,
		Address2 = @address2,
		City = @city,
		State = @state,
		PostalCode = @postalCode,
		Country = @country,
		Email = @email,
		Phone = @phone
	WHERE Id = @id

END
GO