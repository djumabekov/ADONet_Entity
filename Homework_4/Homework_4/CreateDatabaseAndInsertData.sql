
DROP DATABASE IF EXISTS SpainFootballChampionship;
CREATE DATABASE SpainFootballChampionship; 

Use SpainFootballChampionship

DROP TABLE IF EXISTS Countries;
CREATE TABLE Countries
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 Country VARCHAR(100) NOT NULL,
);

DROP TABLE IF EXISTS Cities;
CREATE TABLE Cities
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 City VARCHAR(100) NOT NULL,
);

DROP TABLE IF EXISTS Stadiums;

CREATE TABLE Stadiums
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 Stadium VARCHAR(100) NOT NULL,
 Capacity INT NOT NULL
);

DROP TABLE IF EXISTS Clubs;
CREATE TABLE Clubs
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 Club VARCHAR(100) NOT NULL,
 IdCities INT NOT NULL FOREIGN KEY REFERENCES Cities(Id),
 IdStadiums INT NOT NULL FOREIGN KEY REFERENCES Stadiums(Id),
);

DROP TABLE IF EXISTS Players;
CREATE TABLE Players
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 Name VARCHAR(100) NOT NULL,
 IdClubs INT NOT NULL FOREIGN KEY REFERENCES Clubs(Id),
 Number INT NOT NULL,
 Position VARCHAR(100) NOT NULL,
 IdCountries INT NOT NULL FOREIGN KEY REFERENCES Countries(Id),
);

DROP TABLE IF EXISTS Games;
CREATE TABLE Games
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 IdFirstClub INT NOT NULL FOREIGN KEY REFERENCES Clubs(Id),
 IdSecondClub INT NOT NULL FOREIGN KEY REFERENCES Clubs(Id),
 FirstClubGoals INT NOT NULL,
 SecondClubGoals INT NOT NULL,
 PlayersWhoGoals VARCHAR(100),
 GameDate DATE NOT NULL,
);

insert into Countries (Country) values ('Portugal');
insert into Countries (Country) values ('Argentina');
insert into Countries (Country) values ('Brazil');
insert into Countries (Country) values ('Serbia');
insert into Countries (Country) values ('France');
insert into Countries (Country) values ('Russia');
insert into Countries (Country) values ('Germany');
insert into Countries (Country) values ('Italy');

insert into Cities (City) values ('Madrid');
insert into Cities (City) values ('Barcelona');
insert into Cities (City) values ('Valencia');
insert into Cities (City) values ('Sevilia');

insert into Stadiums (Stadium, Capacity) values ('Santiago Bernabeu', 100000);
insert into Stadiums (Stadium, Capacity) values ('Camp Nou', 90000);
insert into Stadiums (Stadium, Capacity) values ('Mestalla', 80000);
insert into Stadiums (Stadium, Capacity) values ('Ramon Sanchez Pizjuan', 70000);

insert into Clubs (Club, IdCities, IdStadiums) values ('Real', 1, 1);
insert into Clubs (Club, IdCities, IdStadiums) values ('Barcelona', 2, 2);
insert into Clubs (Club, IdCities, IdStadiums) values ('Valencia', 3, 3);
insert into Clubs (Club, IdCities, IdStadiums) values ('Betis', 4, 4);

insert into PLayers (Name, IdClubs, Number, Position, IdCountries) values ('Ronaldo', 1, 7, 'Forward', 1);
insert into PLayers (Name, IdClubs, Number, Position, IdCountries) values ('Zidan', 1, 11, 'Midfielder', 5);
insert into PLayers (Name, IdClubs, Number, Position, IdCountries) values ('Messi', 2, 10, 'Forward', 2);
insert into PLayers (Name, IdClubs, Number, Position, IdCountries) values ('Arshavin', 2, 6, 'Midfielder', 6);
insert into PLayers (Name, IdClubs, Number, Position, IdCountries) values ('Carlos', 3, 9, 'Goalkeaper', 3);
insert into PLayers (Name, IdClubs, Number, Position, IdCountries) values ('Muller', 3, 8, 'Forward', 7);
insert into PLayers (Name, IdClubs, Number, Position, IdCountries) values ('Buffon', 4, 1, 'Goalkeaper', 8);
insert into PLayers (Name, IdClubs, Number, Position, IdCountries) values ('Maximovich', 4, 3, 'Defender', 4);

insert into Games (IdFirstClub, IdSecondClub, FirstClubGoals, SecondClubGoals, PlayersWhoGoals, GameDate) values (1, 2, 2, 1, 'Ronaldo, Messi, Zidan', '01-01-2022');
insert into Games (IdFirstClub, IdSecondClub, FirstClubGoals, SecondClubGoals, PlayersWhoGoals, GameDate) values (2, 1, 0, 1, 'Zidan', '07-02-2022');
insert into Games (IdFirstClub, IdSecondClub, FirstClubGoals, SecondClubGoals, PlayersWhoGoals, GameDate) values (3, 4, 2, 0, 'Carlos, Muller', '05-06-2022');
insert into Games (IdFirstClub, IdSecondClub, FirstClubGoals, SecondClubGoals, PlayersWhoGoals, GameDate) values (4, 3, 1, 1, 'Muller, Maximovich', '11-08-2022');
insert into Games (IdFirstClub, IdSecondClub, FirstClubGoals, SecondClubGoals, PlayersWhoGoals, GameDate) values (1, 4, 2, 0, 'Ronaldo, Buffon', '03-03-2022');
insert into Games (IdFirstClub, IdSecondClub, FirstClubGoals, SecondClubGoals, PlayersWhoGoals, GameDate) values (2, 3, 1, 2, 'Messi, Carlos, Muller', '03-03-2022');
insert into Games (IdFirstClub, IdSecondClub, FirstClubGoals, SecondClubGoals, PlayersWhoGoals, GameDate) values (2, 4, 2, 1, 'Messi, Arshavin, Maximovich', '05-05-2022');
insert into Games (IdFirstClub, IdSecondClub, FirstClubGoals, SecondClubGoals, PlayersWhoGoals, GameDate) values (1, 3, 1, 1, 'Carlos, Buffon', '04-02-2022');
