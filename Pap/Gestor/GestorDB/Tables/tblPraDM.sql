CREATE TABLE [dbo].[tblPraDM]
(
	[id_dm] INT NOT NULL PRIMARY KEY IDENTITY, 
    [disciplina_modulo] INT NOT NULL, 
    [faltas_excesso] INT NOT NULL, 
    [assinatura_professor_disciplina] VARCHAR(50) NULL, 
    [data_assinatura] DATE NULL, 
    [avaliaçao] VARCHAR(50) NULL, 
    [retido] VARCHAR(50) NULL, 
    [id_pra] INT NOT NULL, 
    [dmcode] CHAR(50) NOT NULL, 
    [id_professor] INT NOT NULL
)