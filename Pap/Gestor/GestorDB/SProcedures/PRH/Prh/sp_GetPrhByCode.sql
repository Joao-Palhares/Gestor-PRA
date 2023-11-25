CREATE PROCEDURE [dbo].[sp_GetPrhByCode]
	@codigo_prh char(70)
AS
begin
		select * From tblPrh where codigo_prh=@codigo_prh
END