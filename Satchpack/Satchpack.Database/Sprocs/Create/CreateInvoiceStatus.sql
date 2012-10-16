USE Satchpack
GO

CREATE PROCEDURE [dbo].[CreateInvoiceStatus]
	@name NVARCHAR(30),
	@description NVARCHAR(MAX)
AS
BEGIN

	INSERT INTO dbo.InvoiceStatus (Name, Description)
	VALUES (@name, @description)

END
GO