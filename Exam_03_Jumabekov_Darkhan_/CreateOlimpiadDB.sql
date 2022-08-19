DROP DATABASE IF EXISTS Olympiads;
CREATE DATABASE Olympiads; 
USE Olympiads;


DROP TABLE IF EXISTS OlimpiadTypes;
CREATE TABLE OlimpiadTypes
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 OlimpiadType VARCHAR(255) NOT NULL,
);

DROP TABLE IF EXISTS Countries;
CREATE TABLE Countries
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 Country VARCHAR(255) NOT NULL,
);

DROP TABLE IF EXISTS Cities;
CREATE TABLE Cities
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 City VARCHAR(255) NOT NULL,
 IdCountry INT NOT NULL FOREIGN KEY REFERENCES Countries(Id) ON DELETE CASCADE,
);

DROP TABLE IF EXISTS SportTypes;
CREATE TABLE SportTypes
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 SportType VARCHAR(255) NOT NULL,
);

DROP TABLE IF EXISTS Athlets;
CREATE TABLE Athlets
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 IdCountry INT NOT NULL FOREIGN KEY REFERENCES Countries(Id) ON DELETE CASCADE,
 Athlet VARCHAR(255) NOT NULL,
 Birthdate DATE NOT NULL,
 Photo IMAGE DEFAULT (0x00)
);

DROP TABLE IF EXISTS Olimpiads;
CREATE TABLE Olimpiads
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 OlimpiadName VARCHAR(255) NOT NULL,
 IdOlimpiadType INT NOT NULL FOREIGN KEY REFERENCES OlimpiadTypes(Id) ON DELETE CASCADE,
 IdCountry INT NOT NULL FOREIGN KEY REFERENCES Countries(Id) ON DELETE CASCADE,
 IdCity INT NOT NULL FOREIGN KEY REFERENCES Cities(Id),
 Date DATE NOT NULL,
);

DROP TABLE IF EXISTS SportGames;
CREATE TABLE SportGames
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 IdSportType INT NOT NULL FOREIGN KEY REFERENCES SportTypes(Id) ON DELETE CASCADE,
 IdAthlet INT NOT NULL FOREIGN KEY REFERENCES Athlets(Id) ON DELETE CASCADE,
 IdOlimpiad INT NOT NULL FOREIGN KEY REFERENCES Olimpiads(Id),
);

DROP TABLE IF EXISTS Results;
CREATE TABLE Results
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 IdSportGame INT NOT NULL FOREIGN KEY REFERENCES SportGames(Id) ON DELETE CASCADE,
 IdAthletWinner INT NOT NULL FOREIGN KEY REFERENCES Athlets(Id),
);

insert into OlimpiadTypes(OlimpiadType) values ('Зимняя');
insert into OlimpiadTypes(OlimpiadType) values ('Летняя');

insert into Countries(Country) values ('Китай');
insert into Countries(Country) values ('Великобритания');
insert into Countries(Country) values ('Россия');
insert into Countries(Country) values ('Бразилия');
insert into Countries(Country) values ('Австралия');
insert into Countries(Country) values ('Франция');

insert into Cities(City, IdCountry) values ('Пекин', 1);
insert into Cities(City, IdCountry) values ('Лондон', 2);
insert into Cities(City, IdCountry) values ('Сочи', 3);
insert into Cities(City, IdCountry) values ('Сан-Паулу', 4);
insert into Cities(City, IdCountry) values ('Сидней', 5);
insert into Cities(City, IdCountry) values ('Париж', 6);

insert into SportTypes(SportType) values ('Бокс');
insert into SportTypes(SportType) values ('Лыжи');
insert into SportTypes(SportType) values ('Велоспорт');
insert into SportTypes(SportType) values ('Фигурное катание');
insert into SportTypes(SportType) values ('Коньки');
insert into SportTypes(SportType) values ('Плавание');

