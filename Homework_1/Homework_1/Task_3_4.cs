using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace VegetablesFruitsApp {
  internal class Task_3_4 {

    public static void getQuery(string query, SqlConnection conn) {
      SqlDataReader rdr = null;
      SqlCommand cmd = new SqlCommand(query, conn);
      rdr = cmd.ExecuteReader();
      while (rdr.Read()) {
        Console.WriteLine($"{rdr[0],3:N0}");
      }
      if (rdr != null) {
        rdr.Close();
      }
    }
    public static void readDatabase() {
      try {
        Console.WriteLine(" \nНажмите любую клавишу для продолжения... ");
        Console.ReadKey();

        DbConnect.connectionDB.Open();
        Console.WriteLine("Connection Open");

        SqlDataReader rdr = null;
        SqlCommand cmd = new SqlCommand("select * from Vegetable_Fruits_Table", DbConnect.connectionDB);
        rdr = cmd.ExecuteReader();

        Console.WriteLine("\nОтображение всей информации из таблицы с овощами и фруктами");
        Console.WriteLine(new string('-', 10 + 10 + 10 + 10 + 10 + 5));
        Console.WriteLine("|{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|", "Id", "Name", "Type", "Color", "Calory");
        Console.WriteLine(new string('-', 10 + 10 + 10 + 10 + 10 + 5));

        while (rdr.Read()) {
          Console.WriteLine("|{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|", rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
        }
        if (rdr != null) {
          rdr.Close();
        }

        Console.WriteLine(" \nНажмите любую клавишу для продолжения... "); Console.ReadKey();
        Console.WriteLine("\nОтображение всех названий овощей и фруктов");
        getQuery("select name from Vegetable_Fruits_Table", DbConnect.connectionDB);

        Console.WriteLine(" \nНажмите любую клавишу для продолжения... "); Console.ReadKey();
        Console.WriteLine("\nОтображение всех цветов");
        getQuery("select color from Vegetable_Fruits_Table", DbConnect.connectionDB);

        Console.WriteLine(" \nНажмите любую клавишу для продолжения... "); Console.ReadKey();
        Console.WriteLine("\nПоказать максимальную калорийность");
        getQuery("select Max(calory) from Vegetable_Fruits_Table", DbConnect.connectionDB);

        Console.WriteLine(" \nНажмите любую клавишу для продолжения... "); Console.ReadKey();
        Console.WriteLine("\nПоказать минимальную калорийность");
        getQuery("select Min(calory) from Vegetable_Fruits_Table", DbConnect.connectionDB);

        Console.WriteLine(" \nНажмите любую клавишу для продолжения... "); Console.ReadKey();
        Console.WriteLine("\nПоказать среднюю калорийность");
        getQuery("select Avg(calory) from Vegetable_Fruits_Table", DbConnect.connectionDB);

        Console.WriteLine(" \nНажмите любую клавишу для продолжения... "); Console.ReadKey();
        Console.WriteLine("\nПоказать количество овощей");
        getQuery("select Count(type) from Vegetable_Fruits_Table where type='Vegetable'", DbConnect.connectionDB);

        Console.WriteLine(" \nНажмите любую клавишу для продолжения... "); Console.ReadKey();
        Console.WriteLine("\nПоказать количество фруктов");
        getQuery("select Count(type) from Vegetable_Fruits_Table where type='Fruit'", DbConnect.connectionDB);
       
        Console.WriteLine(" \nНажмите любую клавишу для продолжения... "); Console.ReadKey();
        Console.WriteLine("\nПоказать количество овощей и фруктов заданного цвета 'Yellow'");
        getQuery("select Count(type) from Vegetable_Fruits_Table where color='Yellow'", DbConnect.connectionDB);

        Console.WriteLine(" \nНажмите любую клавишу для продолжения... "); Console.ReadKey();
        Console.WriteLine("\nПоказать количество овощей фруктов каждого цвета");
        rdr = null;
        cmd = new SqlCommand("select color, Count(name) from Vegetable_Fruits_Table Group By color", DbConnect.connectionDB);
        rdr = cmd.ExecuteReader();
        while (rdr.Read()) {
          Console.WriteLine($"{rdr[0],10:N0}: {rdr[1],3:N0}");
        }
        if (rdr != null) {
          rdr.Close();
        }

        Console.WriteLine(" \nНажмите любую клавишу для продолжения... "); Console.ReadKey();
        Console.WriteLine("\nПоказать овощи и фрукты с калорийностью ниже указанной '< 300'");
        getQuery("select name from Vegetable_Fruits_Table where calory < 300", DbConnect.connectionDB);

        Console.WriteLine(" \nНажмите любую клавишу для продолжения... "); Console.ReadKey();
        Console.WriteLine("\nПоказать овощи и фрукты с калорийностью выше указанной '> 300'");
        getQuery("select name from Vegetable_Fruits_Table where calory > 300", DbConnect.connectionDB);

        Console.WriteLine(" \nНажмите любую клавишу для продолжения... "); Console.ReadKey();
        Console.WriteLine("\nПоказать овощи и фрукты с калорийностью в указанном диапазоне '300 and 600'");
        getQuery("select name from Vegetable_Fruits_Table where calory between 300 and 600", DbConnect.connectionDB);

        Console.WriteLine(" \nНажмите любую клавишу для продолжения... "); Console.ReadKey();
        Console.WriteLine("\nПоказать овощи и фрукты с калорийностью в указанном диапазоне 'yellow' or 'red'");
        getQuery("select name from Vegetable_Fruits_Table where color = 'yellow' or color = 'red'", DbConnect.connectionDB);

      } catch (Exception ex) {
        Console.WriteLine(ex.Message);
      } finally {
        DbConnect.connectionDB.Close();
        Console.WriteLine(" \nConnection Close ");
      }
    }
  }
}