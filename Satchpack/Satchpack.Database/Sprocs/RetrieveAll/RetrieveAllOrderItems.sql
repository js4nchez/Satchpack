USE Satchpack
GO

CREATE PROCEDURE [dbo].[RetrieveAllOrderItems]
AS
BEGIN

	SELECT * FROM dbo.OrderItem

END
GO