insert into Athlets(IdCountry, Athlet, Birthdate) values (1, 'Иванов И.И.', '01-01-1990');
insert into Athlets(IdCountry, Athlet, Birthdate) values (2, 'Петров П.П.', '02-02-1991');
insert into Athlets(IdCountry, Athlet, Birthdate) values (3, 'Сидоров С.С.', '03-03-1992');
insert into Athlets(IdCountry, Athlet, Birthdate) values (4, 'Смитт С.С.', '08-08-1993');
insert into Athlets(IdCountry, Athlet, Birthdate) values (5, 'Джон Д.Д.', '09-09-1994');
insert into Athlets(IdCountry, Athlet, Birthdate) values (6, 'Жанполь Р.Р.', '10-10-1995');
insert into Athlets(IdCountry, Athlet, Birthdate) values (1, 'Аманов А.А.', '01-01-1990');
insert into Athlets(IdCountry, Athlet, Birthdate) values (2, 'Сэм С.С.', '02-02-1991');
insert into Athlets(IdCountry, Athlet, Birthdate) values (3, 'Бред Б.Б.', '03-03-1992');
insert into Athlets(IdCountry, Athlet, Birthdate) values (4, 'Самуэль С.С.', '08-08-1993');
insert into Athlets(IdCountry, Athlet, Birthdate) values (5, 'Рикардо Р.Р.', '09-09-1994');
insert into Athlets(IdCountry, Athlet, Birthdate) values (6, 'Титов Т.Т.', '10-10-1995');
insert into Athlets(IdCountry, Athlet, Birthdate) values (1, 'Панов П.П.', '01-01-1990');
insert into Athlets(IdCountry, Athlet, Birthdate) values (2, 'Данилов Д.Д.', '02-02-1991');
insert into Athlets(IdCountry, Athlet, Birthdate) values (3, 'Симон С.С.', '03-03-1992');
insert into Athlets(IdCountry, Athlet, Birthdate) values (4, 'Смитт С.С.', '08-08-1993');
insert into Athlets(IdCountry, Athlet, Birthdate) values (5, 'Котова К.К.', '09-09-1994');
insert into Athlets(IdCountry, Athlet, Birthdate) values (6, 'Мухина М.М.', '10-10-1995');

insert into Olimpiads(OlimpiadName,IdOlimpiadType, IdCountry, IdCity, Date) values ('Пекин-1998', 2, 1, 1, '01-01-1998');
insert into Olimpiads(OlimpiadName, IdOlimpiadType, IdCountry, IdCity, Date) values ('Париж-2002', 2, 6, 6, '10-10-2002');
insert into Olimpiads(OlimpiadName,IdOlimpiadType, IdCountry, IdCity, Date) values ('Пекин-2004', 1, 1, 1, '01-01-2004');
insert into Olimpiads(OlimpiadName,IdOlimpiadType, IdCountry, IdCity, Date) values ('Лондон-2006', 2, 2, 2, '06-06-2006');
insert into Olimpiads(OlimpiadName,IdOlimpiadType, IdCountry, IdCity, Date) values ('Сочи-2008', 1, 3, 3, '10-07-2008');
insert into Olimpiads(OlimpiadName,IdOlimpiadType, IdCountry, IdCity, Date) values ('Сан-Паулу-2010', 2, 4, 4, '11-08-2010');
insert into Olimpiads(OlimpiadName,IdOlimpiadType, IdCountry, IdCity, Date) values ('Сидней-2012', 1, 5, 5, '12-09-2012');
insert into Olimpiads(OlimpiadName,IdOlimpiadType, IdCountry, IdCity, Date) values ('Париж-2000', 1, 6, 6, '06-10-2000');
insert into Olimpiads(OlimpiadName,IdOlimpiadType, IdCountry, IdCity, Date) values ('Пекин-2014', 2, 1, 1, '02-11-2014');
insert into Olimpiads(OlimpiadName,IdOlimpiadType, IdCountry, IdCity, Date) values ('Лондон-2016', 2, 2, 2, '03-12-2016');
insert into Olimpiads(OlimpiadName,IdOlimpiadType, IdCountry, IdCity, Date) values ('Сочи-2018', 2, 3, 3, '04-01-2018');
insert into Olimpiads(OlimpiadName,IdOlimpiadType, IdCountry, IdCity, Date) values ('Сан-Паулу-2020', 2, 4, 4, '05-02-2020');
insert into Olimpiads(OlimpiadName,IdOlimpiadType, IdCountry, IdCity, Date) values ('Сидней-2022', 2, 5, 5, '08-03-2022');

