CREATE PROCEDURE [dbo].[sp_GetCursoByID]
	@id_curso int

AS
begin
		select * From tblCursos where id_curso=@id_curso
END