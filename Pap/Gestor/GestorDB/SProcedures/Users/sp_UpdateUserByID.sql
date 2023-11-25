CREATE PROCEDURE [dbo].[sp_UpdateUserByID]
	@id_user int,
	@username varchar(50),
	@password char(64),
	@email varchar(MAX)
AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblUsers
	where id_user=@id_user

	if(@count=0)
		begin
			select -1 as ReturnCode
		End
	Else
	Begin
		update tblUsers 
		set username=@username , email=@email , password=@password
		where id_user=@id_user
		select 1 as ReturnCode
	END
END