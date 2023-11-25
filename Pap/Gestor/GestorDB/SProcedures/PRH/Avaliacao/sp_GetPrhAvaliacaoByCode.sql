CREATE PROCEDURE [dbo].[sp_GetPrhAvaliacaoByCode]
	@codigo_avaliacao char(65)
AS
begin
		select * From tblAvaliacao where codigo_avaliacao=@codigo_avaliacao
END