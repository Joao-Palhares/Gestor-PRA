CREATE PROCEDURE [dbo].[sp_InsertDecisao]
	@data_conselho date,
	@decisao_code char(61)

AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_decisao) FROM tblDecisao

	IF(@count<>0)
	begin 
		select -1 as ReturnCode1
	End
	Begin
		Insert INTO [dbo].[tblDecisao]
				([data_conselho],
				[decisao_code])
		Values (@data_conselho,@decisao_code)
		select 1 as ReturnCode1
	END
END
