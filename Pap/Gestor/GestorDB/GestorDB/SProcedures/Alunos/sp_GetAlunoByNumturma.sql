CREATE PROCEDURE [dbo].[sp_GetAlunoByNumturma]
	@numero int

AS
begin
		select * From tblAlunos where numero=@numero
END