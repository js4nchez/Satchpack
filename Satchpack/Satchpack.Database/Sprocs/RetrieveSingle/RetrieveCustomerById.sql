USE Satchpack
GO

CREATE PROCEDURE [dbo].[RetrieveCustomerById]
	@id INT
AS
BEGIN

	SELECT * FROM dbo.Customer
	WHERE Id = @id

END
GO