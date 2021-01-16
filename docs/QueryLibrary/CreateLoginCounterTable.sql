
CREATE TABLE dbo.LoginCounter
(
    UserID INT NOT NULL,
    LoginCount INT NOT NULL DEFAULT 0

    CONSTRAINT pk_LoginCounter PRIMARY KEY (UserID)

    CONSTRAINT fk_LoginCounter FOREIGN KEY (UserID)
    REFERENCES dbo.Users(UserID)
);
