CREATE PROCEDURE [dbo].[sp_InsertDM4]
	@disciplina_modulo int,
	@faltas_excesso int,
	@dmcode char(50),
	@id_professor int,
	@id_pra int

AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_dm) FROM tblPraDM

	IF(@count<>0)
	begin 
		select -1 as ReturnCode2
	End
	Begin
		Insert INTO [dbo].[tblPraDM]
				([disciplina_modulo],
				[faltas_excesso],
				[dmcode],
				[id_professor],
				[id_pra])
		Values (@disciplina_modulo,@faltas_excesso,@dmcode,@id_professor,@id_pra)
		select 1 as ReturnCode24
	END
END