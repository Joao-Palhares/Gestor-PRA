CREATE PROCEDURE [dbo].[sp_InsertAluno]
	@nome varchar(100),
	@n_processo int,
	@data_nascimento date,
	@id_curso int,
	@id_turma int,
	@numero int,
	@id_user int,
	@pra varchar(5)
AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_aluno) FROM tblAlunos Where n_processo=@n_processo

	IF(@count<>0)
	begin 
		select -1 as ReturnCode1
	End
	Begin
		Insert INTO [dbo].[tblAlunos]
				([nome_aluno],
				[n_processo],
				[data_nascimento],
				[id_curso],
				[id_turma],
				[numero],
				[id_user],
				[pra])
		Values (@nome,@n_processo,@data_nascimento,@id_curso,@id_turma,@numero,@id_user,@pra)
		select 1 as ReturnCode1
	END
END
