CREATE PROCEDURE [dbo].[sp_InsertAvaliacao]
	@avaliaçao_atividade varchar(1000),
	@faltas_desconsideradas varchar(1000),
	@codigo_avaliacao char(65),
	@id_prh int


AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_avaliaçoes) FROM tblAvaliacao

	IF(@count<>0)
	begin 
		select -1 as ReturnCode3
	End
	Begin
		Insert INTO [dbo].[tblAvaliacao]
				([avaliaçao_atividade],
				[faltas_desconsideradas],
				[codigo_avaliacao],
				[id_prh])
		Values (@avaliaçao_atividade,@faltas_desconsideradas,@codigo_avaliacao,@id_prh)
		select 1 as ReturnCode3
	END
END
