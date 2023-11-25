CREATE TABLE [dbo].[tblPrhPrincipal]
(
	[id_principal] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ano_letivo] CHAR(13) NOT NULL, 
    [turma] VARCHAR(100) NOT NULL, 
    [numero_aluno] INT NOT NULL, 
    [id_aluno] INT NOT NULL, 
    [curso] VARCHAR(200) NOT NULL, 
    [disciplina] VARCHAR(50) NOT NULL, 
    [tempo_letivos_faltas] INT NOT NULL, 
    [modalidade_adotada] VARCHAR(400) NULL, 
    [outra_modalidade] VARCHAR(100) NULL, 
    [codigo_prhprincipal] CHAR(45) NOT NULL, 
    [id_prh] INT NULL
)