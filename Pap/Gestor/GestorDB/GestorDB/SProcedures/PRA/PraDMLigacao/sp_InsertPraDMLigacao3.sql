CREATE PROCEDURE [dbo].[sp_InsertPraDMLigacao3]
	@Id_pra_dm int,
	@id_pra int,
	@id_dm int

AS
Begin
	Declare @count int
	SELECT @count= COUNT(Id_pra_dm) FROM tblPraDMLigacao Where Id_pra_dm=@Id_pra_dm

	IF(@count<>0)
	begin 
		select -1 as returnCodePraDMlig3
	End
	Begin
		Insert INTO [dbo].[tblPraDMLigacao]
				([Id_pra_dm],
				[id_pra],
				[id_dm])
		Values (@Id_pra_dm,@id_pra,@id_dm)
		select 1 as returnCodePraDMlig3
	END
END