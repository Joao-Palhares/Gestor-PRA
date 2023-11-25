CREATE TABLE [dbo].[tblProfessores] (
    [id_professor]    INT           IDENTITY (1, 1) NOT NULL,
    [nome_professor]            VARCHAR (100) NOT NULL,
    [data_nascimento] DATE          NOT NULL,
    [dt]              VARCHAR (10)  NOT NULL,
    [id_user]         INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id_professor] ASC)
);