CREATE PROCEDURE [dbo].[sp_GetModuloByID]
	@id_modulo int

AS
begin
		select * From tblModulos where id_modulo=@id_modulo
END