CREATE PROCEDURE [dbo].[sp_GetDisciplinaByID]
	@id_disciplina int

AS
begin
		select * From tblDisciplinas where id_disciplina=@id_disciplina
END