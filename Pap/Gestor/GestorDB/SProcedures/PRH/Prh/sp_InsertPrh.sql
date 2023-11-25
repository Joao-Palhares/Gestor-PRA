CREATE PROCEDURE [dbo].[sp_InsertPrh]
	@id_principal int,
	@codigo_prh varchar(70),
	@id_professor int,
	@id_aluno int,
	@id_turma int,
	@id_dt int,
	@estado varchar(50),
	@progresso varchar(100)


AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_prh) FROM tblPrh

	IF(@count<>0)
	begin 
		select -1 as ReturnCode
	End
	Begin
		Insert INTO [dbo].[tblPrh]
				([id_principal],
				[codigo_prh],
				[id_professor],
				[id_aluno],
				[id_turma],
				[id_dt],
				[estado],
				[progresso])
		Values (@id_principal,@codigo_prh,@id_professor,@id_aluno,@id_turma,@id_dt,@estado,@progresso)
		select 1 as ReturnCode
	END
END