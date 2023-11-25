CREATE PROCEDURE [dbo].[sp_UpdateDescricaoAtividadesByID]
	@id_descriçao_atividade int,
	@atividades varchar(1000),
	@local varchar(1000),
	@data_inicio date,
	@data_final date,
	@id_prh int,
	@cumprimento varchar(50),
	@codigo_descricao char(50)

AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tbldescricaoatividades
	where id_descriçao_atividade=@id_descriçao_atividade

	if(@count=0)
		begin
			select -1 as ReturnCode100
		End
	Else
	Begin
		update tbldescricaoatividades 
		set atividades=@atividades,local=@local,data_inicio=@data_inicio,data_final=@data_final,id_prh=@id_prh,cumprimento=@cumprimento,codigo_descricao=@codigo_descricao
		where id_descriçao_atividade=@id_descriçao_atividade
		select 1 as ReturnCode10
	END
END