CREATE PROCEDURE [dbo].[sp_GetPraPrincipalByPra]
	@id_pra int

AS
begin
		select * From tblPraPrincipal where id_pra=@id_pra
END