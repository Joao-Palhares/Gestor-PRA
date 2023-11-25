CREATE PROCEDURE [dbo].[sp_InsertPraDMLigacao]
	@id_pra int,
	@id_dm int

AS
Begin
	Declare @count int
	SELECT @count= COUNT(Id_pra_dm) FROM tblPraDMLigacao

	IF(@count<>0)
	begin 
		select -1 as returnCodePraDMlig
	End
	Begin
		Insert INTO [dbo].[tblPraDMLigacao]
				([id_pra],
				[id_dm])
		Values (@id_pra,@id_dm)
		select 1 as returnCodePraDMlig
	END
END