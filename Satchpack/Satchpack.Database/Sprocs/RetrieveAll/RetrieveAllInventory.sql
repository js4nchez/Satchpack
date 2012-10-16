USE Satchpack
GO

CREATE PROCEDURE [dbo].[RetrieveAllInventory]
AS
BEGIN

	SELECT * FROM dbo.Inventory

END
GO