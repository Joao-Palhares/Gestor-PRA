CREATE PROCEDURE [dbo].[sp_InsertTurmaDT]
	@id_turma int,
	@id_professor int


AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_turma_dt) FROM tblTurmaDT

	IF(@count<>0)
	begin 
		select -1 as ReturnCode
	End
	Begin
		Insert INTO [dbo].[tblTurmaDT]
				([id_turma],
				[id_professor])
		Values (@id_turma,@id_professor)
		select 1 as ReturnCode
	END
END