CREATE PROCEDURE [dbo].[sp_InsertUserAdmin]
	@username varchar(50),
	@password char(64),
	@email varchar(256),
	@role char(2),
	@isfirstlogin bit = '0'

AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_user) FROM tblUsers Where username=@username

	IF(@count<>0)
	begin 
		select -1 as ReturnCode
	End
	Begin
		Insert INTO [dbo].[tblUsers]
				([username],
				[password],
				[email],
				[role],
				[isfirstlogin])
		Values (@username,@password,@email,@role,@isfirstlogin)
		select 1 as ReturnCode
	END
END
