USE Satchpack
GO

CREATE PROCEDURE [dbo].[CreateInvoiceStatus]
	@name NVARCHAR(30),
	@description NVARCHAR(MAX),
	@id INT = 0
AS
BEGIN

	INSERT INTO dbo.InvoiceStatus (Name, Description)
	VALUES (@name, @description)

	SELECT SCOPE_IDENTITY();

END
GO