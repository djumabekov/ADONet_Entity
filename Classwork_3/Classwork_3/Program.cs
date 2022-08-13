using Microsoft.Data.SqlClient;
using System;


namespace StationeryShop {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("\n\nЗадание 1. Создайте однотабличную базу данных «Овощи и фрукты».");
      Task_1.createDatabase();

      Console.WriteLine("\n\nЗадание 2. Создайте приложение, которую позволит пользователю подключиться и отключиться от базы данных «Овощи и фрукты».");
      Task_2.connectDatabase();

      Console.WriteLine("\n\nЗадание 3 и 4. Добавьте к приложению из второго задания следующую функциональность.");
      Task_3_4.readDatabase();

      Console.ReadKey();
    }
  }
}