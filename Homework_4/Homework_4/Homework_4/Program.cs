using System;
using System.Linq;

namespace Homework_4
{
  internal class Program
  {
    static void Main(string[] args)
    {

      using (SpainFootballChampionshipEntities db = new SpainFootballChampionshipEntities())
      {
        //Задание 2
        //Добавьте новую функциональность к проекту чемпионат Испании по футболу:

        //Покажите разницу забитых и пропущенных голов для каждой команды;
        Console.WriteLine("\nПокажите разницу забитых и пропущенных голов для каждой команды: ");
        var games = db.Games.ToList();
        var clubs = db.Clubs.ToList();

        for (int i = 0; i < clubs.Count; i++)
        {
          var IdClub = clubs[i].Id;
          var clubName = db.Clubs.FirstOrDefault(x => x.Id == IdClub).Club;
          int scoredGoals = 0;
          int missedGoals = 0;
          for (int j = 0; j < games.Count; j++)
          {
            if (games[j].IdFirstClub == IdClub)
            {
              scoredGoals += games[j].FirstClubGoals;
              missedGoals += games[j].SecondClubGoals;
            }
            if (games[j].IdSecondClub == IdClub)
            {
              scoredGoals += games[j].SecondClubGoals;
              missedGoals += games[j].FirstClubGoals;
            }
          }
          Console.WriteLine("Клуб: " + clubName + ", Забито: " + scoredGoals + ", Пропущено: " + missedGoals);
        }


        //Покажите полную информацию о матче;
        Console.WriteLine("\nПокажите полную информацию о матче: ");
        Console.WriteLine(new string('-', 3 + 20 + 7 + 30 + 10 + 5));
        Console.WriteLine("|{0,3}|{1,20}|{2,7}|{3,30}|{4,10}|", "Id", "Game", "Score", "WhoGoals", "Date");
        Console.WriteLine(new string('-', 3 + 20 + 7 + 30 + 10 + 5));
        foreach (var game in games)
        {
          var firstClubName = db.Clubs.FirstOrDefault(x => x.Id == game.IdFirstClub).Club;
          var secondClubName = db.Clubs.FirstOrDefault(x => x.Id == game.IdSecondClub).Club;
          Console.WriteLine("|{0,3}|{1,20}|{2,7}|{3,30}|{4,10}|", game.Id, firstClubName + " - " + secondClubName, game.FirstClubGoals + " - " + game.SecondClubGoals, game.PlayersWhoGoals, game.GameDate.ToString("d"));
        }

        //Покажите информацию о матчах в конкретную дату;
        var date = new DateTime(2022, 1, 1);
        var gameOnDate = db.Games.Where(x => x.GameDate == date).FirstOrDefault();

        Console.WriteLine("\nПокажите информацию о матчах в конкретную дату " + date.ToString("d") + ": ");
        Console.WriteLine(new string('-', 3 + 20 + 7 + 30 + 10 + 5));
        Console.WriteLine("|{0,3}|{1,20}|{2,7}|{3,30}|{4,10}|", "Id", "Game", "Score", "WhoGoals", "Date");
        Console.WriteLine(new string('-', 3 + 20 + 7 + 30 + 10 + 5));
        if (gameOnDate != null)
        {
          var firstClubName = db.Clubs.FirstOrDefault(x => x.Id == gameOnDate.IdFirstClub).Club;
          var secondClubName = db.Clubs.FirstOrDefault(x => x.Id == gameOnDate.IdSecondClub).Club;
          Console.WriteLine("|{0,3}|{1,20}|{2,7}|{3,30}|{4,10}|", gameOnDate.Id, firstClubName + " - " + secondClubName, gameOnDate.FirstClubGoals + " - " + gameOnDate.SecondClubGoals, gameOnDate.PlayersWhoGoals, gameOnDate.GameDate.ToString("d"));
        }

        //Покажите все матчи конкретной команды;
        var IdClub2 = 1;
        var clubName2 = db.Clubs.Where(x => x.Id == IdClub2).FirstOrDefault().Club;
        var gamesOfClub = db.Games.Where(x => (x.IdFirstClub == IdClub2 || x.IdSecondClub == IdClub2)).ToList();
        Console.WriteLine("\nПокажите все матчи конкретной команды " + clubName2 + ": ");
        Console.WriteLine(new string('-', 3 + 20 + 7 + 30 + 10 + 5));
        Console.WriteLine("|{0,3}|{1,20}|{2,7}|{3,30}|{4,10}|", "Id", "Game", "Score", "WhoGoals", "Date");
        Console.WriteLine(new string('-', 3 + 20 + 7 + 30 + 10 + 5));
        foreach (var game in gamesOfClub)
        {
          var firstClubName = db.Clubs.FirstOrDefault(x => x.Id == game.IdFirstClub).Club;
          var secondClubName = db.Clubs.FirstOrDefault(x => x.Id == game.IdSecondClub).Club;
          Console.WriteLine("|{0,3}|{1,20}|{2,7}|{3,30}|{4,10}|", game.Id, firstClubName + " - " + secondClubName, game.FirstClubGoals + " - " + game.SecondClubGoals, game.PlayersWhoGoals, game.GameDate.ToString("d"));
        }

        //Покажите всех игроков, которые забили голы в конкретную дату.
        date = new DateTime(2022, 3, 3);
        var playersWhoGoalsOnDate = db.Games.Where(x => x.GameDate == date).FirstOrDefault();

        Console.WriteLine("\nПокажите всех игроков, которые забили голы в конкретную дату " + date.ToString("d") + ": ");
        if (playersWhoGoalsOnDate != null)
        {
          Console.WriteLine(playersWhoGoalsOnDate.PlayersWhoGoals);
        }

        // Задание 3 Добавьте новую функциональность к проекту чемпионат Испании по футболу:

        //Добавление информации о матче. Перед добавлением нужно проверить не существует ли уже такая информация;
        Console.WriteLine("\nДобавление информации о матче. Перед добавлением нужно проверить не существует ли уже такая информация: ");

        var newGame = new Games()
        {
          IdFirstClub = 3,
          IdSecondClub = 2,
          FirstClubGoals = 2,
          SecondClubGoals = 1,
          PlayersWhoGoals = "Messi, Arshavin, Carlos",
          GameDate = new DateTime(2022, 4, 15)
        };

        var game2 = db.Games.Where(x => x.IdFirstClub == newGame.IdFirstClub && x.IdSecondClub == newGame.IdSecondClub && x.GameDate == newGame.GameDate).FirstOrDefault();

        if (game2 == null)
        {
          db.Games.Add(newGame);
          db.SaveChanges();
          var createdGame = db.Games.ToList().Last();
          var firstClubName = db.Clubs.FirstOrDefault(x => x.Id == createdGame.IdFirstClub).Club;
          var secondClubName = db.Clubs.FirstOrDefault(x => x.Id == createdGame.IdSecondClub).Club;
          Console.WriteLine(new string('-', 3 + 20 + 7 + 30 + 10 + 5));
          Console.WriteLine("|{0,3}|{1,20}|{2,7}|{3,30}|{4,10}|", "Id", "Game", "Score", "WhoGoals", "Date");
          Console.WriteLine(new string('-', 3 + 20 + 7 + 30 + 10 + 5));
          Console.WriteLine("|{0,3}|{1,20}|{2,7}|{3,30}|{4,10}|", createdGame.Id, firstClubName + " - " + secondClubName, createdGame.FirstClubGoals + " - " + createdGame.SecondClubGoals, createdGame.PlayersWhoGoals, createdGame.GameDate.ToString("d"));
        }
        else
        {
          Console.WriteLine("Такая информация уже существует");

        }
        //Изменение данных существующего матча;
        Console.WriteLine("\nИзменение данных существующего матча: ");
        var game3 = db.Games.ToList().Last();

        if (game3 != null)
        {
          game3.GameDate = DateTime.Now;
          game3.PlayersWhoGoals = "Carlos, Arshavin, Messi";
          db.SaveChanges();
          var firstClubName2 = db.Clubs.FirstOrDefault(x => x.Id == game3.IdFirstClub).Club;
          var secondClubName2 = db.Clubs.FirstOrDefault(x => x.Id == game3.IdSecondClub).Club;
          Console.WriteLine(new string('-', 3 + 20 + 7 + 30 + 10 + 5));
          Console.WriteLine("|{0,3}|{1,20}|{2,7}|{3,30}|{4,10}|", "Id", "Game", "Score", "WhoGoals", "Date");
          Console.WriteLine(new string('-', 3 + 20 + 7 + 30 + 10 + 5));
          Console.WriteLine("|{0,3}|{1,20}|{2,7}|{3,30}|{4,10}|", game3.Id, firstClubName2 + " - " + secondClubName2, game3.FirstClubGoals + " - " + game3.SecondClubGoals, game3.PlayersWhoGoals, game3.GameDate.ToString("d"));
        }


        //Удаление матча. Поиск удаляемого матча производится по названию команд и дате.Перед удалением приложение должно спросить пользователя нужно ли удалять матч.     
        Console.WriteLine("\nУдаление матча. Поиск удаляемого матча производится по названию команд и дате: ");
        var firstClubName3 = db.Clubs.FirstOrDefault(x => x.Id == game3.IdFirstClub).Club;
        var secondClubName3 = db.Clubs.FirstOrDefault(x => x.Id == game3.IdSecondClub).Club;
        Console.WriteLine("Нажмите Enter для удаления матча " + firstClubName3 + " - " + secondClubName3 + " или Пробел для отмены");
        bool isDelete = true;

        while (Console.ReadKey().Key != ConsoleKey.Enter)
        {
          if (Console.ReadKey().Key == ConsoleKey.Spacebar)
          {
            isDelete = false;
            break;
          }
          else
            Console.ReadKey();
        }
        if (isDelete)
        {
          db.Games.Remove(game3);
          db.SaveChanges();
          Console.WriteLine("Матч " + firstClubName3 + " - " + secondClubName3 + " удален");
        }
        else
        {
          Console.WriteLine("Удаление матча " + firstClubName3 + " - " + secondClubName3 + "отменено");
        }

        // Модуль 6.Введение в Entity Framework Core.
        // Часть 2
        // Задание 1
        // Добавьте новую функциональность к проекту чемпионат Испании по футболу из первого практического задания:

        // Поиск информации о команде по названию;
        string clubName3 = "Real";
        Console.WriteLine("\nПоиск информации о команде по названию " + clubName3 + ": ");
        var clubInfo = db.Clubs.Where(x => x.Club == clubName3).FirstOrDefault();
        Console.WriteLine(new string('-', 5 + 10 + 10 + 20 + 10 + 5));
        Console.WriteLine("|{0,5}|{1,10}|{2,10}|{3,20}|{4,10}|", "Id", "Club", "City", "Stadium", "Capacity");
        Console.WriteLine(new string('-', 5 + 10 + 10 + 20 + 10 + 5));
        if (clubInfo != null)
        {
          var city = db.Cities.FirstOrDefault(x => x.Id == clubInfo.IdCities).City;
          var stadium = db.Stadiums.FirstOrDefault(x => x.Id == clubInfo.IdStadiums).Stadium;
          var capacity = db.Stadiums.FirstOrDefault(x => x.Id == clubInfo.IdStadiums).Capacity;
          Console.WriteLine("|{0,5}|{1,10}|{2,10}|{3,20}|{4,10}|", clubInfo.Id, clubInfo.Club, city, stadium, capacity);
        }

        // Поиск команд по названию города;
        string cityName = "Madrid";
        Console.WriteLine("\nПоиск команд по названию города " + cityName + ": ");
        var cityId = db.Cities.FirstOrDefault(x => x.City == cityName).Id;
        var clubs2 = db.Clubs.Where(x => x.IdCities == cityId).ToList();

        foreach (var club in clubs2)
        {
          Console.WriteLine(club.Club);
        }

        // Поиск информации по названию команды и городу
        clubName3 = "Real";
        cityName = "Madrid";
        Console.WriteLine("\nПоиск информации о команде по названию команды " + clubName3 + " и городу " + cityName + ": ");
        cityId = db.Cities.FirstOrDefault(x => x.City == cityName).Id;
        clubInfo = db.Clubs.Where(x => (x.Club == clubName3 && x.IdCities == cityId)).FirstOrDefault();
        Console.WriteLine(new string('-', 5 + 10 + 10 + 20 + 10 + 5));
        Console.WriteLine("|{0,5}|{1,10}|{2,10}|{3,20}|{4,10}|", "Id", "Club", "City", "Stadium", "Capacity");
        Console.WriteLine(new string('-', 5 + 10 + 10 + 20 + 10 + 5));
        if (clubInfo != null)
        {
          var city = db.Cities.FirstOrDefault(x => x.Id == clubInfo.IdCities).City;
          var stadium = db.Stadiums.FirstOrDefault(x => x.Id == clubInfo.IdStadiums).Stadium;
          var capacity = db.Stadiums.FirstOrDefault(x => x.Id == clubInfo.IdStadiums).Capacity;
          Console.WriteLine("|{0,5}|{1,10}|{2,10}|{3,20}|{4,10}|", clubInfo.Id, clubInfo.Club, city, stadium, capacity);
        }

        // Задание 2 Добавьте новую функциональность к проекту чемпионат Испании по футболу из первого практического задания:
        // Отображение команды с самым большим количеством побед;
        Console.WriteLine("\nОтображение команды с самым большим количеством побед: ");
        games = db.Games.ToList();
        clubs = db.Clubs.ToList();
        int countBiggestWin = 0;
        string clubBiggestWin = "";
        for (int i = 0; i < clubs.Count; i++)
        {
          var IdClub = clubs[i].Id;
          var clubName = db.Clubs.FirstOrDefault(x => x.Id == IdClub).Club;
          int win = 0;
          for (int j = 0; j < games.Count; j++)
          {
            if (games[j].IdFirstClub == IdClub)
            {
              if (games[j].FirstClubGoals > games[j].SecondClubGoals)
              {
                win++;
              }
            }
            if (games[j].IdSecondClub == IdClub)
            {
              if (games[j].FirstClubGoals < games[j].SecondClubGoals)
              {
                win++;
              }
            }
          }
          if (countBiggestWin < win)
          {
            countBiggestWin = win;
            clubBiggestWin = clubName;
          }
        }
        Console.WriteLine("Клуб: " + clubBiggestWin + ", Побед: " + countBiggestWin);

        // Отображение команды с самым большим количеством поражений;
        Console.WriteLine("\nОтображение команды с самым большим количеством поражений: ");
        games = db.Games.ToList();
        clubs = db.Clubs.ToList();
        int countBiggestLoss = 0;
        string clubBiggestLoss = "";
        for (int i = 0; i < clubs.Count; i++)
        {
          var IdClub = clubs[i].Id;
          var clubName = db.Clubs.FirstOrDefault(x => x.Id == IdClub).Club;
          int loss = 0;
          for (int j = 0; j < games.Count; j++)
          {
            if (games[j].IdFirstClub == IdClub)
            {
              if (games[j].FirstClubGoals < games[j].SecondClubGoals)
              {
                loss++;
              }
            }
            if (games[j].IdSecondClub == IdClub)
            {
              if (games[j].FirstClubGoals > games[j].SecondClubGoals)
              {
                loss++;
              }
            }
          }
          if (countBiggestLoss < loss)
          {
            countBiggestLoss = loss;
            clubBiggestLoss = clubName;
          }
        }
        Console.WriteLine("Клуб: " + clubBiggestLoss + ", Поражений: " + countBiggestLoss);

        // Отображение команды с самым большим количеством ничьих;
        Console.WriteLine("\nОтображение команды с самым большим количеством ничьих: ");
        games = db.Games.ToList();
        clubs = db.Clubs.ToList();
        int countBiggestEquals = 0;
        string clubBiggestEquals = "";
        for (int i = 0; i < clubs.Count; i++)
        {
          var IdClub = clubs[i].Id;
          var clubName = db.Clubs.FirstOrDefault(x => x.Id == IdClub).Club;
          int equals = 0;
          for (int j = 0; j < games.Count; j++)
          {
            if (games[j].IdFirstClub == IdClub)
            {
              if (games[j].FirstClubGoals == games[j].SecondClubGoals)
              {
                equals++;
              }
            }
            if (games[j].IdSecondClub == IdClub)
            {
              if (games[j].FirstClubGoals == games[j].SecondClubGoals)
              {
                equals++;
              }
            }
          }
          if (countBiggestEquals < equals)
          {
            countBiggestEquals = equals;
            clubBiggestEquals = clubName;
          }
        }
        Console.WriteLine("Клуб: " + clubBiggestEquals + ", Ничьих: " + countBiggestEquals);

        // Отображение команды с самым большим количеством забитых голов;
        Console.WriteLine("\nОтображение команды с самым большим количеством забитых голов: ");
        games = db.Games.ToList();
        clubs = db.Clubs.ToList();
        int countBiggestGoals = 0;
        string clubBiggestGoals = "";
        for (int i = 0; i < clubs.Count; i++)
        {
          var IdClub = clubs[i].Id;
          var clubName = db.Clubs.FirstOrDefault(x => x.Id == IdClub).Club;
          int goals = 0;
          for (int j = 0; j < games.Count; j++)
          {
            if (games[j].IdFirstClub == IdClub)
            {
              goals += games[j].FirstClubGoals;
            }
            if (games[j].IdSecondClub == IdClub)
            {
              goals += games[j].SecondClubGoals;
            }
          }
          if (countBiggestGoals < goals)
          {
            countBiggestGoals = goals;
            clubBiggestGoals = clubName;
          }
        }
        Console.WriteLine("Клуб: " + clubBiggestGoals + ", Голов: " + countBiggestGoals);

        // Отображение команды с самым большим количеством пропущенных голов.
        Console.WriteLine("\nОтображение команды с самым большим количеством пропущенных голов: ");
        games = db.Games.ToList();
        clubs = db.Clubs.ToList();
        int countMissedGoals = 0;
        string clubMissedGoals = "";
        for (int i = 0; i < clubs.Count; i++)
        {
          var IdClub = clubs[i].Id;
          var clubName = db.Clubs.FirstOrDefault(x => x.Id == IdClub).Club;
          int missedGoals = 0;
          for (int j = 0; j < games.Count; j++)
          {
            if (games[j].IdFirstClub == IdClub)
            {
              missedGoals += games[j].SecondClubGoals;
            }
            if (games[j].IdSecondClub == IdClub)
            {
              missedGoals += games[j].FirstClubGoals;
            }
          }
          if (countMissedGoals < missedGoals)
          {
            countMissedGoals = missedGoals;
            clubMissedGoals = clubName;
          }
        }
        Console.WriteLine("Клуб: " + clubMissedGoals + ", Пропущенных голов: " + countMissedGoals);

        // Задание 3
        // Добавьте новую функциональность к проекту чемпионат Испании по футболу из первого практического задания:

        // Добавление новой команды.Перед добавлением нужно проверить не существует ли уже такая команда;
        Console.WriteLine("\nДобавление новой команды.Перед добавлением нужно проверить не существует ли уже такая команда: ");

        var newClub = new Clubs()
        {
          Club = "Athletico",
          IdCities = 1,
          IdStadiums = 1
        };

        var club2 = db.Clubs.Where(x => x.Club == newClub.Club).FirstOrDefault();

        if (club2 == null)
        {
          db.Clubs.Add(newClub);
          db.SaveChanges();
          var createdClub = db.Clubs.ToList().Last();
          var city = db.Cities.FirstOrDefault(x => x.Id == createdClub.IdCities).City;
          var stadium = db.Stadiums.FirstOrDefault(x => x.Id == createdClub.IdStadiums).Stadium;
          var capacity = db.Stadiums.FirstOrDefault(x => x.Id == createdClub.IdStadiums).Capacity;
          Console.WriteLine("|{0,5}|{1,10}|{2,10}|{3,20}|{4,10}|", createdClub.Id, createdClub.Club, city, stadium, capacity);
        }
        else
        {
          Console.WriteLine("Такая информация уже существует");
        }

        // Изменение данных существующей команды.
        Console.WriteLine("\nИзменение данных существующей команды: ");
        var club3 = db.Clubs.ToList().Last();

        if (club3 != null)
        {
          club3.IdCities = 2;
          club3.IdStadiums = 2;
          db.SaveChanges();
          var createdClub = db.Clubs.ToList().Last();
          var city = db.Cities.FirstOrDefault(x => x.Id == club3.IdCities).City;
          var stadium = db.Stadiums.FirstOrDefault(x => x.Id == club3.IdStadiums).Stadium;
          var capacity = db.Stadiums.FirstOrDefault(x => x.Id == club3.IdStadiums).Capacity;
          Console.WriteLine("|{0,5}|{1,10}|{2,10}|{3,20}|{4,10}|", club3.Id, club3.Club, city, stadium, capacity);
        }

        // Удаление команды. Поиск удаляемой команды производится по названию и городу. Перед удалением приложение должно спросить пользователя нужно ли удалять команду.
        Console.WriteLine("\nУдаление команды. Поиск удаляемой команды производится по названию и городу. : ");
        Console.WriteLine("Нажмите Enter для удаления команды " + club3.Club + " или Пробел для отмены");
        isDelete = true;
        while (Console.ReadKey().Key != ConsoleKey.Enter)
        {
          if (Console.ReadKey().Key == ConsoleKey.Spacebar)
          {
            isDelete = false;
            break;
          }
          else
            Console.ReadKey();
        }
        if (isDelete)
        {
          db.Clubs.Remove(club3);
          db.SaveChanges();
          Console.WriteLine("Команда " + club3.Club + " удалена");
        }
        else
        {
          Console.WriteLine("Удаление команды " + club3.Club + " отменено");
        }

      }
      Console.ReadLine();
    }

  }
}
