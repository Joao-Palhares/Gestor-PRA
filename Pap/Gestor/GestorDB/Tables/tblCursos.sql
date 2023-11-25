CREATE TABLE [dbo].[tblCursos]
(
	[id_curso] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nome] VARCHAR(100) NOT NULL, 
    [diretor_curso] VARCHAR(100) NOT NULL,
    CONSTRAINT [UK_tblcursos_dirtor_curso] UNIQUE ([diretor_curso])
)