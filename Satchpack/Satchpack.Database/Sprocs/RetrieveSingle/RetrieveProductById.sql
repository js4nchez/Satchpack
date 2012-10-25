USE Satchpack
GO

CREATE PROCEDURE [dbo].[RetrieveProductById]
	@productId INT,
	@sku NVARCHAR(30) = '',
	@name NVARCHAR(30) = '',
	@description NVARCHAR(200) = '',
	@weight DECIMAL(18, 2) = 0,
	@price DECIMAL(18, 2) = 0,
	@color NVARCHAR(30) = ''
AS
BEGIN

	SELECT * FROM dbo.Product
	WHERE Id = @productId

END
GO