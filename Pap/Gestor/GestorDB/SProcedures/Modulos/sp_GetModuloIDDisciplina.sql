CREATE PROCEDURE [dbo].[sp_GetModuloIDDisciplina]
	@id_disciplina int

AS
begin
		select * From tblModulos where id_disciplina=@id_disciplina
END