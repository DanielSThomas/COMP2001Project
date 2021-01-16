IF OBJECT_ID('dbo.usp_deleteuser') IS NOT NULL
    DROP PROCEDURE dbo.usp_deleteuser
GO

CREATE PROCEDURE dbo.usp_deleteuser
@userID INT

AS
BEGIN TRANSACTION
declare @errorMessage INT
declare @errorServerity INT
declare @errorState INT



SET XACT_ABORT ON /*Automaticly Rollback Transaction if a runtime error happens*/

BEGIN TRY

    DELETE FROM dbo.Users WHERE UserID = @userID;
COMMIT TRANSACTION
END TRY

BEGIN CATCH
 ROLLBACK TRANSACTION          
        SET @errorMessage = ERROR_MESSAGE()
        SET @errorServerity = ERROR_SEVERITY()
        SET @errorState = ERROR_STATE()
        RAISERROR(@errorMessage,@errorServerity,@errorState)  
END CATCH      
 




