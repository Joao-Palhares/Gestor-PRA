CREATE PROCEDURE [dbo].[sp_GetDisciplinaByProfessor]
	@id_professor int

AS
begin
		select  * From tblDisciplinas INNER JOIN tblProfessorTurmaDisciplina ON tblProfessorTurmaDisciplina.id_disciplina=tblDisciplinas.id_disciplina where tblProfessorTurmaDisciplina.id_professor=@id_professor
END