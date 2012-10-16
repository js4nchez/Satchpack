USE Satchpack
GO

CREATE PROCEDURE [dbo].[RetrieveUserById]
	@id INT
AS
BEGIN

	SELECT * FROM dbo.[User]
	WHERE Id = @id

END
GO