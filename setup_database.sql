CREATE DATABASE [Library];
GO

USE [Library];
GO

CREATE TABLE Users (
    userId INT IDENTITY(1,1) PRIMARY KEY,
    email VARCHAR(MAX),
    username VARCHAR(MAX),
    password VARCHAR(MAX),
    date_register DATE
);

CREATE TABLE Books (
    BookID INT IDENTITY(1,1) PRIMARY KEY,
    Book_Title VARCHAR(MAX),
    Author VARCHAR(MAX),
    Published_Date DATE,
    Book_Status VARCHAR(MAX),
    Date_Insert DATE,
    Date_Update DATE,
    Image VARCHAR(MAX),
    Date_Delete DATE
);

CREATE TABLE IssuesBooks (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    IssueID VARCHAR(MAX),
    Full_Name VARCHAR(MAX),
    Contact VARCHAR(MAX),
    Email VARCHAR(MAX),
    Book_Title VARCHAR(MAX),
    Author VARCHAR(MAX),
    Image VARCHAR(MAX),
    Return_Status VARCHAR(MAX),
    Issue_Date VARCHAR(MAX),
    Return_Date VARCHAR(MAX),
    Date_Update VARCHAR(MAX),
    Insert_Date VARCHAR(MAX)
);
GO
