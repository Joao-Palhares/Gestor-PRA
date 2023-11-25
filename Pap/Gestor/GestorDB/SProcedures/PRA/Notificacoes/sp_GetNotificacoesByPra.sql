CREATE PROCEDURE [dbo].[sp_GetNotificacoesByPra]
	@id_pra int
AS
begin
		select * From tblPraNotificacoes where id_pra=@id_pra
END