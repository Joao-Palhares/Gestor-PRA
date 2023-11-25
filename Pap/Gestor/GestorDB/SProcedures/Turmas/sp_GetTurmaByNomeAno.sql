CREATE PROCEDURE [dbo].[sp_GetTurmaByNomeAno]
	@nome_turma varchar(100),
	@ano_escolaridade int

AS
begin
		select * From tblTurmas where nome_turma=@nome_turma and ano_escolaridade=@ano_escolaridade
END