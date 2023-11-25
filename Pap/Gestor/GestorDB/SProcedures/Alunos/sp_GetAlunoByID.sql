CREATE PROCEDURE [dbo].[sp_GetAlunoByID]
	@id_aluno int

AS
begin
		select * From tblAlunos where id_aluno=@id_aluno
END