CREATE PROCEDURE [dbo].[sp_UpdateMedidasByID]
	@id_medidas int,
	@periodo_inicio datetime,
	@periodo_fim datetime,
	@medida varchar(300),
	@cumprimento varchar(50),
	@data_cumprimento date,
	@dever_incumprimento varchar(50),
	@data_incumprimento date,
	@faltas_desconsideradas varchar(300),
	@codemedidas char(60),
	@id_pra int


AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblPraMedidas
	where id_medidas=@id_medidas

	if(@count=0)
		begin
			select -1 as ReturnCode
		End
	Else
	Begin
		update tblPraMedidas 
		set periodo_inicio=@periodo_inicio , periodo_fim=@periodo_fim, medida=@medida, cumprimento=@cumprimento, data_cumprimento=@data_cumprimento, dever_incumprimento=@dever_incumprimento, data_incumprimento=@data_incumprimento ,faltas_desconsideradas=@faltas_desconsideradas, codemedidas=@codemedidas , id_pra=@id_pra
		where id_medidas=@id_medidas
		select 1 as ReturnCode
	END
END