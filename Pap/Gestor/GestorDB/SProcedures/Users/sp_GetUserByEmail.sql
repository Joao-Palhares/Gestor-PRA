CREATE PROCEDURE [dbo].[sp_GetUserByEmail]
	@email varchar(256)
AS
begin
		select * From tblUsers where email=@email
END