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
        public bool on = true;
        public static string response2;
        public static string response3;
        public static string response4;
        public static string response5;
        public static string response6;
        public static string response7;
        public static string response8;
        public static string response9;
        public static string response10;
        public static string richi = "1";
        public static string nemesis = "1";
        public static string elevator = "1";
        public static string elevator1 = "1";
        public static string elevator2 = "1";
        public static string rofl = "1";
        public static string docent = "1";
        public static string nathan = "1";

        public static string token = "0";

        public static SQLiteConnection myConnection;
        static System.Threading.Timer timer;





        public static async void GetTimer1()
        {


            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(60);

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
                myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                if (!File.Exists("./tte_bot.sqlite3"))
                {


                    SQLiteConnection.CreateFile("tte_bot.sqlite3");
                }
                string query = "UPDATE online SET live = @richi WHERE name = 'richi'; UPDATE online SET live = @nemesis WHERE name = 'nemesis'; UPDATE online SET live = @elevator WHERE name = 'elevator'; UPDATE online SET live = @elevator1 WHERE name = 'elevator1'; UPDATE online SET live = @elevator2 WHERE name = 'elevator2'; UPDATE online SET live = @rofl WHERE name = 'rofl'; UPDATE online SET live = @docent WHERE name = 'docent'; UPDATE online SET live = @nathan WHERE name = 'nathan'";
                SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@richi", richi);
                myCommand.Parameters.AddWithValue("@nemesis", nemesis);
                myCommand.Parameters.AddWithValue("@elevator", elevator);
                myCommand.Parameters.AddWithValue("@elevator1", elevator1);
                myCommand.Parameters.AddWithValue("@elevator2", elevator2);
                myCommand.Parameters.AddWithValue("@rofl", rofl);
                myCommand.Parameters.AddWithValue("@docent", docent);
                myCommand.Parameters.AddWithValue("@nathan", nathan);
                var result = myCommand.ExecuteNonQuery();
                myConnection.Close();

                GetOnlineSurprise();
                GetOnlineScottdale();
                GetOnlineChandler();
                GetOnlineChandler1();
                GetOnlineChandler2();
                GetOnlineChandler3();
                GetOnlineChandler4();
                GetOnlineChandler5();




            });

        }





        public static string GetOnlineSurprise()
        {

            var danni = new HttpRequest();
            danni.AddHeader("Client-ID", "f7eeegwu0xe6hpa9o6ntad48i3au1o"); //клиент айди
            danni.AddHeader("Authorization", "Bearer " + token);
            danni.UserAgent = Http.OperaUserAgent();
            danni.Cookies = new CookieDictionary();
            danni.KeepAlive = true;

            try
            {
                response1 = danni.Get("https://api.twitch.tv/helix/streams?user_login=richiking").ToString();
                JObject json = JObject.Parse(response1);
                richi = Convert.ToString(json["data"].Count());
            }

            catch (Exception ex)
            {
                UpdateToken();
                GetOnlineSurprise();
            }

            myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");
            string query = "SELECT live FROM online WHERE name = 'richi'";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);

            myConnection.Open();

            SQLiteDataReader result = myCommand.ExecuteReader();
            var onlineList = new List<string>();


            if (result.HasRows)
            {

                while (result.Read())
                {


                    onlineList.Add(result["live"].ToString());

                    //result["online"] to string array?


                }
                onlineList.ToArray();
                Console.WriteLine(onlineList[0]);
            }
            myConnection.Close();

            if (onlineList[0] == "0")
            {
                if (richi == "1")
                {
                    Rabota.MessageSendStream MesSend = new Rabota.MessageSendStream();
                    MesSend.Send("На канале Ричи пошло развитие!" + "\n" + "https://www.twitch.tv/richiking", "photo-195044271_457239019");
                }

            }
            return richi;
        }
        public static string GetOnlineScottdale()
        {

            var danni = new HttpRequest();
            danni.AddHeader("Client-ID", "f7eeegwu0xe6hpa9o6ntad48i3au1o");
            danni.AddHeader("Authorization", "Bearer " + token);
            danni.UserAgent = Http.OperaUserAgent();
            danni.Cookies = new CookieDictionary();
            danni.KeepAlive = true;

            try
            {
                response1 = danni.Get("https://api.twitch.tv/helix/streams?user_login=nemesis_tv").ToString();
                JObject json = JObject.Parse(response1);
                nemesis = Convert.ToString(json["data"].Count());
            }

            catch (Exception ex)
            {
                UpdateToken();
                return "";
            }
           
            myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");
            string query = "SELECT live FROM online WHERE name = 'nemesis'";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);

            myConnection.Open();

            SQLiteDataReader result = myCommand.ExecuteReader();
            var onlineList = new List<string>();


            if (result.HasRows)
            {

                while (result.Read())
                {


                    onlineList.Add(result["live"].ToString());

                    //result["online"] to string array?


                }
                onlineList.ToArray();
                Console.WriteLine(onlineList[0]);
            }
            myConnection.Close();

            if (onlineList[0] == "0")
            {
                if (nemesis == "1")
                {
                    Rabota.MessageSendStream MesSend = new Rabota.MessageSendStream();
                    MesSend.Send("Змирля запустила поток" + "\n" + "https://www.twitch.tv/nemesis_tv", "photo-195044271_457239018");
                }

            }
            return nemesis;
        }
        public static string GetOnlineChandler()
        {

            var danni = new HttpRequest();
            danni.AddHeader("Client-ID", "f7eeegwu0xe6hpa9o6ntad48i3au1o");
            danni.AddHeader("Authorization", "Bearer " + token);
            danni.UserAgent = Http.OperaUserAgent();
            danni.Cookies = new CookieDictionary();
            danni.KeepAlive = true;

            try
            {
                response1 = danni.Get("https://api.twitch.tv/helix/streams?user_login=nemesis_sin_gavna").ToString();
                JObject json = JObject.Parse(response1);
                elevator = Convert.ToString(json["data"].Count());
            }

            catch (Exception ex)
            {
                UpdateToken();
                elevator = "1";
            }
          
            myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");
            string query = "SELECT live FROM online WHERE name = 'elevator'";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);

            myConnection.Open();

            SQLiteDataReader result = myCommand.ExecuteReader();
            var onlineList = new List<string>();


            if (result.HasRows)
            {

                while (result.Read())
                {


                    onlineList.Add(result["live"].ToString());

                    //result["online"] to string array?


                }
                onlineList.ToArray();
                Console.WriteLine(onlineList[0]);
            }
            myConnection.Close();

            if (onlineList[0] == "0")
            {
                if (elevator == "1")
                {
                    Rabota.MessageSendStream MesSend = new Rabota.MessageSendStream();
                    MesSend.Send("Некий B.V стартанул поток на твиче" + "\n" + "https://www.twitch.tv/nemesis_sin_gavna", "photo-195044271_457239022");
                }

            }
            return elevator;
        }
    
    public static string GetOnlineChandler1()
    {

        var danni = new HttpRequest();
        danni.AddHeader("Client-ID", "f7eeegwu0xe6hpa9o6ntad48i3au1o");
        danni.UserAgent = Http.OperaUserAgent();
        danni.Cookies = new CookieDictionary();
        danni.KeepAlive = true;

        try
        {
               danni.Get("https://www.youtube.com/channel/UCPASCsJ6ISdHhQtv6vv5gYQ").ToString();
        }

        catch (Exception ex)
        {
            elevator1 = "1";
        }
        finally
        {
                string response1 = danni.Get("https://www.youtube.com/channel/UCPASCsJ6ISdHhQtv6vv5gYQ").ToString();
                if (response1.Contains("В эфире"))
                {
                    elevator1 = "1";
                }else
                {
                    elevator1 = "0";
                }
               
            }
        myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");
        string query = "SELECT live FROM online WHERE name = 'elevator1'";
        SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);

        myConnection.Open();

        SQLiteDataReader result = myCommand.ExecuteReader();
        var onlineList = new List<string>();


        if (result.HasRows)
        {

            while (result.Read())
            {


                onlineList.Add(result["live"].ToString());

                //result["online"] to string array?


            }
            onlineList.ToArray();
            Console.WriteLine(onlineList[0]);
        }
        myConnection.Close();

        if (onlineList[0] == "0")
        {
            if (elevator1 == "1")
            {
                    Rabota.MessageSendStream MesSend = new Rabota.MessageSendStream();
                    MesSend.Send("Виталя вышел в эфир на ЮТУБЕ!" + "\n" + "https://www.youtube.com/channel/UCPASCsJ6ISdHhQtv6vv5gYQ", "photo-195044271_457239022");
            }

        }
        return elevator1;
    }
        public static string GetOnlineChandler2()
        {

            var danni = new HttpRequest();
            danni.AddHeader("Client-ID", "f7eeegwu0xe6hpa9o6ntad48i3au1o");
            danni.AddHeader("Authorization", "Bearer " + token);
            danni.UserAgent = Http.OperaUserAgent();
            danni.Cookies = new CookieDictionary();
            danni.KeepAlive = true;

            try
            {
                response1 = danni.Get("https://api.twitch.tv/helix/streams?user_login=elevator_king").ToString();
                JObject json = JObject.Parse(response1);
                elevator2 = Convert.ToString(json["data"].Count());
            }

            catch (Exception ex)
            {
                UpdateToken();
                elevator2 = "1";
            }
            myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");
            string query = "SELECT live FROM online WHERE name = 'elevator2'";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);

            myConnection.Open();

            SQLiteDataReader result = myCommand.ExecuteReader();
            var onlineList = new List<string>();


            if (result.HasRows)
            {

                while (result.Read())
                {


                    onlineList.Add(result["live"].ToString());

                    //result["online"] to string array?


                }
                onlineList.ToArray();
                Console.WriteLine(onlineList[0]);
            }
            myConnection.Close();

            if (onlineList[0] == "0")
            {
                if (elevator2 == "1")
                {
                    Rabota.MessageSendStream MesSend = new Rabota.MessageSendStream();
                    MesSend.Send("Некий B.V стартанул поток на твиче" + "\n" + "https://www.twitch.tv/elevator_king", "photo-195044271_457239022");
                }

            }
            return elevator2;
        }
        public static string GetOnlineChandler3()
        {

            var danni = new HttpRequest();
            danni.AddHeader("Client-ID", "f7eeegwu0xe6hpa9o6ntad48i3au1o");
            danni.AddHeader("Authorization", "Bearer " + token);
            danni.UserAgent = Http.OperaUserAgent();
            danni.Cookies = new CookieDictionary();
            danni.KeepAlive = true;

            try
            {
                response1 = danni.Get("https://api.twitch.tv/helix/streams?user_login=irofl").ToString();
                JObject json = JObject.Parse(response1);
                rofl = Convert.ToString(json["data"].Count());
            }

            catch (Exception ex)
            {
                UpdateToken();
                rofl = "1";
            }
           
            myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");
            string query = "SELECT live FROM online WHERE name = 'rofl'";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);

            myConnection.Open();

            SQLiteDataReader result = myCommand.ExecuteReader();
            var onlineList = new List<string>();


            if (result.HasRows)
            {

                while (result.Read())
                {


                    onlineList.Add(result["live"].ToString());

                    //result["online"] to string array?


                }
                onlineList.ToArray();
                Console.WriteLine(onlineList[0]);
            }
            myConnection.Close();

            if (onlineList[0] == "0")
            {
                if (rofl == "1")
                {
                    Rabota.MessageSendStream MesSend = new Rabota.MessageSendStream();
                    MesSend.Send("ROFL стартанул на твиче" + "\n" + "https://www.twitch.tv/irofl", "photo-195044271_457239023");
                }

            }
            return rofl;
        }
        public static string GetOnlineChandler4()
        {

            var danni = new HttpRequest();
            danni.AddHeader("Client-ID", "f7eeegwu0xe6hpa9o6ntad48i3au1o");
            danni.AddHeader("Authorization", "Bearer " + token);
            danni.UserAgent = Http.OperaUserAgent();
            danni.Cookies = new CookieDictionary();
            danni.KeepAlive = true;

            try
            {
                response1 = danni.Get("https://api.twitch.tv/helix/streams?user_login=cvrnvgge4444").ToString();
                JObject json = JObject.Parse(response1);
                docent = Convert.ToString(json["data"].Count());
            }

            catch (Exception ex)
            {
                UpdateToken();
                docent = "1";
            }
           
            myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");
            string query = "SELECT live FROM online WHERE name = 'docent'";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);

            myConnection.Open();

            SQLiteDataReader result = myCommand.ExecuteReader();
            var onlineList = new List<string>();


            if (result.HasRows)
            {

                while (result.Read())
                {


                    onlineList.Add(result["live"].ToString());

                    //result["online"] to string array?


                }
                onlineList.ToArray();
                Console.WriteLine(onlineList[0]);
            }
            myConnection.Close();

            if (onlineList[0] == "0")
            {
                if (docent == "1")
                {
                    Rabota.MessageSendStream MesSend = new Rabota.MessageSendStream();
                    MesSend.Send("DOCENT запустился на твиче" + "\n" + "https://www.twitch.tv/cvrnvgge4444/", "photo-195044271_457239024");
                }

            }
            return docent;
        }
        public static string GetOnlineChandler5()
        {

            var danni = new HttpRequest();
            danni.AddHeader("Client-ID", "f7eeegwu0xe6hpa9o6ntad48i3au1o");
            danni.AddHeader("Authorization", "Bearer " + token);
            danni.UserAgent = Http.OperaUserAgent();
            danni.Cookies = new CookieDictionary();
            danni.KeepAlive = true;

            try
            {
                response1 = danni.Get("https://api.twitch.tv/helix/streams?user_login=nathangtq").ToString();
                JObject json = JObject.Parse(response1);
                nathan = Convert.ToString(json["data"].Count());
            }

            catch (Exception ex)
            {
                UpdateToken();
                nathan = "1";
            }
           
            myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");
            string query = "SELECT live FROM online WHERE name = 'nathan'";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);

            myConnection.Open();

            SQLiteDataReader result = myCommand.ExecuteReader();
            var onlineList = new List<string>();


            if (result.HasRows)
            {

                while (result.Read())
                {


                    onlineList.Add(result["live"].ToString());

                    //result["online"] to string array?


                }
                onlineList.ToArray();
                Console.WriteLine(onlineList[0]);
            }
            myConnection.Close();

            if (onlineList[0] == "0")
            {
                if (nathan == "1")
                {
                    Rabota.MessageSendStream MesSend = new Rabota.MessageSendStream();
                    MesSend.Send("NathanGtq начал развиваться на твиче" + "\n" + "https://www.twitch.tv/nathangtq", "photo-195044271_457239025");
                }

            }
            return nathan;
        }

        public static void UpdateToken()
        {
            var danni = new HttpRequest();
            //danni.AddHeader("Client-ID", "f7eeegwu0xe6hpa9o6ntad48i3au1o");
            //danni.AddHeader("Authorization", "Bearer dsr51cfseqjygyuh7gjset27aeynui");
            danni.UserAgent = Http.OperaUserAgent();
            danni.Cookies = new CookieDictionary();
            danni.KeepAlive = true;
            string response = danni.Post("https://id.twitch.tv/oauth2/token?client_id=f7eeegwu0xe6hpa9o6ntad48i3au1o&client_secret=dsr51cfseqjygyuh7gjset27aeynui&grant_type=client_credentials").ToString();
            JObject json = JObject.Parse(response);
            token = Convert.ToString(json["access_token"]);
        }



    }
       

    
}

