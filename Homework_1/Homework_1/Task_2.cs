using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace VegetablesFruitsApp {
  internal class Task_2 {
    public static void connectDatabase() {
      try {

        Console.WriteLine(" \nНажмите Enter для подключения к базе ");
        while (Console.ReadKey().Key != ConsoleKey.Enter) {
          Console.ReadKey();
        }

        DbConnect.connectionDB.Open();
        Console.WriteLine(" \nСоединение с базой VegetablesFruits установлено ");

        Console.WriteLine(" \nНажмите Пробел для отключения соединения ");
        while (Console.ReadKey().Key != ConsoleKey.Spacebar) {
          Console.ReadKey();
        }
        Console.WriteLine("\nСоединение с базой VegetablesFruits завершено ");

      } catch (Exception ex) {
        Console.WriteLine(ex.Message);
      } finally {
        DbConnect.connectionDB.Close();
        Console.WriteLine(" \nConnection Close ");
      }
    }
  }
}