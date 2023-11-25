CREATE PROCEDURE [dbo].[sp_GetPrhEstadoByID]
	@id_prh int

AS
begin
		select * From tblPrh where id_prh=@id_prh
END