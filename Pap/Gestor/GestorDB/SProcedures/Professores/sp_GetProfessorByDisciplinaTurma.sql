CREATE PROCEDURE [dbo].[sp_GetProfessorByDisciplinaTurma]
	@id_disciplina int,
	@id_turma int

AS
begin
		select  * From tblProfessores 
		INNER JOIN tblProfessorTurmaDisciplina ON tblProfessorTurmaDisciplina.id_professor=tblProfessores.id_professor AND tblProfessorTurmaDisciplina.id_professor=tblProfessores.id_professor
		where tblProfessorTurmaDisciplina.id_turma=@id_turma AND tblProfessorTurmaDisciplina.id_disciplina=@id_disciplina
END