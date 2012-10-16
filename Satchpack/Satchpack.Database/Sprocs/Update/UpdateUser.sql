USE Satchpack
GO

CREATE PROCEDURE [dbo].[UpdateUser]
	@id INT,
	@username NVARCHAR(30),
	@password NVARCHAR(30),
	@lock BIT = 0
AS
BEGIN

	UPDATE dbo.[User]
	SET Username = @username,
		Password = @password,
		Lock = @lock
	WHERE Id = @id

END
GO