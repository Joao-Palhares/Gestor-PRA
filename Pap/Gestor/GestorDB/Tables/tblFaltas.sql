CREATE TABLE [dbo].[tblFaltas]
(
	[id_falta] INT NOT NULL PRIMARY KEY IDENTITY, 
    [id_turma] INT NOT NULL, 
    [id_disciplina] INT NOT NULL, 
    [id_aluno] INT NOT NULL, 
    [tempo_letivo] INT NOT NULL, 
    [injustificada_justificada] VARCHAR(13) NOT NULL, 
    [justificacao] VARCHAR(100) NULL 
)