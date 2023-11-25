CREATE PROCEDURE [dbo].[sp_GetUserByID]
	@id_user int

AS
begin
		select * From tblUsers where id_user=@id_user
END