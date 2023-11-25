CREATE TABLE [dbo].[tblPraMedidas]
(
	[id_medidas] INT NOT NULL PRIMARY KEY IDENTITY, 
    [periodo_inicio] DATETIME NOT NULL, 
    [periodo_fim] DATETIME NOT NULL, 
    [medida] VARCHAR(300) NOT NULL, 
    [cumprimento] VARCHAR(50) NULL, 
    [data_cumprimento] DATE NULL, 
    [dever_incumprimento] VARCHAR(50) NULL, 
    [data_incumprimento] DATE NULL, 
    [faltas_desconsideradas] VARCHAR(300) NULL, 
    [codemedidas] CHAR(60) NOT NULL,
    [id_pra] INT NOT NULL 
    
)