CREATE PROCEDURE [dbo].[sp_GetTurmaByTurma]
	@id_turma int

AS
begin
		select * From tblTurmaDT where id_turma=@id_turma
END