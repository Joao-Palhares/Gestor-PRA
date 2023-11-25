CREATE PROCEDURE [dbo].[sp_GetPrhsByDT]
@id_dt int
AS
BEGIN
	SELECT tblPrh.id_prh ,tblAlunos.id_aluno,tblAlunos.nome_aluno,tblTurmas.id_turma ,tblTurmas.nome_turma,tblProfessores.id_professor ,tblProfessores.nome_professor , tblDT.id_dt ,tblDT.nome_dt, tblPrh.estado,tblPrh.progresso
FROM tblPrh
INNER JOIN tblAlunos ON tblPrh.id_aluno = tblAlunos.id_aluno
INNER JOIN tblProfessores ON tblPrh.id_professor = tblProfessores.id_professor
INNER JOIN tblTurmas ON tblPrh.id_turma = tblTurmas.id_turma 
INNER JOIN tblDT ON tblPrh.id_dt = tblDT.id_dt where tblPrh.id_dt=@id_dt
END