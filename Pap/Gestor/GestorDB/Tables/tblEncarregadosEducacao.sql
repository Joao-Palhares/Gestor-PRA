CREATE TABLE [dbo].[tblEncarregadosEducacao]
(
	[id_encedu] INT NOT NULL PRIMARY KEY IDENTITY, 
    [id_aluno] INT NOT NULL, 
    [Enc_Edu] VARCHAR(100) NOT NULL,
	CONSTRAINT [FK_tblEncarregadosEducaçao_tblAlunos] FOREIGN KEY ([id_aluno]) REFERENCES [tblAlunos]([id_aluno])
)
