CREATE PROCEDURE [dbo].[sp_GetDisciplinaByModulo]
@id_modulo int
AS
BEGIN
	SELECT *
FROM tblDisciplinas
INNER JOIN tblModulos ON tblDisciplinas.id_disciplina=tblModulos.id_disciplina where tblModulos.id_modulo=@id_modulo
END