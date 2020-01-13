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
    class Program2
    {
        public static string response1;
        public static string response2;
        public static string response3;
        public static string response4;
        public static string response5;
        public static string response6;
        public static string response7;
        public static string response8;
        public static string response9;
        public static string response10;
        public static string Surprise;
        public static string Scottdale;
        public static string SaintRose;
        public static string RedRock;
        public static string Chandler;
        public static string Mesa;
        public static string Phoenix;
        public static string Tucson;
        public static string Yuma;
        public static string Brainburg;
        public static SQLiteConnection myConnection;
        static System.Threading.Timer timer;





        public static async void GetTimer1()
        {


            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(5);

            timer = new System.Threading.Timer((e) =>
            {
                GetOnlineBD1();
            }, null, startTimeSpan, periodTimeSpan);
        }


        //static async v connectdb()
        //{
        //    myConnection = new SQLiteConnection("Data Source=database.sqlite3");
        //    myConnection.Open();
        //}



        async static void GetOnlineBD1()
        {
            await Task.Run(() =>
            {
                GetOnlineSurprise();
                GetOnlineScottdale();
                GetOnlineSaintRose();
                GetOnlineChandler();
                GetOnlineRedRock();
                GetOnlineMesa();
                GetOnlineTucson();
                GetOnlinePhoenix();
                GetOnlineYuma();
                GetOnlineBrainburg();



                myConnection = new SQLiteConnection("Data Source=database.sqlite3");

                if (!File.Exists("./database.sqlite3"))
                {


                    SQLiteConnection.CreateFile("database.sqlite3");
                }
                string query = "UPDATE online1 SET online = @Surprise WHERE name = 'Surprise'; UPDATE online1 SET online = @Scottdale WHERE name = 'Scottdale'; UPDATE online1 SET online = @SaintRose WHERE name = 'SaintRose'; UPDATE online1 SET online = @RedRock WHERE name = 'RedRock'; UPDATE online1 SET online = @Chandler WHERE name = 'Chandler'; UPDATE online1 SET online = @Phoenix WHERE name = 'Phoenix'; UPDATE online1 SET online = @Tucson WHERE name = 'Tucson'; UPDATE online1 SET online = @Yuma WHERE name = 'Yuma'; UPDATE online1 SET online = @Brainburg WHERE name = 'Brainburg'";
                SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@Surprise", Surprise);
                myCommand.Parameters.AddWithValue("@Scottdale", Scottdale);
                myCommand.Parameters.AddWithValue("@SaintRose", SaintRose);
                myCommand.Parameters.AddWithValue("@RedRock", RedRock);
                myCommand.Parameters.AddWithValue("@Chandler", Chandler);
                myCommand.Parameters.AddWithValue("@Phoenix", Phoenix);
                myCommand.Parameters.AddWithValue("@Tucson", Tucson);
                myCommand.Parameters.AddWithValue("@Yuma", Yuma);
                myCommand.Parameters.AddWithValue("@Brainburg", Brainburg);
                var result = myCommand.ExecuteNonQuery();
                myConnection.Close();

            });

        }



        async public static void GetOnline2()
        {
            await Task.Run(() =>
            {
                string query = "SELECT online FROM online1";
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


                MesSend.Send("Surprise: " + onlineList[0] + "/1000" + "\n" + "Scottdale: " + onlineList[1] + "/1000" + "\n" + "SaintRose: " + onlineList[2] + "/1000" + "\n" + "Chandler: " + onlineList[3] + "/1000" + "\n" + "Red-Rock: " + onlineList[4] + "/1000" + "\n" + "Mesa: " + onlineList[5] + "/1000" + "\n" + "Phoenix: " + onlineList[5] + "/1000" + "\n" + "Tucson: " + onlineList[6] + "/1000" + "\n" + "Yuma: " + onlineList[7] + "/1000" + "\n" + "Brainburg: " + onlineList[8] + "/1000");

            });
        }








        public static string GetOnlineSurprise()
        {

            var danni = new HttpRequest();
            try
            {
                response1 = danni.Get("http://monitor.sacnr.com/api/?IP=185.169.134.109&Port=7777&Format=JSON&Action=info").ToString();
            }

            catch (Exception ex)
            {
                Surprise = "0";
            }
            finally
            {
                JObject json = JObject.Parse(response1);
                Surprise = (Convert.ToString(json["Players"]));
            }

            return Surprise;
        }
        public static string GetOnlineScottdale()
        {

            var danni = new HttpRequest();
            try
            {
                response2 = danni.Get("http://monitor.sacnr.com/api/?IP=185.169.134.43&Port=7777&Format=JSON&Action=info").ToString();
            }
            catch (Exception ex)
            {
                Scottdale = "0";
            }
            finally
            {

                JObject json = JObject.Parse(response2);
                Scottdale = (Convert.ToString(json["Players"]));
            }
            return Scottdale;
        }
        public static string GetOnlineSaintRose()
        {

            var danni = new HttpRequest();
            try
            {
                response3 = danni.Get("http://monitor.sacnr.com/api/?IP=185.169.134.5&Port=7777&Format=JSON&Action=info").ToString();
            }
            catch (Exception ex)
            {
                SaintRose = "0";
            }
            finally
            {
                JObject json = JObject.Parse(response3);
                SaintRose = (Convert.ToString(json["Players"]));
            }
            return SaintRose;
        }
        public static string GetOnlineChandler()
        {

            var danni = new HttpRequest();
            try
            {
                response4 = danni.Get("http://monitor.sacnr.com/api/?IP=185.169.134.44&Port=7777&Format=JSON&Action=info").ToString();
            }
            catch (Exception ex)
            {
                Chandler = "0";
            }
            finally
            {
                JObject json = JObject.Parse(response4);
                Chandler = (Convert.ToString(json["Players"]));
            }
            return Chandler;
        }
        public static string GetOnlineRedRock()
        {

            var danni = new HttpRequest();
            try
            {
                response5 = danni.Get("http://monitor.sacnr.com/api/?IP=185.169.134.61&Port=7777&Format=JSON&Action=info").ToString();
            }
            catch (Exception ex)
            {
                RedRock = "0";
            }
            finally
            {
                JObject json = JObject.Parse(response5);
                RedRock = (Convert.ToString(json["Players"]));
            }
            return RedRock;
        }
        public static string GetOnlineMesa()
        {

            var danni = new HttpRequest();
            try
            {
                response6 = danni.Get("http://monitor.sacnr.com/api/?IP=185.169.134.59&Port=7777&Format=JSON&Action=info").ToString();
            }
            catch (Exception ex)
            {
                Mesa = "0";
            }
            finally
            {

                JObject json = JObject.Parse(response6);
                Mesa = (Convert.ToString(json["Players"]));
            }
            return Mesa;
        }
        public static string GetOnlinePhoenix()
        {

            var danni = new HttpRequest();
            try
            {
                response7 = danni.Get("http://monitor.sacnr.com/api/?IP=185.169.134.3&Port=7777&Format=JSON&Action=info").ToString();
            }
            catch (Exception ex)
            {
                Phoenix = "0";
            }
            finally
            {

                JObject json = JObject.Parse(response7);
                Phoenix = (Convert.ToString(json["Players"]));
            }
            return Phoenix;
        }
        public static string GetOnlineTucson()
        {

            var danni = new HttpRequest();
            try
            {
                response8 = danni.Get("http://monitor.sacnr.com/api/?IP=185.169.134.4&Port=7777&Format=JSON&Action=info").ToString();
            }
            catch (Exception ex)
            {
                Tucson = "0";
            }
            finally
            {

                JObject json = JObject.Parse(response8);
                Tucson = (Convert.ToString(json["Players"]));
            }
            return Tucson;
        }
        public static string GetOnlineYuma()
        {

            var danni = new HttpRequest();
            try
            {
                response9 = danni.Get("http://monitor.sacnr.com/api/?IP=185.169.134.107&Port=7777&Format=JSON&Action=info").ToString();
            }
            catch (Exception ex)
            {
                Yuma = "0";
            }
            finally
            {

                JObject json = JObject.Parse(response9);
                Yuma = (Convert.ToString(json["Players"]));
            }
            return Yuma;
        }
        public static string GetOnlineBrainburg()
        {

            var danni = new HttpRequest();
            try
            {
                response10 = danni.Get("http://monitor.sacnr.com/api/?IP=185.169.134.45&Port=7777&Format=JSON&Action=info").ToString();
            }
            catch (Exception ex)
            {
                Brainburg = "0";
            }
            finally
            {

                JObject json = JObject.Parse(response10);
                Brainburg = (Convert.ToString(json["Players"]));
            }
            return Yuma;
        }

    }
}

