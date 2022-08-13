using System;
using Microsoft.Data.SqlClient;


namespace VegetablesFruitsApp {
  public class DbConnect {
    const string connectionServerString = "Server=LAPTOP-66IDD8T0\\SQLEXPRESS;Trusted_Connection=True;TrustServerCertificate=True;";
    public static SqlConnection connectionServer = new SqlConnection(connectionServerString);

    const string connectionDBString = "Server=LAPTOP-66IDD8T0\\SQLEXPRESS;Database=VegetablesFruits;Trusted_Connection=True;TrustServerCertificate=True;";
    public static SqlConnection connectionDB = new SqlConnection(connectionDBString);
  }
}
