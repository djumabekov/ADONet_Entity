using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace StationeryShop {
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
        SqlCommand cmd = new SqlCommand("select * from Stationery", DbConnect.connectionDB);
        rdr = cmd.ExecuteReader();

        Console.WriteLine("\nОтображение всей информации из таблицы Stationery");
        Console.WriteLine(new string('-', 10 + 10 + 10 + 10 + 10 + 5));
        Console.WriteLine("|{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|", "Id", "Name", "Type", "Count", "CostPrice");
        Console.WriteLine(new string('-', 10 + 10 + 10 + 10 + 10 + 5));

        while (rdr.Read()) {
          Console.WriteLine("|{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|", rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
        }
        if (rdr != null) {
          rdr.Close();
        }

        Console.WriteLine(" \nНажмите любую клавишу для продолжения... "); Console.ReadKey();
        Console.WriteLine("\nОтображение всех типов");
        getQuery("select type from Stationery", DbConnect.connectionDB);

        Console.WriteLine(" \nНажмите любую клавишу для продолжения... "); Console.ReadKey();
        rdr = null;
        cmd = new SqlCommand("select * from Managers", DbConnect.connectionDB);
        rdr = cmd.ExecuteReader();
        Console.WriteLine("\nОтображение всех менеджеров по продажам");
        Console.WriteLine(new string('-', 10 + 10 + 10 + 5));
        Console.WriteLine("|{0,10}|{1,10}|{2,10}|", "Id", "Firstname", "Lastname");
        Console.WriteLine(new string('-', 10 + 10 + 10 + 5));
        while (rdr.Read()) {
          Console.WriteLine("|{0,10}|{1,10}|{2,10}|", rdr[0], rdr[1], rdr[2]);
        }
        if (rdr != null) {
          rdr.Close();
        }


        Console.WriteLine(" \nНажмите любую клавишу для продолжения... "); Console.ReadKey();
        Console.WriteLine("\nПоказать канцтовары с максимальным количеством единиц");
        rdr = null;
        cmd = new SqlCommand("select Name, Count from Stationery where Count = (select MAX(Count) from Stationery)", DbConnect.connectionDB);
        rdr = cmd.ExecuteReader();
        while (rdr.Read()) {
          Console.WriteLine($"{rdr[0],10:N0}: {rdr[1],3:N0}");
        }
        if (rdr != null) {
          rdr.Close();
        }

        Console.WriteLine(" \nНажмите любую клавишу для продолжения... "); Console.ReadKey();
        Console.WriteLine("\nПоказать канцтовары с минимальным количеством единиц");
        rdr = null;
        cmd = new SqlCommand("select Name, Count from Stationery where Count = (select MIN(Count) from Stationery)", DbConnect.connectionDB);
        rdr = cmd.ExecuteReader();
        while (rdr.Read()) {
          Console.WriteLine($"{rdr[0],10:N0}: {rdr[1],3:N0}");
        }
        if (rdr != null) {
          rdr.Close();
        }

        Console.WriteLine(" \nНажмите любую клавишу для продолжения... "); Console.ReadKey();
        Console.WriteLine("\nПоказать канцтовары с максимальной себестоимостью");
        rdr = null;
        cmd = new SqlCommand("select Name, CostPrice from Stationery where CostPrice = (select MAX(CostPrice) from Stationery)", DbConnect.connectionDB);
        rdr = cmd.ExecuteReader();
        while (rdr.Read()) {
          Console.WriteLine($"{rdr[0],10:N0}: {rdr[1],3:N0}");
        }
        if (rdr != null) {
          rdr.Close();
        }

        Console.WriteLine(" \nНажмите любую клавишу для продолжения... "); Console.ReadKey();
        Console.WriteLine("\nПоказать канцтовары с минимальной себестоимостью");
        rdr = null;
        cmd = new SqlCommand("select Name, CostPrice from Stationery where CostPrice = (select MIN(CostPrice) from Stationery)", DbConnect.connectionDB);
        rdr = cmd.ExecuteReader();
        while (rdr.Read()) {
          Console.WriteLine($"{rdr[0],10:N0}: {rdr[1],3:N0}");
        }
        if (rdr != null) {
          rdr.Close();
        }

      } catch (Exception ex) {
        Console.WriteLine(ex.Message);
      } finally {
        DbConnect.connectionDB.Close();
        Console.WriteLine(" \nConnection Close ");
      }
    }
  }
}