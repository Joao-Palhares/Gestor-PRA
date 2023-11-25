CREATE PROCEDURE [dbo].[sp_UpdateDecisaoByID]
	@id_decisao int,
	@data_conselho date,
	@consequencia varchar(100),
	@data_eadpf date,
	@medidas_c_s varchar(100),
	@assinatura_diretor varchar(50),
	@data_assinatura_diretor date,
	@decisao_code char(61),
	@id_pra int

AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblDecisao
	where id_decisao=@id_decisao

	if(@count=0)
		begin
			select -1 as ReturnCode
		End
	Else
	Begin
		update tblDecisao 
		set data_conselho=@data_conselho , consequencia=@consequencia , data_eadpf = @data_eadpf, medidas_c_s = @medidas_c_s, assinatura_diretor= @assinatura_diretor, data_assinatura_diretor = @data_assinatura_diretor,decisao_code=@decisao_code,id_pra=@id_pra
		where id_decisao=@id_decisao
		select 1 as ReturnCode
	END
END