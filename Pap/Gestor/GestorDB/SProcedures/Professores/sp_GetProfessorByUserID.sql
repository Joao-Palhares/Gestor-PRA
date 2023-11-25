CREATE PROCEDURE [dbo].[sp_GetProfessorByUserID]
	@id_user int

AS
begin
		select * From tblProfessores where id_user=@id_user
END