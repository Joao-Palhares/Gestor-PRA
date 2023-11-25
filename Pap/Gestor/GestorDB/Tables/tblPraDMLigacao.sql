CREATE TABLE [dbo].[tblPraDMLigacao]
(
	[Id_pra_dm] INT NOT NULL PRIMARY KEY IDENTITY, 
    [id_pra] INT NULL, 
    [id_dm] INT NOT NULL,
    CONSTRAINT [FK_tblPraDMLigacao_tblPra] FOREIGN KEY ([id_pra]) REFERENCES [tblPra]([id_pra]),
    CONSTRAINT [FK_tblPraDMLigacao_tblPraDM] FOREIGN KEY ([id_dm]) REFERENCES [tblPraDM]([id_dm])
)
