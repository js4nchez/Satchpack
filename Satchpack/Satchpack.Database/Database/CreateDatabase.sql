USE master
GO

IF NOT EXISTS (SELECT name 
			   FROM master.dbo.sysdatabases 
			   WHERE name = N'Satchpack')
CREATE DATABASE Satchpack
GO