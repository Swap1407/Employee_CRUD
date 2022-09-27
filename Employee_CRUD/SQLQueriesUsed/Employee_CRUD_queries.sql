Create table Employees(
    Id int IDENTITY(1,1) PRIMARY KEY,
    [Name] Varchar(60) Not Null,
    Department Varchar(30) Not Null
);


Create procedure AddEmployee
@Name varchar(60),
@Department varchar(30)
AS
BEGIN
Insert into Employees([Name],Department)
Values(@Name,@Department)
END


Create procedure EditEmployee
@Id int,
@Name varchar(60),
@Department varchar(30)
AS
BEGIN
Update Employees
Set [Name] = @Name, Department = @Department
Where Id = @Id
END


Create procedure DeleteEmployee
@Id int
AS
BEGIN
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