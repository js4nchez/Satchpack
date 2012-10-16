USE Satchpack
GO

CREATE PROCEDURE [dbo].[DeleteCustomer]
	@id INT
AS
BEGIN

	DELETE FROM dbo.Customer
	WHERE Id = @id

END
GO