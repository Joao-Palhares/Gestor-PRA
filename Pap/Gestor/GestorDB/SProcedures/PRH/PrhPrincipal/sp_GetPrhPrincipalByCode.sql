CREATE PROCEDURE [dbo].[sp_GetPrhPrincipalByCode]
	@codigo_prhprincipal varchar(45)
AS
begin
		select * From tblPrhPrincipal where codigo_prhprincipal=@codigo_prhprincipal
END