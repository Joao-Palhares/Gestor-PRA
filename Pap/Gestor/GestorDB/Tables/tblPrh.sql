CREATE TABLE [dbo].[tblPrh]
(
	[id_prh] INT NOT NULL PRIMARY KEY IDENTITY, 
    [id_principal] INT NOT NULL, 
    [id_descricao_atividade] int null,
    [id_avaliaçoes] INT NULL,
    [codigo_prh] VARCHAR(70) NOT NULL, 
    [id_professor] INT NOT NULL, 
    [id_aluno] INT NOT NULL, 
    [id_turma] INT NOT NULL, 
    [id_dt] INT NOT NULL, 
    [estado] VARCHAR(50) NOT NULL, 
    [progresso] VARCHAR(100) NOT NULL, 
    CONSTRAINT [FK_tblPrh_tblPrhPrincipal] FOREIGN KEY ([id_principal]) REFERENCES [tblPrhPrincipal]([id_principal]),
    CONSTRAINT [FK_tblPrh_tblAvaliacao] FOREIGN KEY ([id_avaliaçoes]) REFERENCES [tblAvaliacao]([id_avaliaçoes])
)