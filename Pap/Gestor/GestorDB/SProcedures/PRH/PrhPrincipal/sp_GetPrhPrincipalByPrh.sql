CREATE PROCEDURE [dbo].[sp_GetPrhPrincipalByPrh]
	@id_prh int

AS
begin
		select * From tblPrhPrincipal where id_prh=@id_prh
END