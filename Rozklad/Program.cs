using System;
using System.Data;
using System.Data.SqlClient;

namespace Rozklad
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var connectionString =
                "Data Source=DESKTOP-ECVPNVB;Initial Catalog=Rozklad;Integrated Security=True";

            using (var connection =
                new SqlConnection(connectionString))
            {
                try
                {
                    Console.WriteLine(connection.ConnectionTimeout);
                    Console.WriteLine(connection.Database);
                    Console.WriteLine(connection.ClientConnectionId);
                    Console.WriteLine(connection.DataSource);

                    var cmd = new SqlCommand();
                    cmd.CommandText = "SELECT " +
                                      "[pName] ," +
                                      "[pParaN] ," +
                                      "[pDayOfWeek] ," +
                                      "[pCH] " +
                                      "FROM tParu where pDayOfWeek = 2 order by pParaN";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    connection.Open();
                    var myDataReader = cmd.ExecuteReader();
                    while (myDataReader.Read())
                    {
                        int N;
                        string Name;
                        bool Ch = true;
                        int dayOfWeek;
                        Name = myDataReader["pName"].ToString();
                        dayOfWeek = int.Parse(myDataReader["pDayOfWeek"].ToString());
                        N = int.Parse(myDataReader["pParaN"].ToString());
                        //Ch = bool.Parse(myDataReader["pCH"].ToString());
                        Console.WriteLine($"{N} - {Name} - {dayOfWeek} - {Ch}");
                    }
                }

                catch (SqlException sqlException)
                {
                    //Console.WriteLine(sqlException);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}