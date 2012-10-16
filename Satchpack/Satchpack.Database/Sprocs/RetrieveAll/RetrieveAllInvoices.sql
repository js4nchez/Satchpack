USE Satchpack
GO

CREATE PROCEDURE [dbo].[RetrieveAllInvoices]
AS
BEGIN

	SELECT * FROM dbo.Invoice

END
GO