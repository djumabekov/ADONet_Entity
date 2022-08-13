using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace VegetablesFruitsApp {
  internal class Task_1 {
    public static void createDatabase() {
      try {
        DbConnect.connectionServer.Open();
        Console.WriteLine("Connection Open. Creating database...");

        string createDbString = @"
                              DROP DATABASE IF EXISTS VegetablesFruits;
                              CREATE DATABASE VegetablesFruits; 
                              ";
        using (SqlCommand cmdCreateDb = new SqlCommand(createDbString, DbConnect.connectionServer)) 
          {
            cmdCreateDb.ExecuteReader();
            Console.WriteLine("Database created");
          };
          

        string createtableString = @"
                              USE VegetablesFruits;
                              DROP TABLE IF EXISTS Vegetable_Fruits_Table;

                              CREATE TABLE Vegetable_Fruits_Table
                              (
                                Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
                                Name NVARCHAR(50) NOT NULL,
                                Type NVARCHAR(50) NOT NULL,
                                Color NVARCHAR(50) NOT NULL,
                                Calory NUMERIC(3) NOT NULL,
                              ) ";

        DbConnect.connectionDB.Open();
        using (SqlCommand cmdCreateTable = new SqlCommand(createtableString, DbConnect.connectionDB)) {
                cmdCreateTable.ExecuteReader();
                Console.WriteLine("Table created");

        }
        DbConnect.connectionDB.Close();

        DbConnect.connectionDB.Open();
        string insertString = @"
                              insert into Vegetable_Fruits_Table (Name, Type, Color, Calory) values ('Apple', 'Fruit', 'Green', 120);
                              insert into Vegetable_Fruits_Table (Name, Type, Color, Calory) values ('Banana', 'Fruit', 'Yellow', 200);
                              insert into Vegetable_Fruits_Table (Name, Type, Color, Calory) values ('Carrot', 'Vegetable', 'Orange', 180);
                              insert into Vegetable_Fruits_Table (Name, Type, Color, Calory) values ('Beet', 'Vegetable', 'Red', 300);
                              insert into Vegetable_Fruits_Table (Name, Type, Color, Calory) values ('Ananas', 'Fruit', 'Grey', 600); 
                              insert into Vegetable_Fruits_Table (Name, Type, Color, Calory) values ('Onion', 'Vegetable', 'Yellow', 400); 
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
