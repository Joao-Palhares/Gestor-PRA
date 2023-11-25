CREATE PROCEDURE [dbo].[sp_UpdateProfessorByID]
	@id_professor int,
	@nome char(100),
	@data_nascimento date,
	@dt varchar(100)

AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblProfessores
	where id_professor=@id_professor

	if(@count=0)
		begin
			select -1 as ReturnCode
		End
	Else
	Begin
		update tblProfessores 
		set nome_professor=@nome , data_nascimento=@data_nascimento, dt=@dt
		where id_professor=@id_professor
		select 1 as ReturnCode
	END
END