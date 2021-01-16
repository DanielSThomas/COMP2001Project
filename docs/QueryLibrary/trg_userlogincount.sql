/*Login Count Trigger*/
IF OBJECT_ID('dbo.trg_UserLoginCount') IS NOT NULL
    DROP PROCEDURE dbo.trg_UserLoginCount
GO

Create TRIGGER dbo.trg_UserLoginCount
ON dbo.Sessions
AFTER INSERT
AS
BEGIN
declare @UserID INT

SET NOCOUNT ON;

SELECT @UserID = UserID from inserted
UPDATE dbo.LoginCounter
SET LoginCount = LoginCount +1
WHERE UserID = @UserID

END

