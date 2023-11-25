CREATE PROCEDURE [dbo].[sp_GetAlunoByTurma]
	@id_turma int

AS
begin
		select * From tblAlunos where id_turma=@id_turma
END