CREATE PROCEDURE [dbo].[sp_GetAlunoByProcesso]
	@n_processo int

AS
begin
		select * From tblAlunos where n_processo=@n_processo
END