CREATE PROCEDURE [dbo].[sp_UpdatePraPrincipalByID]
	@id_principal int,
	@id_aluno varchar(200),
	@idade int,
	@ano_letivo char(13),
	@turma varchar(100),
	@numero_aluno int,
	@codepraprincipal char(70),
	@id_pra int
AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblPraPrincipal
	where id_principal=@id_principal

	if(@count=0)
		begin
			select -1 as ReturnCode100
		End
	Else
	Begin
		update tblPraPrincipal 
		set id_aluno=@id_aluno , idade = @idade, ano_letivo = @ano_letivo, turma= @turma, numero_aluno=@numero_aluno,codepraprincipal=@codepraprincipal,id_pra=@id_pra
		where id_principal=@id_principal
		select 1 as ReturnCode100
	END
END