CREATE PROCEDURE [dbo].[sp_UpdateAlunoByID]
	@id_aluno int,
	@n_processo varchar(50),
	@nome char(64),
	@data_nascimento date,
	@id_curso int,
	@id_turma int,
	@numero int,
	@pra varchar(5)

AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblAlunos
	where id_aluno=@id_aluno

	if(@count=0)
		begin
			select -1 as ReturnCode
		End
	Else
	Begin
		update tblAlunos 
		set n_processo=@n_processo , nome_aluno=@nome , data_nascimento = @data_nascimento, id_curso = @id_curso, id_turma= @id_turma, numero= @numero, pra=@pra 
		where id_aluno=@id_aluno
		select 1 as ReturnCode
	END
END