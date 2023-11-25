CREATE TABLE [dbo].[tblCursosDisciplinas]
(
	[id_cursos_disciplinas] INT NOT NULL PRIMARY KEY IDENTITY, 
    [id_curso] INT NOT NULL, 
    [id_disciplina] INT NOT NULL,
    CONSTRAINT [FK_tblCursosDisciplinas_tblCurso] FOREIGN KEY ([id_curso]) REFERENCES [tblCursos]([id_curso]),
    CONSTRAINT [FK_tblCursosDisciplinas_tblDisciplinas] FOREIGN KEY ([id_disciplina]) REFERENCES [tblDisciplinas]([id_disciplina])
)