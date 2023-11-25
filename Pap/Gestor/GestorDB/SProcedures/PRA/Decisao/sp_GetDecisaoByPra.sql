CREATE PROCEDURE [dbo].[sp_GetDecisaoByPra]
	@id_pra int
AS
begin
		select * From tblDecisao where id_pra=@id_pra
END