CREATE DATABASE [laboratorySystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Laboratory_Primary', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Laboratory_Primary.mdf' , SIZE = 16384KB , MAXSIZE = 32768KB , FILEGROWTH = 4096KB ), 
 FILEGROUP [Laboratory_FG1]  DEFAULT
( NAME = N'Laboratory_FG1_Dat1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Laboratory_FG1_Dat1.ndf' , SIZE = 10240KB , MAXSIZE = 16384KB , FILEGROWTH = 1024KB ),
( NAME = N'Laboratory_FG1_Dat2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Laboratory_FG1_Dat2.ndf' , SIZE = 10240KB , MAXSIZE = 16384KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Laboratory_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Laboratory_log.ldf' , SIZE = 10240KB , MAXSIZE = 16384KB , FILEGROWTH = 1024KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF;
GO
USE laboratorySystem;
GO

SELECT 
    file_id, 
    name AS FileName, 
    type_desc AS FileType, 
    physical_name AS FilePath, 
    size/128 AS SizeMB, 
    max_size/128 AS MaxSizeMB, 
    growth/128 AS GrowthMB
FROM sys.master_files
WHERE database_id = DB_ID(N'laboratorySystem');

CREATE TABLE Lab_inf (
    Name NVARCHAR(50) PRIMARY KEY, 
    Address NVARCHAR(50)  
)
ON Laboratory_FG1

CREATE TABLE Lab_Info (
    LabName NVARCHAR(50) PRIMARY KEY,  -- Updated to NVARCHAR to match the foreign key type
    Governorate NVARCHAR(50) NOT NULL,
    City NVARCHAR(50) NOT NULL,
    Street NVARCHAR(50) NOT NULL
);

CREATE TABLE [User] (
    Username NVARCHAR(30) PRIMARY KEY,  
    Lab_Name NVARCHAR(50),  
    Password NVARCHAR(30) CHECK (LEN(Password) >= 10),  
    Role NVARCHAR(30), 
    CONSTRAINT FK_Lab_Name FOREIGN KEY (Lab_Name) REFERENCES Lab_Info (LabName)
        ON UPDATE CASCADE 
        ON DELETE CASCADE
)
ON Laboratory_FG1;






Create table Patient_Test(
Patient_Test_ID INT IDENTITY(1, 1) ,
TestDate date  default getdate(),
constraint PK_Patient_Test_ID primary key (Patient_Test_ID)
)
 CREATE TABLE Patient (
    PatientID INT IDENTITY(1, 1) PRIMARY KEY,             
    Title nVARCHAR(10) not null,                      
    Name nVARCHAR(100) NOT NULL,                          
    RefBy nVARCHAR(50),                     
    Phone nVARCHAR(11) check(len(Phone)='11'),                      
    Gender nVARCHAR(10) NOT NULL,           
    Age INT NOT NULL check(age>0),                       
    AgeUnit nVARCHAR(30) NOT NULL,           
    Date DATE default getdate()                    
);
create TABLE Main_Test_Group (
    GroupID INT IDENTITY(1, 1)  PRIMARY KEY,
    GroupName VARCHAR(100) NOT NULL
);


CREATE TABLE Sub_Test (
    SubTestID INT IDENTITY(1, 1) PRIMARY KEY,
    SubTestName VARCHAR(100) NOT NULL,
    GroupID INT,
    FOREIGN KEY (GroupID) REFERENCES Main_Test_Groups(GroupID) ON UPDATE CASCADE ON DELETE CASCADE
);


--Create ResultValue table
Create table patientResultValue(
resultID INT IDENTITY(1, 1),
testID INT,
patient_id INT,
patient_test_id INT,
 ResultValue VARCHAR(30) default'Result Pending',
constraint PK_Result_ID primary key (resultID)  ,
constraint FK_testID Foreign key (testID) references [dbo].[Sub_Test] (SubTestID)  ON UPDATE CASCADE ON DELETE CASCADE,
constraint FK_Patient_ID Foreign key (patient_id) references Patient (PatientID)  ON UPDATE CASCADE ON DELETE CASCADE,
constraint FK_Patient_Test_ID Foreign key (Patient_Test_ID) references Patient_Test (Patient_Test_ID) ON UPDATE CASCADE ON DELETE CASCADE
)


CREATE TABLE Test_Value (
    ValueID INT  IDENTITY(1,1) PRIMARY KEY,
    SubTestID INT,
    MinValue VARCHAR(30) not null,
    MaxValue VARCHAR(30) not null,
	Age_gender_cat VARCHAR(50) NOT NULL, 
    FOREIGN KEY (SubTestID) REFERENCES Sub_Test(SubTestID)ON UPDATE CASCADE ON DELETE CASCADE
);
