USE Satchpack
GO

CREATE PROCEDURE [dbo].[CreateInvoiceStatus]
	@id INT,
	@name NVARCHAR(30),
	@description NVARCHAR(MAX)
AS
BEGIN

	INSERT INTO dbo.InvoiceStatus (Name, Description)
	VALUES (@name, @description)

	SELECT SCOPE_IDENTITY();

END
GO