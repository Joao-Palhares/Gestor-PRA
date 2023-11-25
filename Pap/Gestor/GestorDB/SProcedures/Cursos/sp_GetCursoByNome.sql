CREATE PROCEDURE [dbo].[sp_GetCursoByNome]
	@nome varchar(100)

AS
begin
		select * From tblCursos where nome=@nome
END