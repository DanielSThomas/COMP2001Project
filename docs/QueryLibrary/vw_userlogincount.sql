
IF OBJECT_ID('dbo.vw_userlogincount', 'v') IS NOT NULL
    DROP VIEW dbo.vw_userlogincount
GO

CREATE VIEW dbo.vw_userlogincount AS
SELECT dbo.Users.FirstName, dbo.Users.LastName, dbo.Users.Email, dbo.Users.CurrentPassword, dbo.LoginCounter.LoginCount
From dbo.Users
RIGHT JOIN dbo.LoginCounter
ON LoginCounter.UserID = Users.UserID;
GO

SELECT * FROM dbo.vw_userlogincount;


