CREATE PROCEDURE [dbo].[sp_GetMedidasByPra]
	@id_pra int
AS
begin
		select * From tblPraMedidas where id_pra=@id_pra
END