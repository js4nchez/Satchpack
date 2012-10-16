USE Satchpack
GO

CREATE PROCEDURE [dbo].[DeleteProduct]
	@id INT
AS
BEGIN

	DELETE FROM dbo.Product
	WHERE Id = @id

END
GO