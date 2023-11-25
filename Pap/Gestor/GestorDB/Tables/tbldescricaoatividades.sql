CREATE TABLE [dbo].[tbldescricaoatividades]
(
	[id_descriçao_atividade] INT NOT NULL PRIMARY KEY IDENTITY, 
    [atividades] VARCHAR(1000) NOT NULL, 
    [local] VARCHAR(1000) NOT NULL, 
    [data_inicio] DATE NOT NULL, 
    [data_final] DATE NOT NULL, 
    [cumprimento] varchar(15) NULL,
    [id_prh] INT NULL,
    [codigo_descricao] CHAR(50) NOT NULL, 
    CONSTRAINT [FK_tbldescricaoatividades_tblPrh] FOREIGN KEY ([id_prh]) REFERENCES [tblPrh]([id_prh])
)