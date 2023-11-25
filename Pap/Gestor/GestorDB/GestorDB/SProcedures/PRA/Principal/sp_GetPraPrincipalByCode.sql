CREATE PROCEDURE [dbo].[sp_GetPraPrincipalByCode]
	@codepraprincipal varchar(70)
AS
begin
		select * From tblPraPrincipal where codepraprincipal=@codepraprincipal
END