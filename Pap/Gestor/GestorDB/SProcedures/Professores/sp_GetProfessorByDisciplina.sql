CREATE PROCEDURE [dbo].[sp_GetProfessorByDisciplina]
	@id_disciplina int

AS
begin
		select  * From tblProfessores INNER JOIN tblProfessorTurmaDisciplina ON tblProfessorTurmaDisciplina.id_professor=tblProfessores.id_professor where tblProfessorTurmaDisciplina.id_disciplina=@id_disciplina
END