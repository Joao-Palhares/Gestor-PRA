CREATE PROCEDURE [dbo].[sp_GetDisciplinaByTurma]
	@id_turma int

AS
begin
		Select DISTINCT tblProfessorTurmaDisciplina.id_disciplina, tblDisciplinas.id_disciplina , tblDisciplinas.nome
		from tblProfessorTurmaDisciplina
		INNER JOIN tblDisciplinas 
		ON tblProfessorTurmaDisciplina.id_disciplina=tblDisciplinas.id_disciplina 
		where tblProfessorTurmaDisciplina.id_turma=@id_turma
END
