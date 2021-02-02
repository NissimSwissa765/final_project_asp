
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
-- insert data to the users table, without ID which is created automatically
INSERT INTO users (FullName, UserNAme, Pwd, ActionsCounter, LastActionDay)
    VALUES ('Almighty the Maker of All', 'God', 'ThinSilent', 0, 0);
INSERT INTO users (FullName, UserNAme, Pwd, ActionsCounter, LastActionDay)
    VALUES ('Devil the God Rebel', 'Loki', 'InFlames', 0, 0);



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
-- insert data to the department table, without ID which is created automatically
INSERT INTO department (DepName)
    VALUES ('Infernal');
INSERT INTO department (DepName)
    VALUES ('Heaven');
INSERT INTO department (DepName)
    VALUES ('Fallen');


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


-- insert data to the employees table, without ID which is created automatically
INSERT INTO employees (FirstName, LastName, YearStarted, DepID)
    VALUES ('Lilith', 'The First Woman', 0, 1);
INSERT INTO employees (FirstName, LastName, YearStarted, DepID)
    VALUES ('Naama', 'of Seduction', 10, 1);
INSERT INTO employees (FirstName, LastName, YearStarted, DepID)
    VALUES ('BaalZvuv', 'of Insects', 14, 1);
INSERT INTO employees (FirstName, LastName, YearStarted, DepID)
    VALUES ('Sammael', 'The Venom', 3, 1);
INSERT INTO employees (FirstName, LastName, YearStarted, DepID)
    VALUES ('Abaddon', 'The Destroyer', 20, 1);

INSERT INTO employees (FirstName, LastName, YearStarted, DepID)
    VALUES ('Michael', 'Mercy', 1, 2);
INSERT INTO employees (FirstName, LastName, YearStarted, DepID)
    VALUES ('Barachiel', 'Guardian', 56, 2);
INSERT INTO employees (FirstName, LastName, YearStarted, DepID)
    VALUES ('Gabriel', 'Messenger', 0, 2);
INSERT INTO employees (FirstName, LastName, YearStarted, DepID)
    VALUES ('Israfil', 'Music', 56, 2);
INSERT INTO employees (FirstName, LastName, YearStarted, DepID)
    VALUES ('Zuriel', 'Wisdom', 56, 2);
INSERT INTO employees (FirstName, LastName, YearStarted, DepID)
    VALUES ('Paniel', 'Hope', 56, 2);

INSERT INTO employees (FirstName, LastName, YearStarted, DepID)
    VALUES ('Shemihazah', 'The First Watcher', 2, 3);
INSERT INTO employees (FirstName, LastName, YearStarted, DepID)
    VALUES ('Araqiel', 'of the Signs of the Earth', 55, 3);
INSERT INTO employees (FirstName, LastName, YearStarted, DepID)
    VALUES ('Armaros', 'Enchantments', 44, 3);
INSERT INTO employees (FirstName, LastName, YearStarted, DepID)
    VALUES ('Baraqel', 'Astrology', 20, 3);
INSERT INTO employees (FirstName, LastName, YearStarted, DepID)
    VALUES ('Penemue', 'Secrets of the Wisdom', 0, 3);
INSERT INTO employees (FirstName, LastName, YearStarted, DepID)
    VALUES ('Hazaqiel', 'Meteorology', 98, 3);

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
