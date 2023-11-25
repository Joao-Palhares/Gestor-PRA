CREATE PROCEDURE [dbo].[sp_GetTurmaByDiretorturma]

AS
begin
		select id_turma , nome_turma , diretor_turma From tblTurmas where diretor_turma IS NULL
END