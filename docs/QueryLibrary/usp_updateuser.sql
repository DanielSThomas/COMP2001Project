IF OBJECT_ID('dbo.usp_updateuser') IS NOT NULL
    DROP PROCEDURE dbo.usp_updateuser
GO

CREATE PROCEDURE dbo.usp_updateuser
@userID INT,
@newFirstName VARCHAR(50) = NULL,
@newLastName VARCHAR(50) = NULL,
@newEmail VARCHAR(50) = NULL,
@newPassword VARCHAR(50) = NULL

AS
BEGIN TRANSACTION
declare @errorMessage INT
declare @errorServerity INT
declare @errorState INT



SET XACT_ABORT ON /*Automaticly Rollback Transaction if a runtime error happens*/

BEGIN TRY


    IF (@newFirstName IS NOT NULL AND @newFirstName != '')
    BEGIN
        UPDATE dbo.Users
        SET FirstName = @newFirstName
        WHERE UserID = @userID
    END

    IF (@newLastName IS NOT NULL AND @newLastName != '')
     BEGIN
        UPDATE dbo.Users
        SET LastName = @newLastName
        WHERE UserID = @userID
    END

    IF (@newEmail IS NOT NULL AND @newEmail != '')
     BEGIN
        UPDATE dbo.Users
        SET Email = @newEmail
        WHERE UserID = @userID
    END

    IF (@newPassword IS NOT NULL AND @newPassword != '')
     BEGIN
        UPDATE dbo.Users
        SET CurrentPassword = @newPassword
        WHERE UserID = @userID
    END

COMMIT TRANSACTION
END TRY

BEGIN CATCH
 ROLLBACK TRANSACTION          
        SET @errorMessage = ERROR_MESSAGE()
        SET @errorServerity = ERROR_SEVERITY()
        SET @errorState = ERROR_STATE()
        RAISERROR(@errorMessage,@errorServerity,@errorState)  
END CATCH      

        
GO
SELECT * FROM dbo.Users;




