/* Table Creation */


CREATE TABLE dbo.Users
(
    UserID INT IDENTITY(1,1),
    FirstName VARCHAR(50) NOT NULL CHECK (len(FirstName) >= 3), 
    LastName VARCHAR(50) NOT NULL CHECK (len(LastName) >= 3),
    Email VARCHAR(50) NOT NULL,
    CurrentPassword VARCHAR(50) NOT NULL

    UNIQUE (UserID),
    UNIQUE (Email),
    UNIQUE (FirstName, LastName),

    CONSTRAINT pk_Users PRIMARY KEY (UserID)
);

CREATE TABLE dbo.Passwords
(
    UserID INT IDENTITY(1,1),
    PasswordID INT IDENTITY(1,1),
    PreviousPassword VARCHAR(50),
    TimeChanged DATETIME
); 

CREATE TABLE dbo.Sessions
(
    UserID INT IDENTITY(1,1),
    SessionID INT IDENTITY(1,1),
    SessionTime DATETIME
);
