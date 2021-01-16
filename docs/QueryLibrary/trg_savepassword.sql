/*Create User Count Trigger*/
IF OBJECT_ID('dbo.trg_SavePassword') IS NOT NULL
    DROP TRIGGER dbo.trg_SavePassword
GO

Create TRIGGER dbo.trg_SavePassword
ON dbo.Users
AFTER UPDATE
AS
BEGIN
declare @UserID INT
declare @Password VARCHAR(50)

SET NOCOUNT ON;

SELECT @UserID = UserID from inserted
SELECT @Password = CurrentPassword from deleted


INSERT INTO dbo.Passwords(UserID,PreviousPassword,TimeChanged)
VALUES(@UserID,@Password,CURRENT_TIMESTAMP)

END

