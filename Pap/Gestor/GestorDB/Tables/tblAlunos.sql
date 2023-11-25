CREATE TABLE [dbo].[tblAlunos]
(
    [id_aluno]        INT           IDENTITY (1, 1) NOT NULL PRIMARY KEY ,
    [n_processo]      INT           NOT NULL,
    [nome_aluno]            VARCHAR (100) NOT NULL,
    [data_nascimento] DATE          NOT NULL,
    [id_curso]           INT NOT NULL,
    [id_turma]           INT NOT NULL,
    [numero]           int NOT NULL,
    [id_user]          int NOT NULL,
    [pra] VARCHAR(5) NOT NULL  , 
    CONSTRAINT [FK_tblAlunos_tblcursos] FOREIGN KEY ([id_curso]) REFERENCES [tblCursos]([id_curso]),
	CONSTRAINT [FK_tblAlunos_tblUsers] FOREIGN KEY ([id_user]) REFERENCES [tblUsers]([id_user])
);