CREATE PROCEDURE [dbo].[sp_GetProfessorByTurma]
	@id_turma int

AS
begin
		Select DISTINCT tblProfessorTurmaDisciplina.id_professor, tblProfessores.nome_professor from tblProfessores INNER JOIN tblProfessorTurmaDisciplina ON tblProfessores.id_professor=tblProfessorTurmaDisciplina.id_professor where tblProfessorTurmaDisciplina.id_turma=@id_turma
END
