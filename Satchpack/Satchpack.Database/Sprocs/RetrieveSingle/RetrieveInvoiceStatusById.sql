USE Satchpack
GO

CREATE PROCEDURE [dbo].[RetrieveInvoiceStatusById]
	@id INT
AS
BEGIN

	SELECT * FROM dbo.InvoiceStatus
	WHERE Id = @id

END
GO