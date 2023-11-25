CREATE PROCEDURE [dbo].[sp_DeleteTurmaDTByIDProf]
	@id_professor int

AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblTurmaDT
	where id_professor=@id_professor
	if(@count=0)
		begin
			select -1 as ReturnCode
		End
	Else
	Begin
		Delete From tblTurmaDT where id_professor=@id_professor
		select 1 as ReturnCode
	END
END