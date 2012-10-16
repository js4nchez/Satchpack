USE Satchpack
GO

CREATE PROCEDURE [dbo].[DeleteInvoice]
	@id INT
AS
BEGIN

	DELETE FROM dbo.Invoice
	WHERE Id = @id

END
GO