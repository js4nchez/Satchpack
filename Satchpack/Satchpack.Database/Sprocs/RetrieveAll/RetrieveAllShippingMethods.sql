USE Satchpack
GO

CREATE PROCEDURE [dbo].[RetrieveAllShippingMethods]
AS
BEGIN

	SELECT * FROM dbo.ShippingMethod

END
GO