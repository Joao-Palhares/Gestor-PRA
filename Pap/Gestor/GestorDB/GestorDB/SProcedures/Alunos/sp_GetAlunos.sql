CREATE PROCEDURE [dbo].[sp_GetAlunos]
AS
BEGIN
	SELECT * FROM tblAlunos order by nome_aluno asc
END