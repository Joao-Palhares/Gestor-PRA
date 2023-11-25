CREATE PROCEDURE [dbo].[sp_InsertPrincipal]
	@idade int,
	@id_aluno int,
	@ano_letivo char(13),
	@turma varchar(100),
	@numero_aluno int,
	@codepraprincipal CHAR(70)
AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_principal) FROM tblPraPrincipal

	IF(@count<>0)
	begin 
		select -1 as ReturnCode
	End
	Begin
		Insert INTO [dbo].[tblPraPrincipal]
				([idade],
				[id_aluno],
				[ano_letivo],
				[turma],
				[numero_aluno],
				[codepraprincipal])
		Values (@idade,@id_aluno,@ano_letivo,@turma,@numero_aluno,@codepraprincipal)
		select 1 as ReturnCode
	END
END