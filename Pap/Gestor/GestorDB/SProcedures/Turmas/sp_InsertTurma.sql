CREATE PROCEDURE [dbo].[sp_InsertTurma]
	@id_curso int,
	@ano_escolaridade int,
	@nome_turma varchar(100)
AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_curso) FROM tblTurmas Where nome_turma=@nome_turma

	IF(@count<>0)
	begin 
		select -1 as ReturnCode
	End
	Begin
		Insert INTO [dbo].[tblTurmas]
				([id_curso],
				[ano_escolaridade],
				[nome_turma])
		Values (@id_curso,@ano_escolaridade,@nome_turma)
		select 1 as ReturnCode
	END
END