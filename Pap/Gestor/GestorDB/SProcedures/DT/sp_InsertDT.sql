CREATE PROCEDURE [dbo].[sp_InsertDT]
	@nome char(64),
	@id_professor int
AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_dt) FROM tblDT 

	IF(@count<>0)
	begin 
		select -1 as ReturnCode1
	End
	Begin
		Insert INTO [dbo].[tblDT]
				([nome_dt],
				[id_professor])
		Values (@nome,@id_professor)
		select 1 as ReturnCode1
	END
END