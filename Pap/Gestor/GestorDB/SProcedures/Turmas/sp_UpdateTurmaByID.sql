CREATE PROCEDURE [dbo].[sp_UpdateTurmaByID]
	@id_turma int,
	@ano_escolaridade int,
	@id_curso int,
	@diretor_turma int,
	@nome_turma varchar(100)
AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblTurmas
	where id_turma=@id_turma

	if(@count=0)
		begin
			select -1 as ReturnCode
		End
	Else
	Begin
		update tblTurmas 
		set ano_escolaridade=@ano_escolaridade , id_curso=@id_curso , diretor_turma=@diretor_turma,nome_turma=@nome_turma
		where id_turma=@id_turma
		select 1 as ReturnCode
	END
END