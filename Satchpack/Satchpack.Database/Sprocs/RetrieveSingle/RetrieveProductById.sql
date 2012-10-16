USE Satchpack
GO

CREATE PROCEDURE [dbo].[RetrieveProductById]
	@id INT
AS
BEGIN

	SELECT * FROM dbo.Product
	WHERE Id = @id

END
GO