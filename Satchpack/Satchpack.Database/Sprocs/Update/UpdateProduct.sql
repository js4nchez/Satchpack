USE Satchpack
GO

CREATE PROCEDURE [dbo].[UpdateProduct]
	@id INT,
	@sku NVARCHAR(30),
	@name NVARCHAR(30),
	@description NVARCHAR(200) = '',
	@weight DECIMAL(18, 2),
	@price DECIMAL(18, 2),
	@color NVARCHAR(30)
AS
BEGIN

	UPDATE dbo.Product
	SET SKU = @sku,
		Name = @name,
		Description = @description,
		Weight = @weight,
		Price = @price,
		Color = @color
	WHERE Id = @id

END
GO