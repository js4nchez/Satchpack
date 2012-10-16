USE Satchpack
GO

CREATE PROCEDURE [dbo].[RetrieveInvoiceById]
	@id INT
AS
BEGIN

	SELECT * FROM dbo.Invoice
	WHERE Id = @id

END
GO