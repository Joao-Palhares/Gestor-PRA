CREATE TABLE [dbo].[tblCursosTurmas]
(
	[id_curso_turma] INT NOT NULL IDENTITY,
	[id_curso] INT NOT NULL , 
    [id_turma] INT NOT NULL,
    CONSTRAINT [FK_tblCursosTurmas_tblCursos] FOREIGN KEY ([id_curso]) REFERENCES [tblCursos]([id_curso]),
	CONSTRAINT [FK_tblCursosTurmas_tblTurmas] FOREIGN KEY ([id_turma]) REFERENCES [tblTurmas]([id_turma])
)