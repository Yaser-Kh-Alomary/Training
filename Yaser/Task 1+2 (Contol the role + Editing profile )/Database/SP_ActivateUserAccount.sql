
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE ActivateUserAccount 
	@UserId nvarchar(200)=''
AS
BEGIN
	
	SET NOCOUNT ON;

	DECLARE @Result int =0,
	@ErrorMsg nvarchar(max) = ''

	BEGIN Try
	if(@UserId !='' )
	UPDATE dbo.[User]
		SET dbo.[User].StatusID = 2 WHERE  dbo.[User].UserID = @UserId 
	End try

	BEGIN catch
	Set @Result  = 2;
	Set @ErrorMsg = error_message();
	select @Result AS result, @ErrorMsg as message
	End catch
END
GO
