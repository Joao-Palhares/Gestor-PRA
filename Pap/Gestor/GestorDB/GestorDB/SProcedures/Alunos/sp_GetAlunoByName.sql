CREATE PROCEDURE [dbo].[sp_GetAlunoByName]
	@nome varchar(100)

AS
begin
		select * From tblAlunos where nome_aluno=@nome
END