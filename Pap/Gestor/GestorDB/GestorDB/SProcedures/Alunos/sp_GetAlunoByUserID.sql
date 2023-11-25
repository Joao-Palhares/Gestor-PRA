CREATE PROCEDURE [dbo].[sp_GetAlunoByUserID]
	@id_user int

AS
begin
		select * From tblAlunos where id_user=@id_user
END