USE master
GO

DROP DATABASE IF EXISTS EMS
GO

CREATE DATABASE EMS
ON
(
	NAME= EMS,
	FILENAME='C:\Program Files\Microsoft SQL Server\MSSQL15.MAHMUDSABUJ\MSSQL\DATA\EMS.mdf',
	SIZE=10MB,
	MAXSIZE=1GB,
	FILEGROWTH=10%
)
LOG ON
(
	NAME=EMS_log,
	FILENAME='C:\Program Files\Microsoft SQL Server\MSSQL15.MAHMUDSABUJ\MSSQL\DATA\EMS_log.ldf',
	SIZE=10MB,
	MAXSIZE=1GB,
	FILEGROWTH=10%
)
GO
USE EMS
GO
CREATE TABLE loginInfo
(
	userName VARCHAR(30) NOT NULL,
	userPassword VARCHAR(10) NOT NULL,
	userEmail VARCHAR(30) NOT NULL
)
Go
--INSERT INTO loginInfo VALUES ('admin','ad1234','ad@gmail.com')
--GO

--SELECT * FROM loginInfo
--GO

--SELECT * FROM loginInfo WHERE userName='admin' or userPassword='slfs'
--GO
CREATE TABLE tblOfficial
(
	eoId INT IDENTITY(1000,1) PRIMARY KEY,
	eoBcode VARCHAR(50) UNIQUE,
	eoPrePosition VARCHAR(50) NOT NULL,
	eoPresPosition VARCHAR(50) NOT NULL,
	eoPromPosition VARCHAR(50),
	eoBranch VARCHAR(50) NOT NULL
)
GO
--SELECT * FROM tblOfficial
--GO
--INSERT INTO tblOfficial VALUES('BC8848','Officer','Senior Officer','Officer Head','CMtio32')
--GO
--SELECT * FROM tblOfficial WHERE eoId=1000
--GO
--UPDATE tblOfficial SET eoBcode='BC3456',eoPrePosition='Senior Officer',eoPresPosition='Officer',eoPromPosition='Officer Head',eoBranch='CKito454' WHERE eoId=1000
--GO
--DELETE FROM tblOfficial WHERE eoId=1000
--GO
CREATE TABLE tblGender
(
	genderID INT PRIMARY KEY IDENTITY,
	gender VARCHAR(6) NOT NULL
)
GO

CREATE TABLE tblAcademic
(
	eaId INT PRIMARY KEY NOT NULL IDENTITY,
	eaJsc NVARCHAR(20) NOT NULL,
	eaSsc NVARCHAR(20) NOT NULL,
	eaHsc NVARCHAR(20) NOT NULL,
	eaHons NVARCHAR(20) NOT NULL,
	eaMast NVARCHAR(20) NOT NULL,
	eaSpecial NVARCHAR(20) NOT NULL,
)
GO
CREATE TABLE tblEpersonla
(
	eId INT PRIMARY KEY NOT NULL IDENTITY (100,1),
	eTitle NVARCHAR(10) NOT NULL,
	eName VARCHAR(50) NOT NULL,
	eDob DATE NOT NULL,
	--eGender VARCHAR(7) NOT NULL,
	eNationalIdNo CHAR(13) UNIQUE NOT NULL CHECK(eNationalIdNo LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	ePhoneNo VARCHAR(15) NOT NULL,
	eEmail VARCHAR(50) NOT NULL,
	eSocialId VARCHAR(50) NOT NULL,
	eJoinDate DATE NOT NULL,
	eImage IMAGE NOT NULL,
)
GO
