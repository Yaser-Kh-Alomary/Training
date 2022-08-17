
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE UpdateUserAccountStatus 
	@userID nvarchar(200),
	@status int
AS
BEGIN
	
	SET NOCOUNT ON;

    Update dbo.[User]  SET StatusID = @status WHERE UserID=@userID
END
GO
