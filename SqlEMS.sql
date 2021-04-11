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
--INSERT INTO loginInfo VALUES ('admin','1234','ad@gmail.com')
--GO

--SELECT * FROM loginInfo
--GO

--SELECT * FROM loginInfo WHERE userName='admin' or userPassword='slfs'
--GO
CREATE TABLE tblBranch
(
	bId INT IDENTITY(10,1) PRIMARY KEY,
	bCode VARCHAR(20) NOT NULL UNIQUE,
	bNameCode VARCHAR(30) NOT NULL,
	bDistrictName VARCHAR(30) NOT NULL,
	bSubDistrict VARCHAR(30) NOT NULL,
	bAddress VARCHAR(30) NOT NULL
)
GO
--INSERT INTO tblBranch VALUES('BC1003','CHBH03345','Bhola','Charfasson','ch,kalbaxla,hazik palzej 7th f')
--SELECT * FROM tblBranch
--GO
--UPDATE tblBranch SET bCode='',bNameCode='',bDistrictName='',bSubDistrict='',bAddress='' WHERE bId=10
CREATE TABLE tblOfficial
(
	eoId INT PRIMARY KEY NOT NULL,
	eoPrePosition VARCHAR(50) NOT NULL,
	eoPresPosition VARCHAR(50) NOT NULL,
	eoPromPosition VARCHAR(50),
	bId INT REFERENCES tblBranch(bId),
	eoBranch VARCHAR(50) NOT NULL
)
GO

--SELECT * FROM tblOfficial
--GO
--INSERT INTO tblOfficial VALUES(2,'Officer','Senior Officer','Officer Head',11,'Dhaka TTO')
--GO
--SELECT * FROM tblOfficial WHERE eoId=1029
--GO
UPDATE tblOfficial SET eoPrePosition='officer',eoPresPosition='senior officer',eoPromPosition='Officer Head',bId=11,eoBranch='Dhaka ttt' WHERE eoId=1
--DELETE FROM tblOfficial WHERE eoId=1029
--GO
--CREATE TABLE tblGender
--(
--	genderID INT PRIMARY KEY IDENTITY,
--	gender VARCHAR(6) NOT NULL
--)
--GO
--DROP TABLE tblGender
--GO

CREATE TABLE tblAcademic
(
	eaId INT PRIMARY KEY NOT NULL,
	O_level NVARCHAR(40) NOT NULL,
	O_result NVARCHAR(20) NOT NULL,
	A_level NVARCHAR(40) NOT NULL,
	A_result NVARCHAR(20) NOT NULL,
	Intermediate_level NVARCHAR(40) NOT NULL,
	Intermediate_result NVARCHAR(20) NOT NULL,
	eaHons NVARCHAR(40) NOT NULL,
	Hons_result NVARCHAR(20) NOT NULL,
	eaMast NVARCHAR(40) NOT NULL,
	Mast_result NVARCHAR(20) NOT NULL,
	eaSpecial NVARCHAR(50) NOT NULL,
	Special_result NVARCHAR(20) NOT NULL
)
GO

--SELECT eaId FROM tblAcademic
--SELECT * FROM tblAcademic
--GO
--INSERT INTO tblAcademic VALUES('A+','A+','A+','1st Class','1st Class','A+')
--GO
--INSERT INTO tblAcademic VALUES (2,'JSC','A+','SSC','A+','HSC','A','ENGLISH','3.2','ENGLISH','3.5','IT CROUSE','5.00')
--GO
UPDATE tblAcademic SET O_level='JDC',O_result='A',A_level='DHAKIL',A_result='A',Intermediate_level='ALIM',Intermediate_result='A',eaHons='ENGLISH',Hons_result='4.00',eaMast='MATH',Mast_result='4.00',eaSpecial='IT',Special_result='PASS' WHERE eaId=1
GO


CREATE TABLE tblEpersonla
(
	eId INT PRIMARY KEY NOT NULL IDENTITY(100,1),
	eTitle NVARCHAR(10) NOT NULL,
	eName VARCHAR(50) NOT NULL,
	eDob DATE NOT NULL,
	eFatherName VARCHAR(50) NOT NULL,
	eGender VARCHAR(7) NOT NULL,
	eNationalIdNo CHAR(13) UNIQUE NOT NULL CHECK(eNationalIdNo LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	ePhoneNo VARCHAR(15) NOT NULL,
	eEmail VARCHAR(50) NOT NULL,
	eSocialId VARCHAR(50) NOT NULL,
	eMeritals VARCHAR(30) NOT NULL,
	eJoinDate DATE NOT NULL,
	eImage IMAGE,
	eaId INT REFERENCES tblAcademic(eaId),
	eoId INT REFERENCES tblOfficial(eoId),
)
GO
select eImage from tblEpersonla where eId=103
go

--UPDATE tblEpersonla SET eTitle='Mrs',eName='Suma Sintia',eDob='2021-04-13',eFatherName='Kamal Hossen',eGender='Female',eNationalIdNo='1994225465573',ePhoneNo='01787767345',eEmail='su@gmail.com',eSocialId='13131313',eMeritals='Engaged',eJoinDate='2021-04-18',eImage=NULL,eaId=1,eoId=1001 WHERE eId=11
--GO
--DELETE FROM tblEpersonla WHERE eId=11
--GO
--SELECT * FROM tblEpersonla
--GO
--INSERT INTO tblEpersonla VALUES('Mr','Kamal Hossen','10/11/1993','Sumin Hazi Kazi','Male','1994223465578','01735538904','Fiverrwalid@gmail.com','0944345','Single','10/10/2020',NULL,1,1001);
--GO
--DELETE FROM tblEpersonla WHERE eId=110
--GO
CREATE TABLE tblESalary
(
	salaryId INT IDENTITY(1000,1) PRIMARY KEY,
	basicPay INT CHECK(basicPay>=8000) NOT NULL,
	houseRent INT NOT NULL,
	medicalAllowance INT CHECK(medicalAllowance<=1500) NOT NULL DEFAULT 0,
	travle_allowance INT CHECK(travle_allowance<=2000) NOT NULL DEFAULT 0,
	childrenEallwanc INT CHECK(childrenEallwanc<=500) NOT NULL DEFAULT 0,
	grossSalary AS basicPay+houseRent+medicalAllowance+travle_allowance+childrenEallwanc,
	loan INT DEFAULT 0 NOT NULL,
	Gpf_Cpf INT DEFAULT 0 NOT NULL,
	salaryDate DATE NOT NULL DEFAULT GETDATE(),
	eId INT REFERENCES tblEpersonla(eId),
	Cut_from_GrossSalary AS loan+Gpf_Cpf,
	Net_Salary_Paid AS (basicPay+houseRent+medicalAllowance+travle_allowance+childrenEallwanc)-(loan+Gpf_Cpf)
)
GO
drop table tblESalary
go
INSERT INTO tblESalary values (9000,3000,1000,1000,500,10000,40,GETDATE(),103)
go
select * from tblESalary

UPDATE tblESalary(basicpay,houseRent,medicalAllowance,travle_allowance,childrenEallwanc,loan,Gpf_Cpf,salaryDate,eId) SET basicPay=50000,houseRent=4000,medicalAllowance=500,travle_allowance=1000,childrenEallwanc=300,loan=5000,Gpf_Cpf=200,salaryDate='10/10/2020',eId=103 WHERE salaryId=1004
go

update tblESalary SET basicpay=40000,houseRent=4000 where salaryId=1004