insert into SportGames(IdSportType, IdAthlet, IdOlimpiad) values (1, 1, 1);
insert into SportGames(IdSportType, IdAthlet, IdOlimpiad) values (2, 2, 2);
insert into SportGames(IdSportType, IdAthlet, IdOlimpiad) values (3, 3, 3);
insert into SportGames(IdSportType, IdAthlet, IdOlimpiad) values (4, 4, 4);
insert into SportGames(IdSportType, IdAthlet, IdOlimpiad) values (5, 5, 5);
insert into SportGames(IdSportType, IdAthlet, IdOlimpiad) values (6, 6, 6);
insert into SportGames(IdSportType, IdAthlet, IdOlimpiad) values (1, 1, 7);
insert into SportGames(IdSportType, IdAthlet, IdOlimpiad) values (2, 2, 8);
insert into SportGames(IdSportType, IdAthlet, IdOlimpiad) values (3, 3, 9);
insert into SportGames(IdSportType, IdAthlet, IdOlimpiad) values (4, 4, 10);
insert into SportGames(IdSportType, IdAthlet, IdOlimpiad) values (5, 5, 11);
insert into SportGames(IdSportType, IdAthlet, IdOlimpiad) values (6, 6, 12);
insert into SportGames(IdSportType, IdAthlet, IdOlimpiad) values (1, 1, 13);
insert into SportGames(IdSportType, IdAthlet, IdOlimpiad) values (2, 2, 1);
insert into SportGames(IdSportType, IdAthlet, IdOlimpiad) values (3, 3, 2);
insert into SportGames(IdSportType, IdAthlet, IdOlimpiad) values (4, 4, 3);
insert into SportGames(IdSportType, IdAthlet, IdOlimpiad) values (5, 5, 4);
insert into SportGames(IdSportType, IdAthlet, IdOlimpiad) values (6, 6, 5);
insert into SportGames(IdSportType, IdAthlet, IdOlimpiad) values (1, 1, 6);
insert into SportGames(IdSportType, IdAthlet, IdOlimpiad) values (2, 2, 7);
insert into SportGames(IdSportType, IdAthlet, IdOlimpiad) values (3, 3, 8);
insert into SportGames(IdSportType, IdAthlet, IdOlimpiad) values (4, 4, 9);
insert into SportGames(IdSportType, IdAthlet, IdOlimpiad) values (5, 5, 10);
insert into SportGames(IdSportType, IdAthlet, IdOlimpiad) values (6, 6, 12);

insert into Results(IdSportGame, IdAthletWinner) values (1, 3);
insert into Results(IdSportGame, IdAthletWinner) values (1, 6);
insert into Results(IdSportGame, IdAthletWinner) values (1, 18);
insert into Results(IdSportGame, IdAthletWinner) values (2, 15);
insert into Results(IdSportGame, IdAthletWinner) values (3, 4);
insert into Results(IdSportGame, IdAthletWinner) values (4, 13);
insert into Results(IdSportGame, IdAthletWinner) values (5, 2);
insert into Results(IdSportGame, IdAthletWinner) values (6, 4);
insert into Results(IdSportGame, IdAthletWinner) values (1, 12);
insert into Results(IdSportGame, IdAthletWinner) values (2, 1);
insert into Results(IdSportGame, IdAthletWinner) values (3, 4);
insert into Results(IdSportGame, IdAthletWinner) values (4, 2);
insert into Results(IdSportGame, IdAthletWinner) values (5, 6);
insert into Results(IdSportGame, IdAthletWinner) values (6, 15);
insert into Results(IdSportGame, IdAthletWinner) values (2, 19);
insert into Results(IdSportGame, IdAthletWinner) values (3, 4);
insert into Results(IdSportGame, IdAthletWinner) values (4, 5);
insert into Results(IdSportGame, IdAthletWinner) values (6, 7);
insert into Results(IdSportGame, IdAthletWinner) values (1, 18);
insert into Results(IdSportGame, IdAthletWinner) values (2, 3);
insert into Results(IdSportGame, IdAthletWinner) values (3, 4); 
insert into Results(IdSportGame, IdAthletWinner) values (6, 5);
insert into Results(IdSportGame, IdAthletWinner) values (5, 6);
insert into Results(IdSportGame, IdAthletWinner) values (4, 5);
insert into Results(IdSportGame, IdAthletWinner) values (5, 4);
insert into Results(IdSportGame, IdAthletWinner) values (4, 4);
insert into Results(IdSportGame, IdAthletWinner) values (2, 2);
insert into Results(IdSportGame, IdAthletWinner) values (6, 3);
insert into Results(IdSportGame, IdAthletWinner) values (5, 3);