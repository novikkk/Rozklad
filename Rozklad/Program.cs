using System;
using System.Data;
using System.Data.SqlClient;

namespace Rozklad
{
    internal class Program
    {
        private static readonly string connectionString =
            "Data Source=SQL5026.Smarterasp.net;Initial Catalog=DB_9FEAE4_rozklad;User Id=DB_9FEAE4_rozklad_admin;Password=q1234567";

        public static void GetMondaySchedule()
        {
            try
            {
                var connection = new SqlConnection(connectionString);

                var cmd = new SqlCommand();
                cmd.CommandText = "SELECT " +
                                  "[pName] ," +
                                  "[pParaN] ," +
                                  "[pDayOfWeek] ," +
                                  "[pCH] " +
                                  "FROM tParu where pDayOfWeek = 1 order by pParaN";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                connection.Open();
                var myDataReader = cmd.ExecuteReader();
                while (myDataReader.Read())
                {
                    int N;
                    string Name;
                    var Ch = true;
                    int dayOfWeek;
                    Name = myDataReader["pName"].ToString();
                    dayOfWeek = int.Parse(myDataReader["pDayOfWeek"].ToString());
                    N = int.Parse(myDataReader["pParaN"].ToString());
                    //Ch = bool.Parse(myDataReader["pCH"].ToString());
                    Console.Write(N + " - " + Name + " - ");
                    switch (dayOfWeek)
                    {
                        case 1:
                            Console.WriteLine(DayOfWeek.Monday);
                            break;
                        case 2:
                            Console.WriteLine(DayOfWeek.Thursday);
                            break;
                        case 3:
                            Console.WriteLine(DayOfWeek.Wednesday);
                            break;
                        case 4:
                            Console.WriteLine(DayOfWeek.Thursday);
                            break;
                        case 5:
                            Console.WriteLine(DayOfWeek.Friday);
                            break;
                        case 6:
                            Console.WriteLine(DayOfWeek.Saturday);
                            break;
                        case 7:
                            Console.WriteLine(DayOfWeek.Sunday);
                            break;
                    }
                }
            }
            catch (SqlException sqlException)
            {
                //Console.WriteLine(sqlException);
            }
        }

        public static void GetAllSchedule()
        {
            try
            {
                var connection = new SqlConnection(connectionString);


                var cmd = new SqlCommand();
                cmd.CommandText = "SELECT " +
                                  "[pName] ," +
                                  "[pParaN] ," +
                                  "[pDayOfWeek] ," +
                                  "[pCH] " +
                                  "FROM tParu order by pDayOfWeek,pParaN";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                connection.Open();
                var myDataReader = cmd.ExecuteReader();
                while (myDataReader.Read())
                {
                    int N;
                    string Name;
                    var Ch = true;
                    int dayOfWeek;
                    Name = myDataReader["pName"].ToString();
                    dayOfWeek = int.Parse(myDataReader["pDayOfWeek"].ToString());
                    N = int.Parse(myDataReader["pParaN"].ToString());
                    //Ch = bool.Parse(myDataReader["pCH"].ToString());
                    Console.Write(N + " - " + Name + " - ");
                    switch (dayOfWeek)
                    {
                        case 1:
                            Console.WriteLine(DayOfWeek.Monday);
                            break;
                        case 2:
                            Console.WriteLine(DayOfWeek.Tuesday);
                            break;
                        case 3:
                            Console.WriteLine(DayOfWeek.Wednesday);
                            break;
                        case 4:
                            Console.WriteLine(DayOfWeek.Thursday);
                            break;
                        case 5:
                            Console.WriteLine(DayOfWeek.Friday);
                            break;
                        case 6:
                            Console.WriteLine(DayOfWeek.Saturday);
                            break;
                        case 7:
                            Console.WriteLine(DayOfWeek.Sunday);
                            break;
                    }
                }
            }
            catch (SqlException sqlException)
            {
                //Console.WriteLine(sqlException);
            }
        }


        private static void Main(string[] args)
        {
            Console.WriteLine("All schedule");
            GetAllSchedule();
            Console.WriteLine();
            Console.WriteLine("Monday schedule");
            GetMondaySchedule();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}