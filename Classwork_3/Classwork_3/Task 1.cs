using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace StationeryShop {
  internal class Task_1 {
    public static void createDatabase() {
      try {
        DbConnect.connectionServer.Open();
        Console.WriteLine("Connection Open. Creating database...");

        string createDbString = @"
                              DROP DATABASE IF EXISTS StationeryShop;
                              CREATE DATABASE StationeryShop; 
                              ";
        using (SqlCommand cmdCreateDb = new SqlCommand(createDbString, DbConnect.connectionServer)) 
          {
            cmdCreateDb.ExecuteReader();
            Console.WriteLine("Database created");
          };
          

        string createtableString = @"
                              USE StationeryShop;
                              DROP TABLE IF EXISTS Stationery;

                              CREATE TABLE Stationery
                              (
                                Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
                                Name NVARCHAR(50) NOT NULL,
                                Type NVARCHAR(50) NOT NULL,
                                Count NUMERIC(3) NOT NULL,
                                CostPrice NUMERIC(3) NOT NULL,
                              );
                              DROP TABLE IF EXISTS Managers;
                              CREATE TABLE Managers
                              (
                                Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
                                Firstame NVARCHAR(50) NOT NULL,
                                Lastname NVARCHAR(50) NOT NULL,   
                              );
                              DROP TABLE IF EXISTS Sale;
                              CREATE TABLE Sale
                              (
                                Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
                                BuyerName NVARCHAR(50) NOT NULL,
                                MangerId INT NOT NULL,
                                StationeryId INT NOT NULL,
                                CountStationery NUMERIC(3) NOT NULL,
                                SalePrice NUMERIC(3) NOT NULL,
                                Date DATE NOT NULL,
                              )
                              ";

        DbConnect.connectionDB.Open();
        using (SqlCommand cmdCreateTable = new SqlCommand(createtableString, DbConnect.connectionDB)) {
                cmdCreateTable.ExecuteReader();
                Console.WriteLine("Table created");

        }
        DbConnect.connectionDB.Close();

        DbConnect.connectionDB.Open();
        string insertString = @"
                              insert into Stationery (Name, Type, Count, CostPrice) values ('Pen', 'ball', 123, 200);
                              insert into Stationery (Name, Type, Count, CostPrice) values ('Pencil', 'green', 342, 170);
                              insert into Stationery (Name, Type, Count, CostPrice) values ('Ruler', 'plastic', 517, 328);
                              insert into Stationery (Name, Type, Count, CostPrice) values ('Eraser', 'white', 425, 134);

                              insert into Managers (Firstame, Lastname) values ('Ivan', 'Ivanov');
                              insert into Managers (Firstame, Lastname) values ('Petr', 'Petrov');
                              insert into Managers (Firstame, Lastname) values ('Sidor', 'Sidorov');

                              insert into Sale (BuyerName, MangerId, StationeryId, CountStationery, SalePrice, Date) values ('ABDI',   1, 3, 12, 657, '30-01-2022');
                              insert into Sale (BuyerName, MangerId, StationeryId, CountStationery, SalePrice, Date) values ('SULPAK', 2, 2, 32, 234, '11-06-2022');
                              insert into Sale (BuyerName, MangerId, StationeryId, CountStationery, SalePrice, Date) values ('MECHTA', 3, 1, 53, 632, '22-02-2022');
                              ";

        using (SqlCommand cmdInstertData = new SqlCommand(insertString, DbConnect.connectionDB)) {
          cmdInstertData.ExecuteNonQuery();
          Console.WriteLine("Data inserted");
        }

        DbConnect.connectionDB.Close();

      } catch (Exception ex) {
        Console.WriteLine(ex.Message);
      } finally {
        DbConnect.connectionServer.Close();
        DbConnect.connectionDB.Close();
        Console.WriteLine("Connection Close");
      }
    } 
  }
}
