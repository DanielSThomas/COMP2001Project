/*Insert Customer Procedure*/
IF OBJECT_ID('dbo.usp_register') IS NOT NULL
    DROP PROCEDURE dbo.usp_register
GO

CREATE PROCEDURE dbo.usp_register
@newFirstName VARCHAR(50),
@newLastName VARCHAR(50),
@newEmail VARCHAR(50),
@newPassword VARCHAR(50),
@message VARCHAR(200) OUTPUT
AS
BEGIN TRANSACTION
declare @errorMessage INT
declare @errorServerity INT
declare @errorState INT


SET XACT_ABORT ON /*Automaticly Rollback Transaction if a runtime error happens*/
   
IF EXISTS (SELECT 1 FROM dbo.Users WHERE dbo.Users.FirstName = @newFirstName AND dbo.Users.LastName = @newLastName)
    BEGIN
        PRINT 'ERROR: User Name Already Exsits In Database!'
        SET @message = 'Register Failed : User Name Already Exsits In Database!'
        RETURN 
    END
ELSE
    BEGIN TRY
        INSERT INTO dbo.Users (FirstName, LastName, Email, CurrentPassword)
        VALUES (@newFirstName,@newLastName, @newEmail, @newPassword)
        COMMIT TRANSACTION
        SET @message = 'Register Success'
        
    END TRY

    BEGIN CATCH      
        ROLLBACK TRANSACTION          
        SET @errorMessage = ERROR_MESSAGE()
        SET @errorServerity = ERROR_SEVERITY()
        SET @errorState = ERROR_STATE()
        RAISERROR(@errorMessage,@errorServerity,@errorState)
        SET @message = 'Register Failed : General Failure'           
    END CATCH

GO


EXEC dbo.usp_register 'Will2', 'Fisher','ABadEmail3@Email.com','LookaBadW0rdAgain',0
GO

SELECT * FROM dbo.Users;

SELECT * FROM dbo.Passwords;

SELECT * FROM dbo.Sessions;