CREATE PROCEDURE [dbo].[sp_InsertProfessor]
	@nome char(64),
	@data_nascimento date,
	@dt varchar(10),
	@id_user int
AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_professor) FROM tblProfessores Where nome_professor=@nome

	IF(@count<>0)
	begin 
		select -1 as ReturnCode1
	End
	Begin
		Insert INTO [dbo].[tblProfessores]
				([nome_professor],
				[data_nascimento],
				[dt],
				[id_user])
		Values (@nome,@data_nascimento,@dt,@id_user)
		select 1 as ReturnCode1
	END
END