CREATE TABLE [dbo].[tblProfessoresPra]
(
	[id_professores_pra] INT NOT NULL PRIMARY KEY IDENTITY, 
    [id_professor] INT NOT NULL, 
    [id_pra] INT NOT NULL,
	CONSTRAINT [FK_tblProfessoresPra_tblProfessores] FOREIGN KEY ([id_professor]) REFERENCES [tblProfessores]([id_professor]),
    CONSTRAINT [FK_tblProfessoresPra_tblPra] FOREIGN KEY ([id_pra]) REFERENCES [tblPra]([id_pra])
)