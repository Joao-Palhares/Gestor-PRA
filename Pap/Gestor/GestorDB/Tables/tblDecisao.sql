CREATE TABLE [dbo].[tblDecisao]
(
	[id_decisao] INT NOT NULL PRIMARY KEY IDENTITY, 
    [data_conselho] DATE NOT NULL, 
    [consequencia] VARCHAR(100) NOT NULL, 
    [data_eadpf] DATE NULL,
    [medidas_c_s] varchar(100) NULL,
    [assinatura_diretor] VARCHAR(50) NOT NULL, 
    [data_assinatura_diretor] DATE NOT NULL, 
    [id_pra] INT NULL, 
    [decisao_code] CHAR(61) NOT NULL
)