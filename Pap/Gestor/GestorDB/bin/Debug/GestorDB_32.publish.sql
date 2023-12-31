﻿/*
Deployment script for GestorDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "GestorDB"
:setvar DefaultFilePrefix "GestorDB"
:setvar DefaultDataPath "C:\Users\jonip\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\jonip\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Dropping [dbo].[FK_tblPra_tblDecisao]...';


GO
ALTER TABLE [dbo].[tblPra] DROP CONSTRAINT [FK_tblPra_tblDecisao];


GO
PRINT N'Dropping [dbo].[FK_tblPra_tblPraDM]...';


GO
ALTER TABLE [dbo].[tblPra] DROP CONSTRAINT [FK_tblPra_tblPraDM];


GO
PRINT N'Dropping [dbo].[FK_tblPra_tblPraMedidas]...';


GO
ALTER TABLE [dbo].[tblPra] DROP CONSTRAINT [FK_tblPra_tblPraMedidas];


GO
PRINT N'Dropping [dbo].[FK_tblPra_tblPraNotificaçoes]...';


GO
ALTER TABLE [dbo].[tblPra] DROP CONSTRAINT [FK_tblPra_tblPraNotificaçoes];


GO
PRINT N'Dropping [dbo].[FK_tblPra_tblPraPrincipal]...';


GO
ALTER TABLE [dbo].[tblPra] DROP CONSTRAINT [FK_tblPra_tblPraPrincipal];


GO
PRINT N'Dropping [dbo].[FK_tblPrh_tblAvaliacao]...';


GO
ALTER TABLE [dbo].[tblPrh] DROP CONSTRAINT [FK_tblPrh_tblAvaliacao];


GO
PRINT N'Dropping [dbo].[FK_tblPrh_tblPrhPrincipal]...';


GO
ALTER TABLE [dbo].[tblPrh] DROP CONSTRAINT [FK_tblPrh_tblPrhPrincipal];


GO
PRINT N'Altering [dbo].[tblPra]...';


GO
ALTER TABLE [dbo].[tblPra] ALTER COLUMN [id_decisao] INT NULL;

ALTER TABLE [dbo].[tblPra] ALTER COLUMN [id_dm] INT NULL;

ALTER TABLE [dbo].[tblPra] ALTER COLUMN [id_medidas] INT NULL;

ALTER TABLE [dbo].[tblPra] ALTER COLUMN [id_notificaçoes] INT NULL;

ALTER TABLE [dbo].[tblPra] ALTER COLUMN [id_principal] INT NULL;


GO
PRINT N'Altering [dbo].[tblPrh]...';


GO
ALTER TABLE [dbo].[tblPrh] ALTER COLUMN [id_avaliaçoes] INT NULL;

ALTER TABLE [dbo].[tblPrh] ALTER COLUMN [id_principal] INT NULL;


GO
PRINT N'Creating [dbo].[FK_tblPra_tblDecisao]...';


GO
ALTER TABLE [dbo].[tblPra] WITH NOCHECK
    ADD CONSTRAINT [FK_tblPra_tblDecisao] FOREIGN KEY ([id_decisao]) REFERENCES [dbo].[tblDecisao] ([id_decisao]);


GO
PRINT N'Creating [dbo].[FK_tblPra_tblPraDM]...';


GO
ALTER TABLE [dbo].[tblPra] WITH NOCHECK
    ADD CONSTRAINT [FK_tblPra_tblPraDM] FOREIGN KEY ([id_dm]) REFERENCES [dbo].[tblPraDM] ([id_dm]);


GO
PRINT N'Creating [dbo].[FK_tblPra_tblPraMedidas]...';


GO
ALTER TABLE [dbo].[tblPra] WITH NOCHECK
    ADD CONSTRAINT [FK_tblPra_tblPraMedidas] FOREIGN KEY ([id_medidas]) REFERENCES [dbo].[tblPraMedidas] ([id_medidas]);


GO
PRINT N'Creating [dbo].[FK_tblPra_tblPraNotificaçoes]...';


GO
ALTER TABLE [dbo].[tblPra] WITH NOCHECK
    ADD CONSTRAINT [FK_tblPra_tblPraNotificaçoes] FOREIGN KEY ([id_notificaçoes]) REFERENCES [dbo].[tblPraNotificacoes] ([id_notificaçoes]);


GO
PRINT N'Creating [dbo].[FK_tblPra_tblPraPrincipal]...';


GO
ALTER TABLE [dbo].[tblPra] WITH NOCHECK
    ADD CONSTRAINT [FK_tblPra_tblPraPrincipal] FOREIGN KEY ([id_principal]) REFERENCES [dbo].[tblPraPrincipal] ([id_principal]);


GO
PRINT N'Creating [dbo].[FK_tblPrh_tblAvaliacao]...';


GO
ALTER TABLE [dbo].[tblPrh] WITH NOCHECK
    ADD CONSTRAINT [FK_tblPrh_tblAvaliacao] FOREIGN KEY ([id_avaliaçoes]) REFERENCES [dbo].[tblAvaliacao] ([id_avaliaçoes]);


GO
PRINT N'Creating [dbo].[FK_tblPrh_tblPrhPrincipal]...';


GO
ALTER TABLE [dbo].[tblPrh] WITH NOCHECK
    ADD CONSTRAINT [FK_tblPrh_tblPrhPrincipal] FOREIGN KEY ([id_principal]) REFERENCES [dbo].[tblPrhPrincipal] ([id_principal]);


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[tblPra] WITH CHECK CHECK CONSTRAINT [FK_tblPra_tblDecisao];

ALTER TABLE [dbo].[tblPra] WITH CHECK CHECK CONSTRAINT [FK_tblPra_tblPraDM];

ALTER TABLE [dbo].[tblPra] WITH CHECK CHECK CONSTRAINT [FK_tblPra_tblPraMedidas];

ALTER TABLE [dbo].[tblPra] WITH CHECK CHECK CONSTRAINT [FK_tblPra_tblPraNotificaçoes];

ALTER TABLE [dbo].[tblPra] WITH CHECK CHECK CONSTRAINT [FK_tblPra_tblPraPrincipal];

ALTER TABLE [dbo].[tblPrh] WITH CHECK CHECK CONSTRAINT [FK_tblPrh_tblAvaliacao];

ALTER TABLE [dbo].[tblPrh] WITH CHECK CHECK CONSTRAINT [FK_tblPrh_tblPrhPrincipal];


GO
PRINT N'Update complete.';


GO
