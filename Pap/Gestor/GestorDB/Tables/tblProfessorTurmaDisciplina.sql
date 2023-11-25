CREATE TABLE [dbo].[tblProfessorTurmaDisciplina]
(
	[id_ProfessorTurmaDisciplina] INT NOT NULL PRIMARY KEY IDENTITY, 
    [id_professor] INT NOT NULL, 
    [id_disciplina] INT NOT NULL, 
    [id_turma] INT NOT NULL
)
