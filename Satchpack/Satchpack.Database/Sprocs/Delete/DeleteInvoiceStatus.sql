USE Satchpack
GO

CREATE PROCEDURE [dbo].[DeleteInvoiceStatus]
	@id INT
AS
BEGIN

	DELETE FROM dbo.InvoiceStatus
	WHERE Id = @id

END
GO