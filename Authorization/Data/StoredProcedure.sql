USE [DemoProduct]
GO
/****** Object:  StoredProcedure [dbo].[UserCheck]    Script Date: 3/5/2021 9:58:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserCheck]
	@Email varchar(100)
AS
	SELECT * FROM Users WHERE Email = @Email;
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[UserCreate]    Script Date: 3/5/2021 9:58:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserCreate]   
    @FirstName nvarchar(50),
	@LastName nvarchar(50),   
	@Email varchar(100),
	@PasswordHash varchar(100)
AS   

	INSERT INTO Users (FirstName,LastName,Email,PasswordHash)
	VALUES (@FirstName,@LastName,@Email,@PasswordHash);
GO
