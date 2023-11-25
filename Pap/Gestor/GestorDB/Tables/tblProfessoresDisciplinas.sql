CREATE TABLE [dbo].[tblProfessoresDisciplinas]
(
	[id_professores_disciplinas] INT NOT NULL PRIMARY KEY IDENTITY,
    [id_professor] INT NOT NULL, 
    [id_disciplina] INT NOT NULL, 
    CONSTRAINT [FK_tblProfessoresDisciplinas_tblProfessores] FOREIGN KEY ([id_professor]) REFERENCES [tblProfessores]([id_professor]),
    CONSTRAINT [FK_tblProfessoresDisciplinas_tblDisciplinas] FOREIGN KEY ([id_disciplina]) REFERENCES [tblDisciplinas]([id_disciplina])
)