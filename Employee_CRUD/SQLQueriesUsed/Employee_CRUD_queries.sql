

Create table Employees(
    Id Int Primary Key Not Null,
    Name Varchar(60) Not Null,
    Department Varchar(30) Not Null
);



Create procedure AddEmployee
@Id int,
@Name varchar(60),
@Department varchar(30)
AS
BEGIN
Insert into Employees(Id,Name,Department)
Values(@Id,@Name,@Department)
END

Create procedure SaveEmployee
@Id int,
@Name varchar(60),
@Department varchar(30)
AS
BEGIN
Update Employees
Set Id = @Id, Name = @Name, Department = @Department
Where Id = @Id
END