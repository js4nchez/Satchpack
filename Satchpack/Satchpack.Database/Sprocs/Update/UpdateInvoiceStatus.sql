USE Satchpack
GO

CREATE PROCEDURE [dbo].[UpdateInvoiceStatus]
	@id INT,
	@name NVARCHAR(30),
	@description NVARCHAR(MAX)
AS
BEGIN

	UPDATE dbo.InvoiceStatus
	SET Name = @name,
		Description = @description
	WHERE Id = @id

END
GO