CREATE TABLE [dbo].[tblTurmas]
(
	[id_turma] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ano_escolaridade] INT NOT NULL, 
    [id_curso] INT NOT NULL, 
    [diretor_turma] INT NULL,
    [nome_turma] VARCHAR(100) NOT NULL, 
    CONSTRAINT [FK_tblTurmas_tblCursos] FOREIGN KEY ([id_curso]) REFERENCES [tblCursos]([id_curso]),
	CONSTRAINT [FK_tblTurmas_tblProfessores] FOREIGN KEY ([diretor_turma]) REFERENCES [tblProfessores]([id_professor])
)