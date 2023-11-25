CREATE PROCEDURE [dbo].[sp_GetPrasByAluno]
@id_aluno int
AS
BEGIN
	SELECT tblPra.id_pra ,tblAlunos.id_aluno,tblAlunos.nome_aluno,tblProfessores.id_professor,tblProfessores.nome_professor,tblTurmas.id_turma ,tblTurmas.nome_turma , tblDT.id_dt ,tblDT.nome_dt, tblPra.estado,tblPra.progresso
FROM tblPra
INNER JOIN tblProfessores ON tblPra.id_professor1=tblProfessores.id_professor
INNER JOIN tblAlunos ON tblPra.id_aluno = tblAlunos.id_aluno 
INNER JOIN tblTurmas ON tblPra.id_turma = tblTurmas.id_turma 
INNER JOIN tblDT ON tblPra.id_dt = tblDT.id_dt where tblPra.id_aluno=@id_aluno
END