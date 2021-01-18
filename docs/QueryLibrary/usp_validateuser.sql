/*Insert Customer Procedure*/
IF OBJECT_ID('dbo.usp_validateuser') IS NOT NULL
    DROP PROCEDURE dbo.usp_validateuser
GO

CREATE PROCEDURE dbo.usp_validateuser
@email VARCHAR(50),
@password VARCHAR(50),
@validated INT NULL OUT 

AS
declare @errorMessage INT
declare @errorServerity INT
declare @errorState INT
declare @i INT = 0
declare @idcount INT = 0
declare @currentEmail VARCHAR(50)
declare @currentPassword VARCHAR (50)



    BEGIN TRY
        SELECT @idcount = MAX(UserID) FROM dbo.Users
        
        WHILE @i < @idcount
        BEGIN
        SET @i = @i + 1

        SELECT @currentPassword = currentPassword From dbo.Users
        WHERE UserID = @i

        SELECT @currentEmail = email FROM dbo.Users
        Where UserID = @i
        
        if(@email = @currentEmail and @password = @currentPassword)
        BEGIN
        PRINT 'User Validated'
        SET @validated = 1
        RETURN 1
        END
        
        END
        
        PRINT 'Incorrect Email or Password'   
        SET @validated = 0
        RETURN 0
    END TRY

    BEGIN CATCH      
                 
        SET @errorMessage = ERROR_MESSAGE()
        SET @errorServerity = ERROR_SEVERITY()
        SET @errorState = ERROR_STATE()
        RAISERROR(@errorMessage,@errorServerity,@errorState)         
    END CATCH


GO

EXEC dbo.usp_validateuser 'Johnny@email.com', 'Password123',''