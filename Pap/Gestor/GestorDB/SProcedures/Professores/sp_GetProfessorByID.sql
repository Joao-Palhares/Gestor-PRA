CREATE PROCEDURE [dbo].[sp_GetProfessorByID]
	@id_professor int

AS
begin
		select * From tblProfessores where id_professor=@id_professor
END