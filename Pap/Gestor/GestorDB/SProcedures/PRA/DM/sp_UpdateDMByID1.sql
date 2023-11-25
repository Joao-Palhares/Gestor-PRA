CREATE PROCEDURE [dbo].[sp_UpdateDMByID1]
	@id_dm int,
	@disciplina_modulo int,
	@faltas_excesso int,
	@assinatura_professor_disciplina varchar(50),
	@data_assinatura date,
	@avaliaçao varchar(50),
	@retido varchar(50),
	@id_pra int,
	@dmcode char(50),
	@id_professor int

AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblPraDM
	where id_dm=@id_dm

	if(@count=0)
		begin
			select -1 as ReturnCode
		End
	Else
	Begin
		update tblPraDM 
		set disciplina_modulo=@disciplina_modulo , faltas_excesso = @faltas_excesso, assinatura_professor_disciplina = @assinatura_professor_disciplina, data_assinatura= @data_assinatura, avaliaçao = @avaliaçao, retido=@retido, id_pra=@id_pra, dmcode=@dmcode, id_professor=@id_professor
		where id_dm=@id_dm
		select 1 as ReturnCode
	END
END