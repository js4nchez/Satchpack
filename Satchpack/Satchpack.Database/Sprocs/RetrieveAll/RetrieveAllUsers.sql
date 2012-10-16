USE Satchpack
GO

CREATE PROCEDURE [dbo].[RetrieveAllUsers]
AS
BEGIN

	SELECT * FROM dbo.[User]

END
GO