CREATE PROCEDURE [dbo].[sp_DeleteProfessorByID]
	@id_professor int

AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblDT
	where id_professor=@id_professor
	if(@count=0)
		begin
			select -1 as ReturnCode
		End
	Else
	Begin
		Delete From tblDT where id_professor=@id_professor
		select 1 as ReturnCode
	END
END