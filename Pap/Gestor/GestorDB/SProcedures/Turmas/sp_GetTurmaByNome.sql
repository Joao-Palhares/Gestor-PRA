CREATE PROCEDURE [dbo].[sp_GetTurmaByNome]
	@nome_turma varchar(100)

AS
begin
		select * From tblTurmas where nome_turma=@nome_turma
END