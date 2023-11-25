CREATE PROCEDURE [dbo].[sp_GetTurmaIDCurso]
	@id_curso int

AS
begin
		select * From tblTurmas where id_curso=@id_curso
END