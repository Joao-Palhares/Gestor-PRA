CREATE PROCEDURE [dbo].[sp_InsertCurso]
	@nome varchar(100),
	@diretor_curso varchar(100)
AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_curso) FROM tblCursos Where nome=@nome

	IF(@count<>0)
	begin 
		select -1 as ReturnCode
	End
	Begin
		Insert INTO [dbo].[tblCursos]
				([nome],
				[diretor_curso])
		Values (@nome,@diretor_curso)
		select 1 as ReturnCode
	END
END