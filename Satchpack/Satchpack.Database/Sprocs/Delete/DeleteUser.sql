USE Satchpack
GO

CREATE PROCEDURE [dbo].[DeleteUser]
	@id INT
AS
BEGIN

	DELETE FROM dbo.[User]
	WHERE Id = @id

END
GO