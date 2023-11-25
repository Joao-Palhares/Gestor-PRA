CREATE PROCEDURE [dbo].[sp_DeleteAlunoByID]
	@id_aluno int

AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblAlunos
	where id_aluno=@id_aluno
	if(@count=0)
		begin
			select -1 as ReturnCode
		End
	Else
	Begin
		Delete From tblAlunos where id_aluno=@id_aluno
		select 1 as ReturnCode
	END
END