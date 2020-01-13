using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;
using System.Threading;
using Newtonsoft.Json.Linq;
using System.Data.SQLite;

using System.IO;
using System.Drawing;
using System.Diagnostics;


namespace TestBot.Rabota
{
    class Program
    {
        public static SQLiteConnection myConnection;
 
        public static string response1;
        public static string response2;
        public static string response3;
        public static string response4;
        public static string response5;
        public static string response6;
        public static string Emerald;
        public static string Trilliant;
        public static string Crystal;
        public static string Sapphire;
        public static string Amber;
        public static string Ruby;
        public static string[] online1;


        static System.Threading.Timer timer;
        public static async void GetTimer()
        {
            

            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(5);

            timer = new System.Threading.Timer((e) =>
            {
                GetOnlineBD();
            }, null, startTimeSpan, periodTimeSpan);
        }



        async static void GetOnlineBD()
        {
            await Task.Run(() =>
            {
                GetOnlineE();
                GetOnlineA();
                GetOnlineC();
                GetOnlineR();
                GetOnlineT();
                GetOnlineS();
                myConnection = new SQLiteConnection("Data Source=database.sqlite3");
                if (!File.Exists("./database.sqlite3"))
                {


                    SQLiteConnection.CreateFile("database.sqlite3");
                }
                string query = "UPDATE online SET online = @Emerald WHERE name = 'Emerald'; UPDATE online SET online = @Trilliant WHERE name = 'Trilliant'; UPDATE online SET online = @Amber WHERE name = 'Amber'; UPDATE online SET online = @Ruby WHERE name = 'Ruby'; UPDATE online SET online = @Sapphire WHERE name = 'Sapphire'; UPDATE online SET online = @Crystal WHERE name = 'Crystal'";
                SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@Emerald", Emerald);
                myCommand.Parameters.AddWithValue("@Trilliant", Trilliant);
                myCommand.Parameters.AddWithValue("@Ruby", Ruby);
                myCommand.Parameters.AddWithValue("@Crystal", Crystal);
                myCommand.Parameters.AddWithValue("@Sapphire", Sapphire);
                myCommand.Parameters.AddWithValue("@Amber", Amber);
                var result = myCommand.ExecuteNonQuery();
                myConnection.Close();
            });


        }
        async public static void GetOnline1()
        {
            await Task.Run(() =>
            {
                string query = "SELECT online FROM online";
                SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);

                myConnection.Open();


                SQLiteDataReader result = myCommand.ExecuteReader();
                var onlineList = new List<string>();


                if (result.HasRows)
                {

                    while (result.Read())
                    {


                        onlineList.Add(result["online"].ToString());

                        //result["online"] to string array?


                    }
                    onlineList.ToArray();
                    Console.WriteLine(onlineList[0]);
                }
                myConnection.Close();




                Rabota.MessageSend MesSend = new Rabota.MessageSend();


                MesSend.Send("Emerald: " + onlineList[0] + "/1000" + "\n" + "Amber: " + onlineList[1] + "/1000" + "\n" + "Trilliant: " + onlineList[2] + "/1000" + "\n" + "Crystal: " + onlineList[3] + "/1000" + "\n" + "Sapphire: " + onlineList[4] + "/1000" + "\n" + "Ruby: " + onlineList[5] + "/1000");


            });
        }

        public static string GetOnlineE()
        {
            
            var danni = new HttpRequest();
            try
            {
               response1 = danni.Get("http://monitor.sacnr.com/api/?IP=194.61.44.61&Port=7777&Format=JSON&Action=info").ToString();
            }

            catch (Exception ex)
            {
                Emerald = "0";
            }
            finally
            {


                JObject json = JObject.Parse(response1);
                Emerald = (Convert.ToString(json["Players"]));

            }

            return Emerald;
        }
        public static string GetOnlineT()
        {

            var danni = new HttpRequest();
            try
            {
                 response2 = danni.Get("http://monitor.sacnr.com/api/?IP=5.254.123.4&Port=7777&Format=JSON&Action=info").ToString();
            }
            catch (Exception ex)
            {
                Trilliant = "0";
            }
            finally
            {

                JObject json = JObject.Parse(response2);
                Trilliant = (Convert.ToString(json["Players"]));
            }
            return Trilliant;
        }
        public static string GetOnlineC()
        {

            var danni = new HttpRequest();
            try
            {
                 response3 = danni.Get("http://monitor.sacnr.com/api/?IP=194.61.44.64&Port=7777&Format=JSON&Action=info").ToString();
            }
            catch (Exception ex)
            {
                Crystal = "0";
            }
            finally
            {
                JObject json = JObject.Parse(response3);
                Crystal = (Convert.ToString(json["Players"]));
            }
            return Crystal;
        }
        public static string GetOnlineS()
        {

            var danni = new HttpRequest();
            try
            {
                response4 = danni.Get("http://monitor.sacnr.com/api/?IP=5.254.123.6&Port=7777&Format=JSON&Action=info").ToString();
            }
            catch (Exception ex)
            {
                Sapphire = "0";
            }
            finally
            {
                JObject json = JObject.Parse(response4);
                Sapphire = (Convert.ToString(json["Players"]));
            }
            return Sapphire;
        }
        public static string GetOnlineA()
        {

            var danni = new HttpRequest();
            try
            {
                response5 = danni.Get("http://monitor.sacnr.com/api/?IP=194.61.44.67&Port=7777&Format=JSON&Action=info").ToString();
            }
            catch (Exception ex)
            {
                Amber = "0";
            }
            finally
            {
                JObject json = JObject.Parse(response5);
                Amber = (Convert.ToString(json["Players"]));
            }
            return Amber;
        }
        public static string GetOnlineR()
        {

            var danni = new HttpRequest();
            try
            {
                response6 = danni.Get("http://monitor.sacnr.com/api/?IP=194.61.44.68&Port=7777&Format=JSON&Action=info").ToString();
            }
            catch (Exception ex)
            {
                Ruby = "0";
            }
            finally
            {

                JObject json = JObject.Parse(response6);
                Ruby = (Convert.ToString(json["Players"]));
            }
            return Ruby;
        }
    }
}

