CREATE PROCEDURE [dbo].[sp_GetDMByID5]
	@id_dm varchar(50)
AS
begin
		select * From tblPraDM where id_dm=@id_dm
END