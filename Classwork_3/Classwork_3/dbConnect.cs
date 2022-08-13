using System;
using Microsoft.Data.SqlClient;


namespace StationeryShop {
  public class DbConnect {
    const string connectionServerString = "Server=LAPTOP-66IDD8T0\\SQLEXPRESS;Trusted_Connection=True;TrustServerCertificate=True;";
    public static SqlConnection connectionServer = new SqlConnection(connectionServerString);

    const string connectionDBString = "Server=LAPTOP-66IDD8T0\\SQLEXPRESS;Database=StationeryShop;Trusted_Connection=True;TrustServerCertificate=True;";
    public static SqlConnection connectionDB = new SqlConnection(connectionDBString);
  }
}
