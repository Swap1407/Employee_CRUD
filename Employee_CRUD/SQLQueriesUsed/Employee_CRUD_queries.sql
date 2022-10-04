use Employee_Data;
Create table Employees(
    Id int IDENTITY(1,1) PRIMARY KEY,
    [Name] Varchar(60) Not Null,
    Department Varchar(30) Not Null
);

select * from Employees;

Alter procedure AddEmployee
@Name varchar(60),
@Department varchar(30),
@EmployeeId int Out,
@EmployeeName varchar(60) Out,
@EmployeeDepartment varchar(30) Out
AS
BEGIN
Insert into Employees([Name],Department) Values(@Name,@Department)
SELECT @EmployeeId = SCOPE_IDENTITY()
SELECT @EmployeeName = [Name], @EmployeeDepartment = Department FROM Employees Where Id = @EmployeeId
END

Alter procedure EditEmployee
@Id int,
@Name varchar(60),
@Department varchar(30),
@EmployeeId int Out,
@EmployeeName varchar(60) Out,
@EmployeeDepartment varchar(30) Out
AS
BEGIN
Update Employees
Set [Name] = @Name, Department = @Department
Where Id = @Id
SELECT @EmployeeId = Id, @EmployeeName = [Name], @EmployeeDepartment = Department FROM Employees Where Id = @Id
END

Alter procedure DeleteEmployee
@Id int,
@EmployeeId int Out,
@EmployeeName varchar(60) Out,
@EmployeeDepartment varchar(30) Out
AS
BEGIN
SELECT @EmployeeId = @Id
SELECT @EmployeeName = [Name], @EmployeeDepartment = Department FROM Employees Where Id = @EmployeeId
Delete from Employees Where Id = @Id
END

Create procedure GetAllEmployees
AS
BEGIN
Select Id, [Name], Department From Employees
END


Create procedure GetEmployee
@Id int
AS
BEGIN
Select Id, [Name], Department From Employees Where Id = @Id
END