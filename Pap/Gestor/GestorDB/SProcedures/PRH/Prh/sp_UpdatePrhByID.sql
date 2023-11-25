CREATE PROCEDURE [dbo].[sp_UpdatePrhByID]
	@id_prh int,
	@id_principal int,
	@id_descricao_atividade int,
	@codigo_prh char(70),
	@id_professor int,
	@id_aluno int,
	@id_turma int,
	@id_dt int,
	@id_avaliaçoes int,
	@estado varchar(50),
	@progresso varchar(100)
AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblPrh
	where id_prh=@id_prh

	if(@count=0)
		begin
			select -1 as ReturnCode100
		End
	Else
	Begin
		update tblPrh 
		set id_principal=@id_principal,id_descricao_atividade=@id_descricao_atividade,id_avaliaçoes=@id_avaliaçoes,codigo_prh=@codigo_prh,id_professor=@id_professor,id_aluno=@id_aluno,id_turma=@id_turma,id_dt=@id_dt,estado=@estado, progresso=@progresso
		where id_prh=@id_prh
		select 1 as ReturnCode10
	END
END