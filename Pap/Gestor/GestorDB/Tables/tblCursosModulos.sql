CREATE TABLE [dbo].[tblCursosModulos]
(
	[id_cursos_modulos] INT NOT NULL PRIMARY KEY IDENTITY, 
    [id_curso] INT NOT NULL, 
    [id_modulo] INT NOT NULL,
    CONSTRAINT [FK_tblCursosModulos_tblCurso] FOREIGN KEY ([id_curso]) REFERENCES [tblCursos]([id_curso]),
    CONSTRAINT [FK_tblCursosModulos_tblModulos] FOREIGN KEY ([id_modulo]) REFERENCES [tblModulos]([id_modulo])
)