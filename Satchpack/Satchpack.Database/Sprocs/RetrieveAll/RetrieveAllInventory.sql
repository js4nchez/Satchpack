USE Satchpack
GO

CREATE PROCEDURE [dbo].[RetrieveAllInventory]
AS
BEGIN

	SELECT * FROM dbo.Inventory AS I INNER JOIN
			  dbo.Product AS P ON I.ProductId = P.Id

END
GO