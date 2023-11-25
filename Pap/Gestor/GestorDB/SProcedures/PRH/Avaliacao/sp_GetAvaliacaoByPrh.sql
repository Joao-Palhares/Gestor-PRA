CREATE PROCEDURE [dbo].[sp_GetAvaliacaoByPrh]
	@id_prh int

AS
begin
		select * From tblAvaliacao where id_prh=@id_prh
END