CREATE PROCEDURE [dbo].[sp_AuthenticateUser]
	@username varchar(50),
	@password char(64)

AS
BEGIN
	declare @countuser int

	Select @countuser = COUNT(*) From tblUsers Where username= @username

	IF(@countuser <> 0) -- verifica se o username está registado
		BEGIN
			DECLARE @is_locked bit				-- 0 - não bloqueado; 1 - bloqueado
			DECLARE @nr_attempts int			--nº de tentativas falhadas
			DECLARE @locked_date_time datetime
			declare @count1 int

			select @locked_date_time = locked_date_time, @nr_attempts = nr_attempts, @is_locked = is_locked from tblUsers where username = @username
			
			
			if(@is_locked = 1)
				begin 
					declare @a int
					select @a = DATEDIFF(Hour,@locked_date_time,GETDATE())
					if(@a >= 1)
						begin
							update tblUsers set is_locked=0, nr_attempts=0, locked_date_time=null where username = @username
							set @is_locked = 0
						end
				end

			if(@is_locked = 0)
				begin
					select @count1 = Count(*) from tblUsers where username = @username and password = @password
						if(@count1 = 0)
							begin
								if(@nr_attempts >= 3)
									begin
										update tblUsers set is_locked = 1, nr_attempts = 0, locked_date_time = GETDATE() where username = @username
									end
								else
									begin
										update tblUsers set nr_attempts = nr_attempts + 1 where username = @username
									end
							end
						else
							begin
								update tblUsers set is_locked = 0, locked_date_time = null, nr_attempts = 0 where username = @username
							end
				end
		end
		select * from tblUsers where username = @username
END