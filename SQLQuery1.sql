CREATE DATABASE LibrarySystem;
GO

USE LibrarySystem;
GO

CREATE TABLE Users (
    UserID    INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName  NVARCHAR(50),
    Username  NVARCHAR(50) UNIQUE,
    Password  NVARCHAR(50),
    IsAdmin   BIT
);

CREATE TABLE Books (
    BookID   INT PRIMARY KEY IDENTITY(1,1),
    Title    NVARCHAR(100),
    Author   NVARCHAR(100),
    Quantity INT
);

CREATE TABLE BorrowingTransaction (
    TransactionID INT PRIMARY KEY IDENTITY(1,1),
    UserID        INT FOREIGN KEY REFERENCES Users(UserID),
    BookID        INT FOREIGN KEY REFERENCES Books(BookID),
    BorrowDate    DATE,
    ReturnDate    DATE,
    IsReturned    BIT DEFAULT 0
);

CREATE TABLE BookReturnTransaction (
    ReturnID         INT PRIMARY KEY IDENTITY(1,1),
    TransactionID    INT FOREIGN KEY REFERENCES BorrowingTransaction(TransactionID),
    ActualReturnDate DATE
);

-- Default admin account
INSERT INTO Users (FirstName, LastName, Username, Password, IsAdmin)
VALUES ('Admin', 'User', 'admin', '1234', 1);

-- Sample books
INSERT INTO Books (Title, Author, Quantity) VALUES
('Clean Code', 'Robert C. Martin', 5),
('The Pragmatic Programmer', 'Andrew Hunt', 3),
('Introduction to Algorithms', 'Thomas H. Cormen', 4);
GO