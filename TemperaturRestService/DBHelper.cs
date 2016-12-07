using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TemperaturRestService
{
    public class DBHelper
    {
        private static string connectionstring =
            @"Server=tcp:easytempdb.database.windows.net,1433;Initial Catalog=easytempdb;Persist Security Info=False;User ID=easytemp;Password=Temp1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static List<Temperatur> GetTemperaturList()
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();


                    string sql = "SELECT *  FROM Temperatur";
                    SqlCommand cmd = new SqlCommand(sql, connection);


                    //cmd.CommandType = CommandType.Text;
                    //cmd.ExecuteNonQuery();

                    List<Temperatur> temperaturList = new List<Temperatur>();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Temperatur temps = new Temperatur();
                                temps.DatoTid = reader.GetDateTime(1);
                                temps.Sted = reader.GetString(2);
                                temps.Inde = reader.GetBoolean(3);
                                temps.Ude = reader.GetBoolean(4);
                                temps.Temp = reader.GetDouble(5);
                                temps.Kommentar = reader.GetString(6);
                                temperaturList.Add(temps);
                            }
                        }

                    }
                    return temperaturList;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Der skete en fejl da objektet skulle vises" + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}