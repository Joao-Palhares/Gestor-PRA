CREATE PROCEDURE [dbo].[sp_InsertNotificacoes]
	@assinatura_enc varchar(50),
	@data_assinatura_enc date,
	@codenotificaçoes char(65),
	@id_pra int

AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_notificaçoes) FROM tblPraNotificacoes

	IF(@count<>0)
	begin 
		select -1 as ReturnCode4
	End
	Begin
		Insert INTO [dbo].[tblPraNotificacoes]
				([assinatura_enc],
				[data_assinatura_enc],
				[codenotificaçoes],
				[id_pra])
		Values (@assinatura_enc,@data_assinatura_enc,@codenotificaçoes,@id_pra)
		select 1 as ReturnCode4
	END
END