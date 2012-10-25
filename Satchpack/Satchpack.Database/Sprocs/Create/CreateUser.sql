USE Satchpack
GO

CREATE PROCEDURE [dbo].[CreateUser]
	@id INT,
	@username NVARCHAR(30),
	@password NVARCHAR(30),
	@lock BIT = 0
AS
BEGIN

	INSERT INTO dbo.[User] (Username, Password, Lock)
	VALUES (@username, @password, @lock)

	SELECT SCOPE_IDENTITY();

END
GO