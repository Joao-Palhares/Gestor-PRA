CREATE PROCEDURE [dbo].[sp_GetMedidasByCode]
	@codemedidas varchar(60)
AS
begin
		select * From tblPraMedidas where codemedidas=@codemedidas
END