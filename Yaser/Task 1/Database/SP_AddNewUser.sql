USE [Task_1]
GO
/****** Object:  StoredProcedure [dbo].[AddNewUser]    Script Date: 8/8/2022 8:08:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[AddNewUser] 
	-- Add the parameters for the stored procedure here
	@UserID nvarchar(200) ='',
	@Name nvarchar(200) ='',
	@Email nvarchar(200) ='',
	@Phone nvarchar(200) ='',
	@RoleID int =-1,
	@StatusID int =-1
AS
BEGIN
	DECLARE @Result int =0,
@ErrorMsg nvarchar(max) = ''

	BEGIN Try
	if(@UserID !='' AND @Name !='' And @Email !='' AND @Phone !='' AND @RoleID !=-1 AND @StatusID !=-1)
		if(@RoleID = 2)
			INSERT INTO [dbo].[User]
				   ([UserID]
				   ,[Name]
				   ,[Email]
				   ,[Phone]
				   ,[RoleID]
				   ,[StatusID])
			 VALUES
			 (@UserID,@Name,@Email,@Phone,@RoleID,2)

		 if(@RoleID = 3)
			INSERT INTO [dbo].[User]
				   ([UserID]
				   ,[Name]
				   ,[Email]
				   ,[Phone]
				   ,[RoleID]
				   ,[StatusID])
			 VALUES
			 (@UserID,@Name,@Email,@Phone,@RoleID,1)

		
	End try

	BEGIN catch
	Set @Result  = 2;
	Set @ErrorMsg = error_message();
	select @Result AS result, @ErrorMsg as message
	End catch
END
