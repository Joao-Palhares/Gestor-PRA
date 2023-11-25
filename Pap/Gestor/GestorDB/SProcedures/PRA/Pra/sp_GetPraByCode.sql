CREATE PROCEDURE [dbo].[sp_GetPraByCode]
	@codigo_pra varchar(20)
AS
begin
		select * From tblPra where codigo_pra=@codigo_pra
END