CREATE TABLE [dbo].[tblAvaliacao]
(
	[id_avaliaçoes] INT NOT NULL PRIMARY KEY IDENTITY, 
    [avaliaçao_atividade] VARCHAR(1000) NOT NULL, 
    [faltas_desconsideradas] VARCHAR(1000) NOT NULL, 
    [nome_aluno] VARCHAR(200) NULL, 
    [data_assinatura_aluno] DATE NULL, 
    [nome_professor] VARCHAR(200) NULL, 
    [data_assinatura_professor] DATE NULL, 
    [dt_assinatura] VARCHAR(200) NULL, 
    [data_assinatura_dt] DATE NULL, 
    [id_prh] INT NOT NULL, 
    [codigo_avaliacao] CHAR(65) NOT NULL
)