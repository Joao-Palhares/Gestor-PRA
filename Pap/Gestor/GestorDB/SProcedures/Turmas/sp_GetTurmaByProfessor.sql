CREATE PROCEDURE [dbo].[sp_GetTurmaByProfessor]
	@id_professor int

AS
begin
		Select DISTINCT tblProfessorTurmaDisciplina.id_turma, tblTurmas.nome_turma from tblTurmas INNER JOIN tblProfessorTurmaDisciplina ON tblTurmas.id_turma = tblProfessorTurmaDisciplina.id_turma where tblProfessorTurmaDisciplina.id_professor=@id_professor
END
