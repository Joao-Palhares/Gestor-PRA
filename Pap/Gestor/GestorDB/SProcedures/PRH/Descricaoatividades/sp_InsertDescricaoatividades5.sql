CREATE PROCEDURE [dbo].[sp_InsertDescricaoatividades5]
	@id_descriçao_atividade int,
	@atividades varchar(300),
	@local varchar(100),
	@data_inicio date,
	@data_final date,
	@id_prh int

AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_descriçao_atividade) FROM tbldescricaoatividades Where id_descriçao_atividade=@id_descriçao_atividade

	IF(@count<>0)
	begin 
		select -1 as ReturnCode25
	End
	Begin
		Insert INTO [dbo].[tbldescricaoatividades]
				([id_descriçao_atividade],
				[atividades],
				[local],
				[data_inicio],
				[data_final],
				[id_prh])
		Values (@id_descriçao_atividade,@atividades,@local,@data_inicio,@data_final,@id_prh)
		select 1 as ReturnCode25
	END
END