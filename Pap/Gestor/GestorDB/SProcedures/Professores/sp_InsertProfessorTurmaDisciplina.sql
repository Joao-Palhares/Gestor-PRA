CREATE PROCEDURE [dbo].[sp_InsertProfessorTurmaDisciplina]
	@id_professor int,
	@id_turma int,
	@id_disciplina int
	
AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_ProfessorTurmaDisciplina) FROM tblProfessorTurmaDisciplina

	IF(@count<>0)
	begin 
		select -1 as ReturnCode1
	End
	Begin
		Insert INTO [dbo].[tblProfessorTurmaDisciplina]
				([id_professor],
				[id_turma],
				[id_disciplina])
		Values (@id_professor,@id_turma,@id_disciplina)
		select 1 as ReturnCode1
	END
END