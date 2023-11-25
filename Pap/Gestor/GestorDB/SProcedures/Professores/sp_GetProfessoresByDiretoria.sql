CREATE PROCEDURE [dbo].[sp_GetProfessorByDiretoria]

AS
begin
		select * From tblProfessores where dt='Sim'

END