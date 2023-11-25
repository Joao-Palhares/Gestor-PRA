CREATE TABLE [dbo].[tblDisciplinas]
(
	[id_disciplina] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nome] VARCHAR(100) NOT NULL, 
    [id_curso] INT NOT NULL,
    CONSTRAINT [FK_tblCursos_tblDisciplinas] FOREIGN KEY ([id_curso]) REFERENCES [tblCursos]([id_curso])
)