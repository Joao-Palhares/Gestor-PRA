CREATE PROCEDURE [dbo].[sp_UpdatePraByID]
	@id_pra int,
	@id_principal int,
	@id_medidas int,
	@id_notificaçoes int,
	@id_decisao int,
	@codigo_pra varchar(20),
	@id_aluno int,
	@id_turma int, 
	@id_dt int,
	@estado varchar(100),
	@progresso varchar(100),
	@id_professor1 int,
	@id_professor2 int,
	@id_professor3 int,
	@id_professor4 int,
	@id_professor5 int,
	@ndisciplinas int,
	@id_dm1 int,
	@id_dm2 int,
	@id_dm3 int,
	@id_dm4 int,
	@id_dm5 int

AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblPra
	where id_pra=@id_pra

	if(@count=0)
		begin
			select -1 as ReturnCode
		End
	Else
	Begin
		update tblPra 
		set id_principal=@id_principal , id_medidas=@id_medidas , id_notificaçoes = @id_notificaçoes,id_decisao=@id_decisao, codigo_pra= @codigo_pra, id_aluno=@id_aluno,id_turma=@id_turma,id_dt=@id_dt,estado=@estado,progresso=@progresso,id_professor1=@id_professor1,id_professor2=@id_professor2,id_professor3=@id_professor3,id_professor4=@id_professor4,id_professor5=@id_professor5, ndisciplinas=@ndisciplinas,id_dm1=@id_dm1,id_dm2=@id_dm2,id_dm3=@id_dm3,id_dm4=@id_dm4,id_dm5=@id_dm5
		where id_pra=@id_pra
		select 1 as ReturnCode
	END
END