/*Example Data*/

DBCC CHECKIDENT("dbo.Sessions", RESEED, 0);
DBCC CHECKIDENT("dbo.Passwords", RESEED, 0);
DBCC CHECKIDENT("dbo.Users", RESEED, 0);

DELETE FROM dbo.Sessions
DELETE FROM dbo.Passwords
DELETE FROM dbo.Users

INSERT INTO dbo.Users (FirstName, LastName, Email, CurrentPassword)
VALUES 
('John', 'Smith', 'JSmith@email.co.uk','password'),
('Daniel', 'Weller', 'Someemail@email.com','pass'),
('Miles', 'Spinner', 'MilesSpinner100@email.co.uk','123456789')

INSERT INTO dbo.Passwords (UserID, PreviousPassword, TimeChanged)
VALUES 
('1', 'Smith_John','2020-11-14 16:30:00')

INSERT INTO dbo.Sessions (UserID, SessionTime)
VALUES 
('1', '2020-11-14 16:26:00')

SELECT * FROM dbo.Users;

SELECT * FROM dbo.Passwords;

SELECT * FROM dbo.Sessions;


