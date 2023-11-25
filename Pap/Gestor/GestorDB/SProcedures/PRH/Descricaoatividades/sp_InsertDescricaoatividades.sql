CREATE PROCEDURE [dbo].[sp_InsertDescricaoatividades]
	@atividades varchar(1000),
	@local varchar(1000),
	@data_inicio date,
	@data_final date,
	@codigo_descricao char(50),
	@id_prh int

AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_descriçao_atividade) FROM tbldescricaoatividades

	IF(@count<>0)
	begin 
		select -1 as ReturnCode21
	End
	Begin
		Insert INTO [dbo].[tbldescricaoatividades]
				([atividades],
				[local],
				[data_inicio],
				[data_final],
				[codigo_descricao],
				[id_prh])
		Values (@atividades,@local,@data_inicio,@data_final,@codigo_descricao,@id_prh)
		select 1 as ReturnCode21
	END
END