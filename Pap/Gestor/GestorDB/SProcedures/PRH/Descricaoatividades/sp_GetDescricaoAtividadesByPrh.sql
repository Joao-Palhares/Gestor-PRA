CREATE PROCEDURE [dbo].[sp_GetDescricaoAtividadesByPrh]
	@id_prh int

AS
begin
		select * From tbldescricaoatividades where id_prh=@id_prh
END