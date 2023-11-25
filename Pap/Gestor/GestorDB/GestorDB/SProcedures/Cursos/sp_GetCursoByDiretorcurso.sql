CREATE PROCEDURE [dbo].[sp_GetCursoByDiretorcurso]
	@diretor_curso varchar(100)

AS
begin
		select * From tblCursos where diretor_curso=@diretor_curso
END