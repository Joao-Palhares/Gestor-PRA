CREATE PROCEDURE [dbo].[sp_InsertMedidas]
	@periodo_inicio datetime,
	@periodo_fim datetime,
	@medida varchar(300),
	@codemedidas char(60),
	@id_pra int 

AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_medidas) FROM tblPraMedidas

	IF(@count<>0)
	begin 
		select -1 as ReturnCode4
	End
	Begin
		Insert INTO [dbo].[tblPraMedidas]
				([periodo_inicio],
				[periodo_fim],
				[medida],
				[codemedidas],
				[id_pra])
		Values (@periodo_inicio,@periodo_fim,@medida,@codemedidas,@id_pra)
		select 1 as ReturnCode4
	END
END