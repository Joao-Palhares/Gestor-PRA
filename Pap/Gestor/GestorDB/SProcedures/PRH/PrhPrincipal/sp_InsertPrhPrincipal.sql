CREATE PROCEDURE [dbo].[sp_InsertPrhPrincipal]
	@ano_letivo char(13),
	@turma varchar(100),
	@numero_aluno int,
	@id_aluno int,
	@curso varchar(200),
	@disciplina varchar(50),
	@codigo_prhprincipal char(45),
	@tempo_letivos_faltas int

AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_principal) FROM tblPrhPrincipal Where id_principal=id_principal

	IF(@count<>0)
	begin 
		select -1 as ReturnCode1
	End
	Begin
		Insert INTO [dbo].[tblPrhPrincipal]
				([ano_letivo],
				[turma],
				[numero_aluno],
				[id_aluno],
				[curso],
				[disciplina],
				[tempo_letivos_faltas],
				[codigo_prhprincipal])
		Values (@ano_letivo,@turma,@numero_aluno,@id_aluno,@curso,@disciplina,@tempo_letivos_faltas,@codigo_prhprincipal)
		select 1 as ReturnCode1
	END
END