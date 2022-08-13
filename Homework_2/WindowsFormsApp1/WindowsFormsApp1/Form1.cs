using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp1
{
  public partial class Form1 : Form
  {
    DbConnection conn = null;
    DbProviderFactory fact = null;
    string connectionString = "";

    //словарь для хранения Select запросов
    Dictionary<string, string> queries = new Dictionary<string, string>();

    public Form1()
    {
      InitializeComponent();
      //по умолчанию делаем кнопки неактивными пока поля ввода SQL запроса пусты
      button1.Enabled = false;
      button2.Enabled = false;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      //SQL на создание и наполнение таблицы в БД VegetablesFruits
      string queryForCreateDBAndAddData = @"
                                          USE VegetablesFruits;
                                          DROP TABLE IF EXISTS Vegetable_Fruits_Table;
                                          CREATE TABLE Vegetable_Fruits_Table
                                          (
                                            Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
                                            Name NVARCHAR(50) NOT NULL,
                                            Type NVARCHAR(50) NOT NULL,
                                            Color NVARCHAR(50) NOT NULL,
                                            Calory NUMERIC(3) NOT NULL,
                                          );
                                          insert into Vegetable_Fruits_Table (Name, Type, Color, Calory) values ('Apple', 'Fruit', 'Green', 120);
                                          insert into Vegetable_Fruits_Table (Name, Type, Color, Calory) values ('Banana', 'Fruit', 'Yellow', 200);
                                          insert into Vegetable_Fruits_Table (Name, Type, Color, Calory) values ('Carrot', 'Vegetable', 'Orange', 180);
                                          insert into Vegetable_Fruits_Table (Name, Type, Color, Calory) values ('Beet', 'Vegetable', 'Red', 300);
                                          insert into Vegetable_Fruits_Table (Name, Type, Color, Calory) values ('Ananas', 'Fruit', 'Grey', 600); 
                                          insert into Vegetable_Fruits_Table (Name, Type, Color, Calory) values ('Onion', 'Vegetable', 'Yellow', 400); 
                                          ";

      //по умолчанию подключение к БД MSSQL
      fact = DbProviderFactories.GetFactory("System.Data.SqlClient");
      conn = fact.CreateConnection();
      connectionString = GetConnectionStringByProvider("System.Data.SqlClient");
      if (connectionString == null)
      {
        MessageBox.Show("В конфигурационном файле нет требуемой строки подключения");
      }
      textBox3.Text = connectionString;
      conn.ConnectionString = textBox3.Text;

      //выполняем SQL запрос на создание таблицы и заполнение данными 
      conn.Open();
      DbCommand comm = conn.CreateCommand();
      comm.CommandText = queryForCreateDBAndAddData;
      comm.ExecuteNonQuery();
      conn.Close();
      
      //заполняем список доступными подключениями к БД
      DataTable t = DbProviderFactories.GetFactoryClasses();
      comboBox1.Items.Clear();
      foreach (DataRow dr in t.Rows)
      {
        comboBox1.Items.Add(dr["InvariantName"]);
      }

      //формируем список Select запросов и заполняем выпадающий список
      queries.Add("Отображение всей информации из таблицы с овощами и фруктами", "select * from Vegetable_Fruits_Table");
      queries.Add("Отображение всех названий овощей и фруктов", "select name from Vegetable_Fruits_Table");
      queries.Add("Отображение всех цветов", "select color from Vegetable_Fruits_Table");
      queries.Add("Показать максимальную калорийность", "select Max(calory) AS 'Max' from Vegetable_Fruits_Table");
      queries.Add("Показать минимальную калорийность", "select Min(calory) AS 'Min' from Vegetable_Fruits_Table");
      queries.Add("Показать среднюю калорийность", "select Avg(calory) AS 'Avg' from Vegetable_Fruits_Table");
      queries.Add("Показать количество овощей", "select Count(type) AS 'Count' from Vegetable_Fruits_Table where type='Vegetable'");
      queries.Add("Показать количество фруктов", "select Count(type) AS 'Count' from Vegetable_Fruits_Table where type='Fruit'");
      queries.Add("Показать количество овощей и фруктов заданного цвета 'Yellow'", "select Count(type) from Vegetable_Fruits_Table where color='Yellow'");
      queries.Add("Показать количество овощей фруктов каждого цвета", "select color, Count(name) AS 'Count' from Vegetable_Fruits_Table Group By color");
      queries.Add("Показать овощи и фрукты с калорийностью ниже указанной '< 300'", "select name, calory from Vegetable_Fruits_Table where calory < 300");
      queries.Add("Показать овощи и фрукты с калорийностью выше указанной '> 300'", "select name, calory from Vegetable_Fruits_Table where calory > 300");
      queries.Add("Показать овощи и фрукты с калорийностью в указанном диапазоне '300 and 600'", "select name, calory from Vegetable_Fruits_Table where calory between 300 and 600");
      queries.Add("Показать овощи и фрукты с калорийностью в указанном диапазоне 'yellow' or 'red'", "select name, color from Vegetable_Fruits_Table where color = 'yellow' or color = 'red'");
      foreach (string key in queries.Keys)
      {
        comboBox2.Items.Add(key);
      }

   }

    //метод получения строки подключения из конфигурационного файла
    static string GetConnectionStringByProvider(string providerName)
    {
      string returnValue = null;
      ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
      if (settings != null)
      {
        foreach (ConnectionStringSettings cs in settings)
        {
          if (cs.ProviderName == providerName)
          {
            returnValue = cs.ConnectionString;
            break;
          }
        }
      }
      return returnValue;
    }

    //кнопка выполнения Select запросов
    private async void button1_Click(object sender, EventArgs e)
    {

      conn.ConnectionString = textBox3.Text;
      await conn.OpenAsync();
      DbCommand comm = conn.CreateCommand();
      comm.CommandText = conn.ConnectionString.Contains("OLEDB") ? "" : "WAITFOR DELAY '00:00:05';";
      comm.CommandText += textBox1.Text.ToString();
      DataTable table = new DataTable();
      dataGridView1.DataSource = null;
      textBox4.Text = "";
      var sw = new Stopwatch();
      sw.Restart();
      using (DbDataReader reader = await comm.ExecuteReaderAsync())
      {
        sw.Stop();
        textBox4.Text = sw.Elapsed.ToString();
        int line = 0;
        do
        {
          while (await reader.ReadAsync())
          {
            if (line == 0)
            {
              for (int i = 0; i < reader.FieldCount; i++)
              {
                table.Columns.Add(reader.GetName(i));
              }
              line++;
            }
            DataRow row = table.NewRow();
            for (int i = 0; i < reader.FieldCount; i++)
            {
              row[i] = await reader.GetFieldValueAsync<Object>(i);
            }
            table.Rows.Add(row);
          }
        } while (reader.NextResult());
      }
      conn.Close();
      dataGridView1.DataSource = table;
    }

    //кнопка выполнения Update, Delete, Insert запросов
    private async void button2_Click(object sender, EventArgs e)
    {
      conn.ConnectionString = textBox3.Text;
      await conn.OpenAsync();
      DbCommand comm = conn.CreateCommand();
      comm.CommandText = conn.ConnectionString.Contains("OLEDB") ? "" : "WAITFOR DELAY '00:00:05';";
      comm.CommandText += textBox2.Text.ToString();
      dataGridView1.DataSource = null;
      textBox4.Text = "";
      var sw = new Stopwatch();
      sw.Restart();

      await comm.ExecuteNonQueryAsync();

      sw.Stop();
      textBox4.Text = sw.Elapsed.ToString();

      //отображаем таблицу после запроса
      comm.CommandText = "Select * from Vegetable_Fruits_Table";

      var table = new DataTable();

      using (DbDataReader reader = comm.ExecuteReader())
      {
        int line = 0;
        do
        {
          while (reader.Read())
          {
            //на первой итерации формируем колонки
            if (line == 0)
            {
              for (int i = 0; i < reader.FieldCount; i++)
              {
                table.Columns.Add(reader.GetName(i));
              }
              line++;
            }
            //поскольку колонки уже готовы, то на каждой итерации создаем и заполняем очередную строку 
            DataRow row = table.NewRow();
            for (int i = 0; i < reader.FieldCount; i++)
            {
              row[i] = reader[i]; //заполняем строку из reader
            }
            table.Rows.Add(row); //добавляем очередную строку
          }
        } while (reader.NextResult());
        dataGridView1.DataSource = table;
        conn.Close();
        reader.Close();
      }
    }
    
    //поле для Select запроса
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      if (textBox1.Text.Length > 5)
        button1.Enabled = true;
      else
        button1.Enabled = false;
    }

    //список доступных подключений к БД
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      fact = DbProviderFactories.GetFactory(comboBox1.SelectedItem.ToString());
      conn = fact.CreateConnection();
      connectionString = GetConnectionStringByProvider(comboBox1.SelectedItem.ToString());
      textBox3.Text = connectionString;
    }

    //поле для Update, Delete, Insert запросов
    private void textBox2_TextChanged(object sender, EventArgs e)
    {
      if (textBox2.Text.Length > 5)
        button2.Enabled = true;
      else
        button2.Enabled = false;
    }

    //поле для отображения строки текущего соединения с БД
    private void textBox3_TextChanged(object sender, EventArgs e)
    {

    }

    private void label5_Click(object sender, EventArgs e)
    {

    }

    //список для выбора Select запросов
    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (queries.TryGetValue(comboBox2.SelectedItem.ToString(), out string query))
      {
        textBox1.Text = query;
      }
    }
  }
}