CREATE TABLE [dbo].[tblModulos]
(
	[id_modulo] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nome] VARCHAR(100) NOT NULL, 
    [tempos_letivos] INT NOT NULL, 
    [id_disciplina] INT NOT NULL,
    CONSTRAINT [FK_tblModulos_tblDisciplinas] FOREIGN KEY ([id_disciplina]) REFERENCES [tblDisciplinas]([id_disciplina])
)