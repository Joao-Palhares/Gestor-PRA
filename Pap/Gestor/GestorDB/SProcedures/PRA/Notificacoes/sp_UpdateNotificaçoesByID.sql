CREATE PROCEDURE [dbo].[sp_UpdateNotificaçoesByID]
	@id_notificaçoes int,
	@assinatura_enc varchar(50),
	@data_assinatura_enc date,
	@assinatura_dt varchar(50),
	@data_assinatura_dt date,
	@assinatura_pt varchar(50),
	@data_assinatura_pt date,
	@data_assinatura_cpcj date,
	@codenotificaçoes char(65),
	@id_pra int


AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblPraNotificacoes

	if(@count=0)
		begin
			select -1 as ReturnCode
		End
	Else
	Begin
		update tblPraNotificacoes 
		set assinatura_enc=@assinatura_enc , data_assinatura_enc=@data_assinatura_enc, assinatura_dt=@assinatura_dt, data_assinatura_dt=@data_assinatura_dt, assinatura_pt=@assinatura_pt, data_assinatura_pt=@data_assinatura_pt, data_assinatura_cpcj=@data_assinatura_cpcj ,codenotificaçoes=@codenotificaçoes , id_pra=@id_pra
		where id_notificaçoes=@id_notificaçoes
		select 1 as ReturnCode
	END
END