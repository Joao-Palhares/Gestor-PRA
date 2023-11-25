CREATE PROCEDURE [dbo].[sp_GetDecisaoByCode]
	@decisao_code varchar(61)
AS
begin
		select * From tblDecisao where decisao_code=@decisao_code
END
