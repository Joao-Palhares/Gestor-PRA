CREATE PROCEDURE [dbo].[sp_GetNotificacoesByCode]
	@codenotificaçoes varchar(65)
AS
begin
		select * From tblPraNotificacoes where codenotificaçoes=@codenotificaçoes
END