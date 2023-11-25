CREATE PROCEDURE [dbo].[sp_UpdatePrhAlunoAvaliacaoByID]
	@id_avaliaçoes int,
	@avaliaçao_atividade varchar(1000),
	@faltas_desconsideradas varchar(1000),
	@nome_aluno varchar(200),
	@data_assinatura_aluno date,
	@codigo_avaliacao char(65),
	@id_prh int 

AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblAvaliacao
	where id_avaliaçoes=@id_avaliaçoes

	if(@count=0)
		begin
			select -1 as ReturnCode100
		End
	Else
	Begin
		update tblAvaliacao
		set avaliaçao_atividade=@avaliaçao_atividade,faltas_desconsideradas=@faltas_desconsideradas,nome_aluno=@nome_aluno,data_assinatura_aluno=@data_assinatura_aluno,codigo_avaliacao=@codigo_avaliacao,id_prh=@id_prh
		where id_avaliaçoes=@id_avaliaçoes
		select 1 as ReturnCode10
	END
END