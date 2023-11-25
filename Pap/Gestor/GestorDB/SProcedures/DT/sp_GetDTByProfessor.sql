CREATE PROCEDURE [dbo].[sp_GetDTByProfessor]
	@id_professor int

AS
begin
		select * From tblDT where id_professor=@id_professor
END