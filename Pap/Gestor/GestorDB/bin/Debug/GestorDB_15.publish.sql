﻿/*
Deployment script for GestorDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "GestorDB"
:setvar DefaultFilePrefix "GestorDB"
:setvar DefaultDataPath "C:\Users\jonip\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB"
:setvar DefaultLogPath "C:\Users\jonip\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Altering [dbo].[sp_AuthenticateUser]...';


GO
ALTER PROCEDURE [dbo].[sp_AuthenticateUser]
	@username varchar(50),
	@password char(64)

AS
BEGIN
	declare @countuser int

	Select @countuser = COUNT(*) From tblUsers Where username= @username

	IF(@countuser <> 0) -- verifica se o username está registado
		BEGIN
			DECLARE @is_locked bit				-- 0 - não bloqueado; 1 - bloqueado
			DECLARE @nr_attempts int			--nº de tentativas falhadas
			DECLARE @locked_date_time datetime
			declare @count1 int

			select @locked_date_time = locked_date_time, @nr_attempts = nr_attempts, @is_locked = is_locked from tblUsers where username = @username
			
			
			if(@is_locked = 1)
				begin 
					declare @a int
					select @a = DATEDIFF(Hour,@locked_date_time,GETDATE())
					if(@a >= 1)
						begin
							update tblUsers set is_locked=0, nr_attempts=0, locked_date_time=null where username = @username
							set @is_locked = 0
						end
				end

			if(@is_locked = 0)
				begin
					select @count1 = Count(*) from tblUsers where username = @username and password = @password
						if(@count1 = 0)
							begin
								if(@nr_attempts >= 3)
									begin
										update tblUsers set is_locked = 1, nr_attempts = 0, locked_date_time = GETDATE() where username = @username
									end
								else
									begin
										update tblUsers set nr_attempts = nr_attempts + 1 where username = @username
									end
							end
						else
							begin
								update tblUsers set is_locked = 0, locked_date_time = null, nr_attempts = 0 where username = @username
							end
				end
		end
		select * from tblUsers where username = @username
END
GO
PRINT N'Creating [dbo].[GetUsers]...';


GO
CREATE PROCEDURE [dbo].[GetUsers]
AS
BEGIN
	SELECT * FROM tblUsers
END
GO
PRINT N'Update complete.';


GO
