CREATE PROCEDURE [dbo].[sp_InsertPra]
	@id_principal int,
	@codigo_pra varchar(20),
	@id_aluno int,
	@id_turma int,
	@id_dt int,
	@estado varchar(100),
	@progresso varchar(100)

AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_pra) FROM tblPra 

	IF(@count<>0)
	begin 
		select -1 as ReturnCodepra
	End
	Begin
		Insert INTO [dbo].[tblPra]
				([id_principal],
				[codigo_pra],
				[id_aluno],
				[id_turma],
				[id_dt],
				[estado],
				[progresso])
		Values (@id_principal,@codigo_pra,@id_aluno,@id_turma,@id_dt,@estado,@progresso)
		select 1 as ReturnCodepra
	END
END