CREATE PROCEDURE [dbo].[sp_GetDisciplinaByNome]
	@nome int

AS
begin
		Select * from tblDisciplinas where nome=@nome
END
