CREATE TABLE [dbo].[tblPraPrincipal]
(
	[id_principal] INT NOT NULL PRIMARY KEY IDENTITY, 
    [id_aluno] INT NOT NULL, 
    [idade] INT NOT NULL, 
    [ano_letivo] CHAR(13) NOT NULL, 
    [turma] VARCHAR(100) NOT NULL, 
    [numero_aluno] INT NOT NULL, 
    [codepraprincipal] CHAR(70) NOT NULL,
    [id_pra] INT NULL
)