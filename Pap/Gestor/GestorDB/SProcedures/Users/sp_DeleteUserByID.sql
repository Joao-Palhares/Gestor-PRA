CREATE PROCEDURE [dbo].[sp_DeleteUserByID]
	@id_user int

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
		Delete From tblUsers where id_user=@id_user
		select 1 as ReturnCode
	END
END