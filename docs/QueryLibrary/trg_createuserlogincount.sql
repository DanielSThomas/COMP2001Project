/*Create User Count Trigger*/
IF OBJECT_ID('dbo.trg_CreateLoginCount') IS NOT NULL
    DROP PROCEDURE dbo.trg_CreateLoginCount
GO

Create TRIGGER dbo.trg_CreateLoginCount
ON dbo.Users
AFTER INSERT
AS
BEGIN
declare @UserID INT

SET NOCOUNT ON;

SELECT @UserID = UserID from inserted
INSERT INTO dbo.LoginCounter(UserID)
VALUES(@UserID)

END

