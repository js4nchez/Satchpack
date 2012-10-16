USE Satchpack
GO

CREATE PROCEDURE [dbo].[RetrieveAllInvoiceStatus]
AS
BEGIN

	SELECT * FROM dbo.InvoiceStatus

END
GO