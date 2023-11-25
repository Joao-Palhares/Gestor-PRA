CREATE TABLE [dbo].[tblPraNotificacoes]
(
	[id_notificaçoes] INT NOT NULL PRIMARY KEY IDENTITY, 
    [assinatura_enc] VARCHAR(50) NOT NULL, 
    [data_assinatura_enc] DATE NOT NULL, 
    [assinatura_dt] VARCHAR(50) NULL, 
    [data_assinatura_dt] DATE NULL, 
    [assinatura_pt] VARCHAR(50) NULL, 
    [data_assinatura_pt] DATE NULL, 
    [data_assinatura_cpcj] DATE NULL, 
    [codenotificaçoes] CHAR(65) NOT NULL,
    [id_pra] INT NOT NULL,
)