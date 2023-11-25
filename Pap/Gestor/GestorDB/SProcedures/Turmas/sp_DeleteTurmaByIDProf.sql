CREATE PROCEDURE [dbo].[sp_DeleteTurmaByIDProf]
	@id_professor int

AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblTurmas
	where diretor_turma=@id_professor
	if(@count=0)
		begin
			select -1 as ReturnCode
		End
	Else
	Begin
		Delete From tblTurmas where diretor_turma=@id_professor
		select 1 as ReturnCode
	END
END