CREATE PROCEDURE [dbo].[sp_UpdatePrhPrincipalByID]
	@id_principal int,
	@ano_letivo char(13),
	@turma varchar(100),
	@numero_aluno int,
	@id_aluno int,
	@curso varchar(200),
	@disciplina varchar(50),
	@tempo_letivos_faltas int,
	@modalidade_adotada varchar(400),
	@outra_modalidade varchar(100),
	@codigo_prhprincipal char(45),
	@id_prh int
AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblPrhPrincipal
	where id_principal=@id_principal

	if(@count=0)
		begin
			select -1 as ReturnCode100
		End
	Else
	Begin
		update tblPrhPrincipal 
		set ano_letivo=@ano_letivo, turma=@turma, numero_aluno=@numero_aluno, id_aluno=@id_aluno , curso=@curso ,disciplina=@disciplina ,tempo_letivos_faltas=@tempo_letivos_faltas , modalidade_adotada=@modalidade_adotada , outra_modalidade=@outra_modalidade ,codigo_prhprincipal=@codigo_prhprincipal, id_prh=@id_prh
		where id_principal=@id_principal
		select 1 as ReturnCode10
	END
END