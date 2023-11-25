CREATE PROCEDURE [dbo].[sp_GetDMByPra]
	@id_pra int
AS
begin
		select * From tblPraDM where id_pra=@id_pra
END