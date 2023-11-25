CREATE PROCEDURE [dbo].[sp_GetUserByUsername]
	@username varchar(50)
AS
begin
		select * From tblUsers where username=@username
END