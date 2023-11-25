CREATE PROCEDURE [dbo].[sp_GetPraByID]
	@id_pra int

AS
begin
		select * From tblPra where id_pra=@id_pra
END