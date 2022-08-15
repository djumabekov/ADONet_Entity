DROP DATABASE IF EXISTS ComputerClub;
CREATE DATABASE ComputerClub; 
USE ComputerClub;

DROP TABLE IF EXISTS Halls;
CREATE TABLE Halls
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 Name VARCHAR(255) NOT NULL,
);

DROP TABLE IF EXISTS Products;
CREATE TABLE Products
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 Name VARCHAR(255) NOT NULL,
);

DROP TABLE IF EXISTS Employees;
CREATE TABLE Employees
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 Name VARCHAR(255) NOT NULL,
);

DROP TABLE IF EXISTS Visitors;
CREATE TABLE Visitors
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 Name VARCHAR(255) NOT NULL,
 Date Date NOT NULL,
 VisitTime Time NOT NULL,
 Duration Time NOT NULL,
 IdHall INT NOT NULL FOREIGN KEY REFERENCES Halls(Id),
);

DROP TABLE IF EXISTS EmployeeSchedule;
CREATE TABLE EmployeeSchedule
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 Date Date NOT NULL,
 IdEmployee INT NOT NULL FOREIGN KEY REFERENCES Employees(Id),
 TimeStart Time NOT NULL,
 TimeEnd Time NOT NULL,
);

DROP TABLE IF EXISTS Orders;
CREATE TABLE Orders
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 IdVisitor INT NOT NULL FOREIGN KEY REFERENCES Visitors(Id),
 IdProduct INT NOT NULL FOREIGN KEY REFERENCES Products(Id),
);

insert into Halls (Name) values ('Green');
insert into Halls (Name) values ('Blue');
insert into Halls (Name) values ('Red');

insert into Products (Name) values ('Drink');
insert into Products (Name) values ('Chips');
insert into Products (Name) values ('Sigarets');
insert into Products (Name) values ('Beer');
insert into Products (Name) values ('Burger');

insert into Employees(Name) values ('Иванов И.И.');
insert into Employees(Name) values ('Петров П.П.');
insert into Employees(Name) values ('Сидоров С.С.');

insert into Visitors(Name, Date, VisitTime, Duration, IdHall) values ('Петренко П.П.', '05-06-2022', '06:40', '01:10', 1);
insert into Visitors(Name, Date, VisitTime, Duration, IdHall) values ('Омаров О.О.', '06-06-2022', '12:10', '02:50', 2);
insert into Visitors(Name, Date, VisitTime, Duration, IdHall) values ('Ахметов А.А.', '07-06-2022', '00:40', '03:30', 3);
insert into Visitors(Name, Date, VisitTime, Duration, IdHall) values ('Арманов А.А.', '08-06-2022', '18:20', '00:30', 1);
insert into Visitors(Name, Date, VisitTime, Duration, IdHall) values ('Саматов С.С.', '09-06-2022', '03:45', '02:10', 2);
insert into Visitors(Name, Date, VisitTime, Duration, IdHall) values ('Абаев А.А.', '10-06-2022', '21:20', '01:50', 3);

insert into EmployeeSchedule(Date, IdEmployee, TimeStart, TimeEnd) values ('05-06-2022', 1, '09:00', '23:59');
insert into EmployeeSchedule(Date, IdEmployee, TimeStart, TimeEnd) values ('06-06-2022', 2, '00:00', '09:00');
insert into EmployeeSchedule(Date, IdEmployee, TimeStart, TimeEnd) values ('07-06-2022', 3, '09:00', '23:59');
insert into EmployeeSchedule(Date, IdEmployee, TimeStart, TimeEnd) values ('08-06-2022', 1, '00:00', '09:00');
insert into EmployeeSchedule(Date, IdEmployee, TimeStart, TimeEnd) values ('09-06-2022', 2, '09:00', '23:59');
insert into EmployeeSchedule(Date, IdEmployee, TimeStart, TimeEnd) values ('10-06-2022', 3, '00:00', '09:00');

insert into Orders(IdVisitor, IdProduct) values (1, 1);
insert into Orders(IdVisitor, IdProduct) values (2, 2);
insert into Orders(IdVisitor, IdProduct) values (3, 3);
insert into Orders(IdVisitor, IdProduct) values (4, 1);
insert into Orders(IdVisitor, IdProduct) values (5, 2);
insert into Orders(IdVisitor, IdProduct) values (6, 3);
insert into Orders(IdVisitor, IdProduct) values (1, 3);
insert into Orders(IdVisitor, IdProduct) values (2, 1);
insert into Orders(IdVisitor, IdProduct) values (3, 2);
insert into Orders(IdVisitor, IdProduct) values (4, 3);
insert into Orders(IdVisitor, IdProduct) values (5, 1);
insert into Orders(IdVisitor, IdProduct) values (6, 2);




