
USE master;
GO

DROP DATABASE IF EXISTS asp_final_project_nissim2;
GO
CHECKPOINT


CREATE DATABASE asp_final_project_nissim2;
GO
CHECKPOINT


USE asp_final_project_nissim2


CREATE TABLE users
(
    
    ID int IDENTITY(1,1) PRIMARY KEY,
    
    FullName VARCHAR(100) NOT NULL,
    
    UserName VARCHAR(100) NOT NULL,
    
    Pwd VARCHAR(100) NOT NULL,
    
    ActionsCounter INT NOT NULL,
    -- last action day
    LastActionDay INT
);




-- Department Table
-- - ID (PK)
-- - Name
-- - Manager (FK to Employee.ID)
CREATE TABLE department
(
    -- department ID as primary key integer starts at 1 with 1 increment
    ID int IDENTITY(1,1) PRIMARY KEY,
    -- department name with 50 characters
    DepName VARCHAR(50) NOT NULL,
    -- Manager ID FK to employees

);

-- Employee Table
-- - ID (PK)
-- - First Name
-- - Last Name
-- - Start Work Year
-- - DepartmentID (FK to Department.ID)
CREATE TABLE employees
(
-- order ID as primary key integer starts at 1000001 with 1 increment
    ID int IDENTITY(1,1) PRIMARY KEY,
-- FirstName string
    FirstName VARCHAR(50) NOT NULL,
-- LasttName string
    LastName VARCHAR(50) NOT NULL,
-- Year start to wirk
    YearStarted INT NOT NULL,
-- product ID as foreign key from users table and ID column rules
    DepID INT FOREIGN KEY REFERENCES department(ID) NOT NULL,
);



-- Add Manager foreign key column ad data
ALTER TABLE department ADD 
    Manager INT FOREIGN KEY REFERENCES employees(ID);
GO
CHECKPOINT

UPDATE department SET Manager=1 WHERE ID=1
UPDATE department SET Manager=6 WHERE ID=2
UPDATE department SET Manager=12 WHERE ID=3




-- Shift Table
-- - ID (PK)
-- - Date (date time)
-- - Start Time (int)
-- - End Time (int)
CREATE TABLE shifts
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ShiftDate DATE,
    StartTime INT,
    EndTime INT
)


-- EmployeeShift Table
-- - ID (PK)
-- - EmployeeID (FK to Employee.ID)
-- - ShiftID (FK to Shift.ID)
CREATE TABLE EmployeeShift
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeID INT FOREIGN KEY REFERENCES employees(ID),
    ShiftID INT FOREIGN KEY REFERENCES shifts(ID)
)
