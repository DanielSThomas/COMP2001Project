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
declare @OldPassword VARCHAR(50)
declare @NewPassword VARCHAR(50)

SET NOCOUNT ON;

SELECT @UserID = UserID from inserted
SELECT @OldPassword = CurrentPassword from deleted
SELECT @NewPassword = CurrentPassword from inserted

if (@OldPassword = @NewPassword)
BEGIN
RETURN
END

if (@NewPassword = '')
BEGIN
RETURN
END

INSERT INTO dbo.Passwords(UserID,PreviousPassword,TimeChanged)
VALUES(@UserID,@OldPassword,CURRENT_TIMESTAMP)

END

