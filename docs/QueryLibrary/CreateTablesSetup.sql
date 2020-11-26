/* Table Creation */


CREATE TABLE dbo.Users
(
    UserID INT IDENTITY(1,1),
    FirstName VARCHAR(50) NOT NULL CHECK (len(FirstName) >= 3), 
    LastName VARCHAR(50) NOT NULL CHECK (len(LastName) >= 3),
    Email VARCHAR(50) NOT NULL, /*Looking into check for @ character and ends in .co.uk,.com etc*/
    CurrentPassword VARCHAR(50) NOT NULL

    
    UNIQUE (Email),
    UNIQUE (FirstName, LastName),

    CONSTRAINT pk_Users PRIMARY KEY (UserID)
);

CREATE TABLE dbo.Passwords
(
    PasswordID INT IDENTITY(1,1),
    UserID INT NOT NULL,
    PreviousPassword VARCHAR(50) NOT NULL, /* Check user hasn't used password before ? */
    TimeChanged DATETIME NOT NULL

    CONSTRAINT pk_Passwords PRIMARY KEY (PasswordID)

    CONSTRAINT fk_Passwords FOREIGN KEY (UserID)
    REFERENCES dbo.Users(UserID)
); 

CREATE TABLE dbo.Sessions
(
    SessionID INT IDENTITY(1,1),
    UserID INT NOT NULL,
    SessionTime DATETIME NOT NULL

    CONSTRAINT pk_Sessions PRIMARY KEY (SessionID)

    CONSTRAINT fk_Sessions FOREIGN KEY (UserID)
    REFERENCES dbo.Users(UserID)
);
