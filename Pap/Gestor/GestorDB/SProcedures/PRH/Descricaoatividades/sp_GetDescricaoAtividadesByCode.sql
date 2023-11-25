CREATE PROCEDURE [dbo].[sp_GetDescricaoAtividadesByCode]
	@codigo_descricao char(50)
AS
begin
		select * From tbldescricaoatividades where codigo_descricao=@codigo_descricao
END