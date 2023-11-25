CREATE PROCEDURE [dbo].[sp_GetTurmaByID]
	@id_turma int

AS
begin
		select * From tblTurmas where id_turma=@id_turma
END