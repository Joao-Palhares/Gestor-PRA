CREATE PROCEDURE [dbo].[sp_GetTurmaByDT]
	@id_professor int

AS
begin
		select * From tblTurmaDT where id_professor=@id_professor
END