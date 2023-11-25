CREATE TABLE [dbo].[tblUsers]
(
	[id_user] INT NOT NULL PRIMARY KEY IDENTITY,
	[username] VARCHAR(50) NOT NULL,
	[password] CHAR(64) NOT NULL,
	[role] CHAR(2) NOT NULL,
	[is_locked]        BIT           DEFAULT ((0)) NULL,
    [nr_attempts]      INT           DEFAULT ((0)) NULL,
    [locked_date_time] DATETIME      NULL,
    [email] VARCHAR(256) NOT NULL, 
    [EmailConfirmed] BIT NULL, 
    [isfirstlogin] BIT NOT NULL, 
    CONSTRAINT [UK_tblUsers_username] UNIQUE ([username])
)