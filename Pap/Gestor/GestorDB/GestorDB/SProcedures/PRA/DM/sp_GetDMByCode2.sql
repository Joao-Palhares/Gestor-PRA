CREATE PROCEDURE [dbo].[sp_GetDMByCode2]
	@dmcode varchar(50)
AS
begin
		select * From tblPraDM where dmcode=@dmcode
END