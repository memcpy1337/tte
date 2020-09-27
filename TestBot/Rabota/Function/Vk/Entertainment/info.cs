using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using TestBot.Rabota.Vk.Users;
using xNet;

namespace TestBot.Rabota.Function.Vk.Entertainment
{
    class info
    {
        public static SQLiteConnection myConnection;
        /* public static string GetInfo(string[] Razdelil)
         {
             Rabota.MessageSend MesSend = new Rabota.MessageSend();
             if(Razdelil.Count() == 1)
             {
                 MesSend.Send(Rabota.Vk.Users.UsersGetVk.Get());
             }else if(Razdelil.Count() == 2)
             {
                 if (Razdelil[1].Contains("https://vk.com/id"))
                     Razdelil[1] = Razdelil[1].Replace("https://vk.com/id", "");
                 else
                     Razdelil[1] = Razdelil[1].Replace("https://vk.com/", "");
                 MesSend.Send(Rabota.Vk.Users.UsersGetVk.Get(Razdelil[1]));
             }
             return "";
         }
         */
        public static string GetPidor(string[] Razdelil, int idPols, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(0, 100);
           
                MesSend.Send(data, TestBot.Rabota.Vk.Users.UsersGetVk.Get(idPols, data) + " болен циррозом на " + random1 + "%");
            
            return "";
        }
        public static string CheckRang(Variables data)
        {
            string output = "";
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            try
            {
                myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                
                string query = "SELECT Rang FROM users WHERE id = @command LIMIT 1";
                SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@command", data.IdPols);
               
                myConnection.OpenAsync();


                SQLiteDataReader result = myCommand.ExecuteReader();
                var onlineList = new List<string>();


                if (result.HasRows)
                {

                    while (result.Read())
                    {


                        onlineList.Add(result["Rang"].ToString());

                        //result["online"] to string array?


                    }
                    onlineList.ToArray();
                    Console.WriteLine(onlineList[0]);

                   if (onlineList[0] == "1")
                   {
                        output = "1";
                        UsersGetVk.Delete(data.IdMes, data);
                   }

                    myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                    string query2 = "UPDATE users SET Messages_Number = Messages_Number + 1 WHERE id = @command1";



                    SQLiteCommand myCommand2 = new SQLiteCommand(query2, myConnection);

                    myConnection.OpenAsync();
                    myCommand2.Parameters.AddWithValue("@command1", data.IdPols);
                    Console.WriteLine(myCommand2.ExecuteNonQuery());
                    myConnection.Close();


                }
                else
                {
                    string query1 = "INSERT INTO users (id, Name) VALUES (@id, @Name)";

                    SQLiteCommand myCommand1 = new SQLiteCommand(query1, myConnection);

                    
                   
                    myCommand1.Parameters.AddWithValue("@id", data.IdPols);
                    myCommand1.Parameters.AddWithValue("@Name", TestBot.Rabota.Vk.Users.UsersGetVk.Get(data.IdPols, data));

                    var result1 = myCommand1.ExecuteNonQuery();
                    Console.WriteLine(Convert.ToString(result1));
                    myConnection.Close();
                }

                myConnection.Close();




            }catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return output;
        }
        public static void Sozdat(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            try
            {
                if (Razdelil[1].Substring(0,2) == "!t")
                {
                    if (data.IdPols.ToString() != "261341610")
                    {
                        MesSend.Send(data, "Только Мэтх может создавать такие команды");
                        return;
                    }


                }
                    myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                if (!File.Exists("./tte_bot.sqlite3"))
                {


                    SQLiteConnection.CreateFile("tte_bot.sqlite3");
                }
                string query = "SELECT Rang FROM users WHERE id = @command LIMIT 1";
                SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@command", data.IdPols);
                myConnection.OpenAsync();


                SQLiteDataReader result = myCommand.ExecuteReader();
                var onlineList = new List<string>();


                if (result.HasRows)
                {

                    while (result.Read())
                    {


                        onlineList.Add(result["Rang"].ToString());

                        //result["online"] to string array?


                    }
                    onlineList.ToArray();
                    Console.WriteLine(onlineList[0]);
                    myConnection.Close();
                    if (Convert.ToInt32(onlineList[0]) >= 4)
                    {

                        string output = "";
                        if (Razdelil.Length < 3)
                        {
                            MesSend.Send(data, "Параметров не может быть меньше 3");
                            return;
                        }
                        for (int i = 2; i < Razdelil.Length; i++)
                        {

                            output += Razdelil[i] + " ";

                        }

                        myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");
                        if (!File.Exists("./tte_bot.sqlite3"))
                        {


                            SQLiteConnection.CreateFile("tte_bot.sqlite3");
                        }
                        string query1 = "INSERT INTO commands (command, text) VALUES (@command, @text)";



                        SQLiteCommand myCommand1 = new SQLiteCommand(query1, myConnection);

                        myConnection.OpenAsync();
                        output = output.Trim();
                        myCommand1.Parameters.AddWithValue("@command", Razdelil[1]);
                        myCommand1.Parameters.AddWithValue("@text", output);
                        var result1 = myCommand1.ExecuteNonQuery();
                        myConnection.Close();



                    }
                    else
                    {
                        MesSend.Send(data, "Создать команду можно с ранга «Фан»");
                    }
                }
                else
                {
                    MesSend.Send(data, "Вы не зарегистрированы");
                }
                
            }
            catch
            {
                MesSend.Send(data, "Ошибка при создании команды.");
            }

        }
        public static void Ydalit(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            try
            {
                if (Razdelil[1].Substring(0, 2) == "!t")
                {
                    if (data.IdPols.ToString() != "261341610")
                    {
                        MesSend.Send(data, "Только Мэтх может удалять такие команды");
                        return;
                    }


                }
                myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                if (!File.Exists("./tte_bot.sqlite3"))
                {

                    SQLiteConnection.CreateFile("tte_bot.sqlite3");
                }
                string query = "SELECT Rang FROM users WHERE id = @command LIMIT 1";
                SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@command", data.IdPols);
                myConnection.OpenAsync();


                SQLiteDataReader result = myCommand.ExecuteReader();
                var onlineList = new List<string>();


                if (result.HasRows)
                {

                    while (result.Read())
                    {


                        onlineList.Add(result["Rang"].ToString());

                        //result["online"] to string array?


                    }
                    onlineList.ToArray();
                    Console.WriteLine(onlineList[0]);
                    myConnection.Close();
                    if (Convert.ToInt32(onlineList[0]) >= 4)
                    {

                        string output = "";
                        if (Razdelil.Length < 2)
                        {
                            MesSend.Send(data, "Параметров не может быть меньше 2");
                            return;
                        }
                        if (Razdelil.Length > 2)
                        {
                            MesSend.Send(data, "Параметров не может быть больше 2");
                            return;
                        }

                        myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");
                      
                        string query1 = "DELETE FROM commands WHERE command = @command1";



                        SQLiteCommand myCommand1 = new SQLiteCommand(query1, myConnection);

                        myConnection.OpenAsync();
                        output = output.Trim();
                        myCommand1.Parameters.AddWithValue("@command1", Razdelil[1]);
                        Console.WriteLine(myCommand1.ExecuteNonQuery());
                        myConnection.Close();
                        MesSend.Send(data, "Ты удалил команду");


                    }
                    else
                    {
                        MesSend.Send(data, "Удалить команду можно с ранга «Фан»");
                    }
                }
                else
                {
                    MesSend.Send(data, "Вы не зарегистрированы");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MesSend.Send(data, "Ошибка при удалении команды.");
            }

        }
        public static void UpRang(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            try
            {
                myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                if (!File.Exists("./tte_bot.sqlite3"))
                {

                    SQLiteConnection.CreateFile("tte_bot.sqlite3");
                }
                string query = "SELECT Rang FROM users WHERE id = @command LIMIT 1";
                SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@command", data.IdPols);
                myConnection.OpenAsync();


                SQLiteDataReader result = myCommand.ExecuteReader();
                var onlineList = new List<string>();


                if (result.HasRows)
                {

                    while (result.Read())
                    {


                        onlineList.Add(result["Rang"].ToString());

                        //result["online"] to string array?


                    }
                    onlineList.ToArray();
                    Console.WriteLine(onlineList[0]);
                    myConnection.Close();

                    if (Convert.ToInt32(onlineList[0]) >= 5)
                    {

                        string output = "";
                        if (Razdelil.Length < 2)
                        {
                            MesSend.Send(data, "Параметров не может быть меньше 2");
                            return;
                        }
                        if (Razdelil.Length > 2)
                        {
                            MesSend.Send(data, "Параметров не может быть больше 2");
                            return;
                        }

                        string[] words = Razdelil[1].Split(new char[] { '|' });
                        string short_name = words[0];
                        short_name = short_name.Substring(1);
                        int user_id = Convert.ToInt32(UsersGetVk.Get(short_name, data));


                        myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                        string query1 = "SELECT Rang FROM users WHERE id = @command LIMIT 1";
                        SQLiteCommand myCommand1 = new SQLiteCommand(query1, myConnection);
                        myCommand1.Parameters.AddWithValue("@command", user_id);
                        myConnection.OpenAsync();


                        SQLiteDataReader result1 = myCommand1.ExecuteReader();
                        var onlineList1 = new List<string>();


                        if (result1.HasRows)
                        {

                            while (result1.Read())
                            {


                                onlineList1.Add(result1["Rang"].ToString());

                                //result["online"] to string array?


                            }
                            onlineList1.ToArray();
                            Console.WriteLine(onlineList1[0]);
                            myConnection.Close();
                            if (Convert.ToInt32(onlineList1[0]) <= 4)
                            {
                                string rang = "";
                                switch (onlineList1[0])
                                {
                                    case "1":
                                        rang = "«Фанат ричи конга»";
                                        break;
                                    case "2":
                                        rang = "«Норм пацан»";
                                        break;
                                    case "3":
                                        rang = "«Фан»";
                                        break;
                                    case "4":
                                        rang = "«Админ»";
                                        break;

                                }

                              

                                myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                                string query2 = "UPDATE users SET rang = rang + 1 WHERE id = @command1";



                                SQLiteCommand myCommand2 = new SQLiteCommand(query2, myConnection);

                                myConnection.OpenAsync();
                                output = output.Trim();
                                myCommand2.Parameters.AddWithValue("@command1", user_id);
                                Console.WriteLine(myCommand2.ExecuteNonQuery());
                                myConnection.Close();

                                MesSend.Send(data, "Ты повысил " + UsersGetVk.Get(user_id, data) + " до ранга " + rang);


                            }
                            else
                            {
                                MesSend.Send(data, "У данного человека и так максимальный ранг");
                            }











                        }
                        else
                        {
                            MesSend.Send(data, "Комманда введена не правильно либо человек не зареган. (!повысить @<id>)");
                        }
                    }
                    else
                    {
                        MesSend.Send(data, "У вас недостаточный ранг для повышения других");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MesSend.Send(data, "Ошибка при повышении.");
            }

        }
        public static void GameAnswer(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            try
            {
                myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                if (!File.Exists("./tte_bot.sqlite3"))
                {

                    SQLiteConnection.CreateFile("tte_bot.sqlite3");
                }
                string query = "SELECT answer FROM games WHERE user = @command LIMIT 1";
                SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@command", data.IdPols);
                myConnection.OpenAsync();


                SQLiteDataReader result = myCommand.ExecuteReader();
                var onlineList = new List<string>();


                if (result.HasRows)
                {

                    while (result.Read())
                    {


                        onlineList.Add(result["answer"].ToString());

                        //result["online"] to string array?


                    }
                    onlineList.ToArray();
                    Console.WriteLine(onlineList[0]);
                    myConnection.Close();
                    if (Razdelil[1] == onlineList[0].ToLower())
                    {
                        myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                        string query1 = "DELETE FROM games WHERE user = @command1";



                        SQLiteCommand myCommand1 = new SQLiteCommand(query1, myConnection);

                        myConnection.OpenAsync();
                        myCommand1.Parameters.AddWithValue("@command1", data.IdPols);
                        Console.WriteLine(myCommand1.ExecuteNonQuery());
                        myConnection.Close();
                        MesSend.Send(data, "Правильный ответ!!!");

                        myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                        myConnection.OpenAsync();
                        string query5 = "UPDATE users SET Banned = Banned + 1 WHERE id = @user";
                        SQLiteCommand myCommand5 = new SQLiteCommand(query5, myConnection);
                        myCommand5.Parameters.AddWithValue("@user", data.IdPols);
  

                        var outpiut = myCommand5.ExecuteNonQuery();
                        myConnection.Close();


                    }
                    else
                    {
                        myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                        string query1 = "DELETE FROM games WHERE user = @command1";



                        SQLiteCommand myCommand1 = new SQLiteCommand(query1, myConnection);

                        myConnection.OpenAsync();
                        myCommand1.Parameters.AddWithValue("@command1", data.IdPols);
                        Console.WriteLine(myCommand1.ExecuteNonQuery());
                        myConnection.Close();

                        MesSend.Send(data, "Неверный ответ");

                    }




                }else
                {
                    MesSend.Send(data, "Не нашел твоего вопроса или время на ответ вышло (15 сек)");
                }

            }
            catch
            {
                MesSend.Send(data, "Че то пошло не так, либо твой вопрос уже стух (10 сек)");
            }
        }
        public static void Duel(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            try
            {
                int rang_usr = RangGet(data.IdPols, data);
                if (!(rang_usr < 3))
                {
                    if (Razdelil.Length == 2)
                    {
                        string[] words = Razdelil[1].Split(new char[] { '|' });
                        string short_name = words[0];
                        short_name = short_name.Substring(1);
                        int user_id = Convert.ToInt32(UsersGetVk.Get(short_name, data));



                        myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                        string query1 = "SELECT user1, user2 FROM duel WHERE user1 = @command OR user2 = @command LIMIT 1";
                        SQLiteCommand myCommand1 = new SQLiteCommand(query1, myConnection);
                        myCommand1.Parameters.AddWithValue("@command", user_id);
                        myConnection.OpenAsync();


                        SQLiteDataReader result1 = myCommand1.ExecuteReader();
                        var onlineList1 = new List<string>();


                        if (result1.HasRows)
                        {

                            MesSend.Send(data, "🤠 Данный человек уже в дуэли с кем-то, или кто то вызвал его");
                        }else
                        {



                            myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                            myConnection.OpenAsync();
                            string query = "INSERT INTO duel(user1, user2, bullet1, bullet2, bullet3, bullet4, bullet5, bullet6, bullet7, last_choose) VALUES(@user1, @user2, @bullet1, @bullet2, @bullet3, @bullet4, @bullet5, @bullet6, @bullet7, @last_choose)";
                            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
                            Random rnd = new Random();
                            int dead = rnd.Next(0, 7);
                            int[] bullets = new int[7];
                            for (int i =0; i <bullets.Length; i++)
                            {
                                bullets[i] = 0;
                            }
                            bullets[dead] = 1;
                            myCommand.Parameters.AddWithValue("@user1", data.IdPols);
                            myCommand.Parameters.AddWithValue("@user2", user_id);
                            myCommand.Parameters.AddWithValue("@bullet1", bullets[0]);
                            myCommand.Parameters.AddWithValue("@bullet2", bullets[1]);
                            myCommand.Parameters.AddWithValue("@bullet3", bullets[2]);
                            myCommand.Parameters.AddWithValue("@bullet4", bullets[3]);
                            myCommand.Parameters.AddWithValue("@bullet5", bullets[4]);
                            myCommand.Parameters.AddWithValue("@bullet6", bullets[5]);
                            myCommand.Parameters.AddWithValue("@bullet7", bullets[6]);
                            myCommand.Parameters.AddWithValue("@last_choose", data.IdPols);
                            var outpiut = myCommand.ExecuteNonQuery();
                            myConnection.Close();
                            result1.Close();
                            MesSend.Send(data, "🤠 Дуэль между " + UsersGetVk.Get(data.IdPols, data) + " и " + UsersGetVk.Get(user_id, data) + " началась!" + "\n" + "Выбери патрон командой !пуля <1-7>. Время на игру 60с.");
                           Task.Delay(60000).ContinueWith(t => DeleteDuel(data.IdPols));
                        }

                    }



                }else
                {
                    
                    MesSend.Send(data, "🤠 Для старта дуэли необходим минимум ранг Нормальный пацан");
                }

               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MesSend.Send(data, "Ошибка");
            }
        }
        public static void GetStats(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            try
            {
                myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");
                string query101 = "SELECT Messages_Number, Rang, Banned, win_duels FROM users WHERE id = @command";
                SQLiteCommand myCommand101 = new SQLiteCommand(query101, myConnection);
                myCommand101.Parameters.AddWithValue("@command", data.IdPols);
                myConnection.OpenAsync();

                SQLiteDataReader result101 = myCommand101.ExecuteReader();
                var onlineList101 = new List<string>();


                if (result101.HasRows)
                {

                    while (result101.Read())
                    {
                        onlineList101.Add(result101["Messages_Number"].ToString());
                        onlineList101.Add(result101["Rang"].ToString());
                        onlineList101.Add(result101["Banned"].ToString());
                        onlineList101.Add(result101["win_duels"].ToString());

                    }

                }
                string rank = "";
                switch (onlineList101[1])
                {
                    case "1":
                        rank = " (Лопата)";
                        break;
                    case "2":
                        rank = " (Фанат Ричи Конга)";
                        break;
                    case "3":
                        rank = " (Нормальный пацан)";
                        break;
                    case "4":
                        rank = " (Фан)";
                        break;
                    case "5":
                        rank = " (Админ)";
                        break;

                }
                MesSend.Send(data, "✅ Статистика для " + UsersGetVk.Get(data.IdPols, data) + "\n" + "‼ Ранг: " + onlineList101[1] + rank + "\n" + "💬 Количество сообщений: " + onlineList101[0] + "\n" + "🎓 Правильных ответов на викторину: " + onlineList101[2] + "\n" + "🤠 Выиграно дуэлей: " + onlineList101[3]);
                result101.Close();
                myConnection.Close();
            }
            catch
            {

            }
        }
                public static void ChooseBullet(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            try
            {
                
                    if (Razdelil.Length == 2)
                    {
                        



                        myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                        string query1 = "SELECT user1, user2 FROM duel WHERE user1 = @command OR user2 = @command LIMIT 1";
                        SQLiteCommand myCommand1 = new SQLiteCommand(query1, myConnection);
                        myCommand1.Parameters.AddWithValue("@command", data.IdPols);
                        myConnection.OpenAsync();


                        SQLiteDataReader result1 = myCommand1.ExecuteReader();
                        var onlineList1 = new List<string>();
                   

                    if (result1.HasRows)
                    {
                        result1.Close();
                        myConnection.Close();
                       

                        myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");
                        string query10 = "SELECT last_choose FROM duel WHERE user1 = @command OR user2 = @command";
                        SQLiteCommand myCommand10 = new SQLiteCommand(query10, myConnection);
                        myCommand10.Parameters.AddWithValue("@command", data.IdPols);
                        myConnection.OpenAsync();

                        SQLiteDataReader result10 = myCommand10.ExecuteReader();
                        var onlineList10 = new List<string>();


                        if (result10.HasRows)
                        {

                            while (result10.Read())
                            {
                                onlineList10.Add(result10["last_choose"].ToString());
                            }
                            
                        }
                        result10.Close();
                        myConnection.Close();
                        if (onlineList10[0] != Convert.ToString(data.IdPols))
                        {







                            myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");
                            string query9 = "SELECT bullet" + Razdelil[1] + " FROM duel WHERE user1 = @command OR user2 = @command LIMIT 1";
                            SQLiteCommand myCommand9 = new SQLiteCommand(query9, myConnection);
                            myCommand9.Parameters.AddWithValue("@command", data.IdPols);
                            myConnection.OpenAsync();


                            SQLiteDataReader result9 = myCommand9.ExecuteReader();
                            var onlineList9 = new List<string>();


                            if (result9.HasRows)
                            {

                                while (result9.Read())
                                {


                                    onlineList9.Add(result9["bullet" + Razdelil[1]].ToString());
                                    Console.WriteLine(result9["bullet" + Razdelil[1]].ToString());
                                    //result["online"] to string array?


                                }

                                onlineList9.ToArray();
                                Console.WriteLine(onlineList9[0]);
                                result9.Close();
                                switch (onlineList9[0])
                                {
                                    case "0":
                                        myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                                        string query8 = "UPDATE duel SET bullet" + Razdelil[1] + " = '2', last_choose = @command1 WHERE user1 = @command1 OR user2 = @command1";



                                        SQLiteCommand myCommand8 = new SQLiteCommand(query8, myConnection);

                                        myConnection.OpenAsync();
                                        myCommand8.Parameters.AddWithValue("@command1", data.IdPols);
                                        Console.WriteLine(myCommand8.ExecuteNonQuery());
                                        myConnection.Close();

                                        MesSend.Send(data, "🤠 " + UsersGetVk.Get(data.IdPols, data) + " ВЫЖАЛ!! Холостой патрон.");
                                        break;
                                    case "1":
                                        myConnection.Close();
                                        

                                        MesSend.Send(data, "🤠 " + UsersGetVk.Get(data.IdPols, data) + " ВЫШИБ себе мозги.");


                                        myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");
                                        string query13 = "SELECT user1, user2 FROM duel WHERE user1 = @command OR user2 = @command LIMIT 1";
                                        SQLiteCommand myCommand13 = new SQLiteCommand(query13, myConnection);
                                        myCommand13.Parameters.AddWithValue("@command", data.IdPols);
                                        myConnection.OpenAsync();


                                        SQLiteDataReader result13 = myCommand13.ExecuteReader();
                                        var onlineList13 = new List<string>();


                                        if (result13.HasRows)
                                        {

                                            while (result13.Read())
                                            {


                                                onlineList13.Add(result13["user1"].ToString());
                                                onlineList13.Add(result13["user2"].ToString());
                                                //result["online"] to string array?


                                            }
                                            result13.Close();
                                            onlineList13.ToArray();
                                            Console.WriteLine(onlineList13[0] + " " + onlineList13[1]);
                                            myConnection.Close();

                                            if (onlineList13[0] == Convert.ToString(data.IdPols))
                                            {

                                                myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                                                string query22 = "UPDATE users SET win_duels = win_duels + 1 WHERE id = @command1";

                                                SQLiteCommand myCommand22 = new SQLiteCommand(query22, myConnection);

                                                myConnection.OpenAsync();

                                                myCommand22.Parameters.AddWithValue("@command1", data.IdPols);
                                                Console.WriteLine(myCommand22.ExecuteNonQuery());
                                                myConnection.Close();

                                            }else
                                            {

                                                myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                                                string query222 = "UPDATE users SET win_duels = win_duels + 1 WHERE id = @command1";

                                                SQLiteCommand myCommand222 = new SQLiteCommand(query222, myConnection);

                                                myConnection.OpenAsync();

                                                myCommand222.Parameters.AddWithValue("@command1", Convert.ToInt32(onlineList13[0]));
                                                Console.WriteLine(myCommand222.ExecuteNonQuery());
                                                myConnection.Close();
                                            }
                                            DeleteDuel(data.IdPols);

                                        }


                                            break;
                                    case "2":
                                        myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");
                                        string query7 = "SELECT bullet1, bullet2, bullet3, bullet4, bullet5, bullet6, bullet7 FROM duel WHERE user1 = @command OR user2 = @command LIMIT 1";
                                        SQLiteCommand myCommand7 = new SQLiteCommand(query7, myConnection);
                                        myCommand7.Parameters.AddWithValue("@command", data.IdPols);
                                        myConnection.OpenAsync();


                                        SQLiteDataReader result7 = myCommand7.ExecuteReader();
                                        var onlineList7 = new List<string>();


                                        if (result7.HasRows)
                                        {

                                            while (result7.Read())
                                            {


                                                onlineList7.Add(result7["bullet1"].ToString());
                                                onlineList7.Add(result7["bullet2"].ToString());
                                                onlineList7.Add(result7["bullet3"].ToString());
                                                onlineList7.Add(result7["bullet4"].ToString());
                                                onlineList7.Add(result7["bullet5"].ToString());
                                                onlineList7.Add(result7["bullet6"].ToString());
                                                onlineList7.Add(result7["bullet7"].ToString());
                                                //result["online"] to string array?


                                            }
                                            result7.Close();
                                            onlineList7.ToArray();
                                            Console.WriteLine(onlineList7[0]);
                                            myConnection.Close();

                                            string msg = "";
                                            for (int i = 0; i < onlineList7.Count(); i++)
                                            {
                                                if (onlineList7[i] != "2")
                                                {
                                                    msg += (i + 1) + "  ";
                                                }

                                            }

                                            MesSend.Send(data, "🤠 " + UsersGetVk.Get(data.IdPols, data) + " этот патрон уже использовали до тебя. Выбери другой из списка:" + "\n" + msg);
                                        }

                                        break;

                                }
                                myConnection.Close();




                            }
                            else
                            {
                                myConnection.Close();
                                MesSend.Send(data, "🤠 Нет такого патрона на столе");
                            }
                        }else
                        {
                            myConnection.Close();
                            MesSend.Send(data, "🤠 Сейчас не твоя очередь выбирать патрон");
                        }
                    }
                    else
                    {
                        myConnection.Close();
                        MesSend.Send(data, "🤠 В данный момент игра с твоим участием не проводится");
                    }
                    }else
                {
                    myConnection.Close();
                    MesSend.Send(data, "🤠 Неверно набрана команда дуэли. (!пуля <номер патрона>)");
                }
                
            }catch (Exception ex)
            {
                myConnection.Close();
                Console.WriteLine(ex);
            }


        }
         static void DeleteDuel(int id_user)
         {
         
            myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

            string query1 = "DELETE FROM duel WHERE user1 = @command1 OR user2 = @command1";



            SQLiteCommand myCommand1 = new SQLiteCommand(query1, myConnection);

            myConnection.OpenAsync();
            myCommand1.Parameters.AddWithValue("@command1", id_user);
            Console.WriteLine(myCommand1.ExecuteNonQuery());
            myConnection.Close();

        }
                

                

                
            
        
          static int RangGet(int id_user, Variables data)
           {

            try
            {
                myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                if (!File.Exists("./tte_bot.sqlite3"))
                {

                    SQLiteConnection.CreateFile("tte_bot.sqlite3");
                }
                string query = "SELECT Rang FROM users WHERE id = @command LIMIT 1";
                SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@command", data.IdPols);
                myConnection.OpenAsync();


                SQLiteDataReader result = myCommand.ExecuteReader();
                var onlineList = new List<string>();


                if (result.HasRows)
                {

                    while (result.Read())
                    {


                        onlineList.Add(result["Rang"].ToString());

                        //result["online"] to string array?


                    }
                    onlineList.ToArray();
                    Console.WriteLine(onlineList[0]);
                    myConnection.Close();

                    return Convert.ToInt32(onlineList[0]);
                }
            }catch
            {

            }
            return 0;
           }
            public static void Game(string[] Razdelil, Variables data)
            {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            try
            {
                myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                if (!File.Exists("./tte_bot.sqlite3"))
                {

                    SQLiteConnection.CreateFile("tte_bot.sqlite3");
                }
                string query = "SELECT Rang FROM users WHERE id = @command LIMIT 1";
                SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@command", data.IdPols);
                myConnection.OpenAsync();


                SQLiteDataReader result = myCommand.ExecuteReader();
                var onlineList = new List<string>();


                if (result.HasRows)
                {

                    while (result.Read())
                    {


                        onlineList.Add(result["Rang"].ToString());

                        //result["online"] to string array?


                    }
                    onlineList.ToArray();
                    Console.WriteLine(onlineList[0]);
                    myConnection.Close();

                    if (Convert.ToInt32(onlineList[0]) >= 3)
                    {
                        string query5 = "SELECT user FROM games WHERE user = @command LIMIT 1";
                        SQLiteCommand myCommand5 = new SQLiteCommand(query5, myConnection);
                        myCommand5.Parameters.AddWithValue("@command", data.IdPols);
                        myConnection.OpenAsync();


                        SQLiteDataReader result5 = myCommand5.ExecuteReader();

                       

                        if (!(result5.HasRows))
                        {

                            var danni = new HttpRequest();
                            danni.UserAgent = Http.OperaUserAgent();

                            danni.Cookies = new CookieDictionary();
                            Random rnd = new Random();
                            string response = danni.Get("https://db.chgk.info/xml/random//answers/types6/1177040479/limit1").ToString();
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(response);

                            XmlNodeList question = doc.GetElementsByTagName("Question");
                            XmlNodeList answer1 = doc.GetElementsByTagName("Answer");
                            string msg1 = "";
                            for (int i = 0; i < question[0].InnerXml.Length; i++)
                            {
                                msg1 += question[0].InnerXml[i] + "​"; //invisible char
                            }
                           
                            string msg = UsersGetVk.Get(data.IdPols, data) + ", ваш вопрос: " + "\n" + msg1;

                            string answer = (answer1[0].InnerXml).ToString();
                            answer = answer[0].ToString();

                           

                           
                            MesSend.Send(data, msg);


                            myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                            myConnection.OpenAsync();
                            string query1 = "INSERT INTO games(user, question, answer, answered) VALUES(@user, @question, @answer, '0')";
                            SQLiteCommand myCommand1 = new SQLiteCommand(query1, myConnection);
                            myCommand1.Parameters.AddWithValue("@user", data.IdPols);
                            myCommand1.Parameters.AddWithValue("@question", msg);
                            myCommand1.Parameters.AddWithValue("@answer", answer);

                            var outpiut = myCommand1.ExecuteNonQuery();
                            myConnection.Close();
                            Task.Delay(20000).ContinueWith(t => DeleteOldGame(data.IdPols));

                        }else
                        {
                            MesSend.Send(data, "У тебя уже идет игра, жди 15 секунд");
                        }
                        

                         
                    }
                    else
                    {
                        MesSend.Send(data, "Ты слишком лошня для запуска игры (От ранга «Нормальный пацан»)");


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MesSend.Send(data, "Не удалось получить вопрос, попробуй еще раз!");
            }
        }
        static void DeleteOldGame(int user_id)
        {
            myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

            string query1 = "DELETE FROM games WHERE user = @command1";



            SQLiteCommand myCommand1 = new SQLiteCommand(query1, myConnection);

            myConnection.OpenAsync();
            myCommand1.Parameters.AddWithValue("@command1", user_id);
            Console.WriteLine(myCommand1.ExecuteNonQuery());
            myConnection.Close();


        }


        public static void MyRang(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            try
            {
                myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

            
                string query = "SELECT Rang FROM users WHERE id = @command LIMIT 1";
                SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@command", data.IdPols);
                myConnection.OpenAsync();


                SQLiteDataReader result = myCommand.ExecuteReader();
                var onlineList = new List<string>();


                if (result.HasRows)
                {

                    while (result.Read())
                    {


                        onlineList.Add(result["Rang"].ToString());

                        //result["online"] to string array?


                    }
                    onlineList.ToArray();
                    Console.WriteLine(onlineList[0]);
                    myConnection.Close();
                    switch (onlineList[0])
                    {
                        case "1":
                            MesSend.Send(data, "Твой ранг: Лопата");
                            return;
                        case "2":
                            MesSend.Send(data, "Твой ранг: Фанат ричи конга");
                            return;
                        case "3":
                            MesSend.Send(data, "Твой ранг: Норм пацан");
                            return;
                        case "4":
                            MesSend.Send(data, "Твой ранг: Фан");
                            return;
                        case "5":
                            MesSend.Send(data, "Твой ранг: Админ");
                            return;

                    }
                }else
                {
                    MesSend.Send(data, "Ты не зареган");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        
                    public static void DownRang(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            try
            {
                myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                if (!File.Exists("./tte_bot.sqlite3"))
                {

                    SQLiteConnection.CreateFile("tte_bot.sqlite3");
                }
                string query = "SELECT Rang FROM users WHERE id = @command LIMIT 1";
                SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@command", data.IdPols);
                myConnection.OpenAsync();


                SQLiteDataReader result = myCommand.ExecuteReader();
                var onlineList = new List<string>();


                if (result.HasRows)
                {

                    while (result.Read())
                    {


                        onlineList.Add(result["Rang"].ToString());

                        //result["online"] to string array?


                    }
                    onlineList.ToArray();
                    Console.WriteLine(onlineList[0]);
                    myConnection.Close();

                    if (Convert.ToInt32(onlineList[0]) >= 5)
                    {

                        string output = "";
                        if (Razdelil.Length < 2)
                        {
                            MesSend.Send(data, "Параметров не может быть меньше 2");
                            return;
                        }
                        if (Razdelil.Length > 2)
                        {
                            MesSend.Send(data, "Параметров не может быть больше 2");
                            return;
                        }

                        string[] words = Razdelil[1].Split(new char[] { '|' });
                        string short_name = words[0];
                        short_name = short_name.Substring(1);
                        int user_id = Convert.ToInt32(UsersGetVk.Get(short_name, data));


                        myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                        string query1 = "SELECT Rang FROM users WHERE id = @command LIMIT 1";
                        SQLiteCommand myCommand1 = new SQLiteCommand(query1, myConnection);
                        myCommand1.Parameters.AddWithValue("@command", user_id);
                        myConnection.OpenAsync();


                        SQLiteDataReader result1 = myCommand1.ExecuteReader();
                        var onlineList1 = new List<string>();


                        if (result1.HasRows)
                        {

                            while (result1.Read())
                            {


                                onlineList1.Add(result1["Rang"].ToString());

                                //result["online"] to string array?


                            }
                            onlineList1.ToArray();
                            Console.WriteLine(onlineList1[0]);
                            myConnection.Close();
                            if ((Convert.ToInt32(onlineList1[0]) > 1) && (Convert.ToInt32(onlineList1[0]) != 5))
                            {
                                string rang = "";
                                switch (onlineList1[0])
                                {
                                    case "2":
                                        rang = "«Лопата (мут)»";
                                        break;
                                    case "3":
                                        rang = "«Фанат ричи конга»";
                                        break;
                                    case "4":
                                        rang = "«Норм пацан»";
                                        break;
                                    case "5":
                                        rang = "«Фан»";
                                        break;

                                }



                                myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                                string query2 = "UPDATE users SET rang = rang - 1 WHERE id = @command1";



                                SQLiteCommand myCommand2 = new SQLiteCommand(query2, myConnection);

                                myConnection.OpenAsync();
                                output = output.Trim();
                                myCommand2.Parameters.AddWithValue("@command1", user_id);
                                Console.WriteLine(myCommand2.ExecuteNonQuery());
                                myConnection.Close();

                                MesSend.Send(data, "Ты понизил " + UsersGetVk.Get(user_id, data) + " до ранга " + rang);


                            }
                            else
                            {
                                MesSend.Send(data, "У данного человека и так минимальный ранг, либо он ранга Генерал");
                            }











                        }
                        else
                        {
                            MesSend.Send(data, "Комманда введена не правильно либо человек не зареган. (!повысить @<id>)");
                        }
                    }
                    else
                    {
                        MesSend.Send(data, "У вас недостаточный ранг для понижения других");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MesSend.Send(data, "Ошибка при удалении команды.");
            }

        }
        public static string GetCustomCommand(string Razdelil, Variables data)
        {

            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            try
            {
                

                myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                if (!File.Exists("./tte_bot.sqlite3"))
                {


                    SQLiteConnection.CreateFile("tte_bot.sqlite3");
                }
                string query = "SELECT text FROM commands WHERE command = @command LIMIT 1";
                SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@command", Razdelil);
                myConnection.OpenAsync();
               
               
                SQLiteDataReader result = myCommand.ExecuteReader();
                var onlineList = new List<string>();


                if (result.HasRows)
                {

                    while (result.Read())
                    {


                        onlineList.Add(result["text"].ToString());

                        //result["online"] to string array?


                    }
                    onlineList.ToArray();
                    Console.WriteLine(onlineList[0]);

                    if (ISPHOTO(onlineList[0]))
                    {
                        MesSend.Send(data, RazborString(onlineList[0]), Photo(onlineList[0]));
                    }else
                    {
                        MesSend.Send(data, RazborString(onlineList[0]));
                    }

                   

                }
                else
                {
                    MesSend.Send(data, "Нет такой команды");
                }
                myConnection.Close();

            }
            catch (SQLiteException ex)
            {
                MesSend.Send(data, "Ошибка");
               
                myConnection.Close();
                return "";
            }
            myConnection.Close();
            return "";
        }
        public static bool ISPHOTO(string input)
        {
            try
            {
                string[] Razdelil = input.Split(' ');
                for (int i = 0; i < Razdelil.Length; i++)
                {
                    if (Razdelil[i].Substring(0, 1) == "&")
                    {
                        return true;
                    }
                }

                return false;
            }
            catch
            {
                
            }
            return false;
        }
        public static string Photo(string input)
        {
            try
            {
                string[] Razdelil = input.Split(' ');
                for (int i = 0; i < Razdelil.Length; i++)
                {
                    if (Razdelil[i].Substring(0, 1) == "&")
                    {

                        return Razdelil[i].Substring(1);
                    }

                }
                return "";
            }
            catch
            {
                return "";
            }
          
        }
        public static string RazborString(string input)
        {
            try
            {

                string[] Razdelil1 = input.Split(' ');
                for (int i = 0; i < Razdelil1.Length; i++)
                {
                    if (Razdelil1[i].Substring(0, 1) == "$")
                    {
                        string[] helper = Razdelil1[i].Split('-');
                        int min = Convert.ToInt32(helper[1]);
                        int max = Convert.ToInt32(helper[2]);

                        Random rnd = new Random();
                        int random1 = rnd.Next(min, max);
                        Razdelil1[i] = Convert.ToString(random1) + " ";

                    }
                    if (Razdelil1[i].Substring(0, 1) == "*")
                    {
                        string[] helper = Razdelil1[i].Split('-');

                        Random rnd = new Random();
                        int random1 = rnd.Next(1, helper.Length);

                        StringBuilder sb = new StringBuilder(helper[random1]);
                        for (int n = 0; n < helper[random1].Length; n++)
                        {
                            if (helper[random1][n] == 0x7C)
                            {
                                sb[n] = Convert.ToChar(" ");
                                
                            }
                        }
                        helper[random1] = sb.ToString();
                        Razdelil1[i] = helper[random1] + " ";

                    }
                    else
                    {
                        if (Razdelil1[i].Substring(0, 1) == "&")
                        {
                            Razdelil1[i] = null;
                        }
                        else
                        {
                            Razdelil1[i] += " ";
                        }
                    }

                    
                }
                return String.Concat(Razdelil1);
            }
            catch
            {
                return "";
            }

            return "";
        }

        public static string GetRandom(string[] Razdelil, int idPols, Variables data)
        {
            string msg;
            Rabota.MessageSend MesSend = new Rabota.MessageSend();

            
            if (RangGet(data.IdPols, data) >= 4)
            {
                try
                {
                    if ((Convert.ToInt32(Razdelil[1]) <= 0) && (Convert.ToInt32(Razdelil[1]) > 5))
                    {
                        MesSend.Send(data, "Количество зарандомленных чисел не может быть меньше 0 или больше 5" + "\n" + "Правильная команда !рандом [кол-во чисел] [мин] [макс]");
                        return "";
                    }
                    if (Convert.ToInt32(Razdelil[2]) >= Convert.ToInt32(Razdelil[3]))
                    {
                        MesSend.Send(data, "Минимальное число не может быть больше или равным максимальному" + "\n" + "Правильная команда !рандом [кол-во чисел] [мин] [макс]");
                        return "";
                    }
                    Random rnd = new Random();
                    int random1 = rnd.Next(100, 100000);
                    string json = "{\"jsonrpc\":\"2.0\",\"method\":\"generateSignedIntegers\",\"params\":{\"apiKey\":\"3de872cc-6a44-4b7d-b7d8-11d24758be88\",\"n\":" + Razdelil[1] + ",\"min\":" + Razdelil[2] + ",\"max\":" + Razdelil[3] + ",\"replacement\":false,\"base\":10},\"id\":" + random1 + "}";
                    var danni = new HttpRequest();
                    danni.UserAgent = Http.OperaUserAgent();

                    danni.Cookies = new CookieDictionary();
                    string response = danni.Post("https://api.random.org/json-rpc/2/invoke", json, "application/json").ToString();
                    JObject json1 = JObject.Parse(response);

                    for (int i = 0; i < Convert.ToInt32(Razdelil[1]); i++)
                    {
                        MesSend.Send(data, Convert.ToString(json1["result"]["random"]["data"][i]));

                    }
                    MesSend.SendLog(response);
                }
                catch
                {
                    MesSend.Send(data, "Возникла ошибка");
                    return "";
                }
            }else
            {
                MesSend.Send(data, "Для этой команды надо быть рангом ФАН или выше");
            }


            return "";
        }
        public static string GetRadone(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            MesSend.Send(data, "Radone проперделся на 100%");

            return "";
        }
        public static string GetKreslo(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            MesSend.Send(data, "Кресло", "photo-" + "195044271" + "_" + "457239017");

            return "";
        }
        public static string GetYspex(string[] Razdelil, int idPols, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(0, 100);

            MesSend.Send(data, TestBot.Rabota.Vk.Users.UsersGetVk.Get(idPols, data) + " успешен на " + random1 + "%");

            return "";
        }
        public static string GetNapizdel(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(10000, 80000);

            MesSend.Send(data, "Генерал Werdex напиздел с донатом на сумму " + random1 + " рублей");

            return "";
        }
        public static string GetGonki(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();

            MesSend.Send(data, "Давайте устроим гонки в чяти ♿♿♿♿♿♿♿♿♿♿♿♿♿♿♿♿♿♿");

            return "";
        }
        public static string GetYrovn(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(0, 100);

            MesSend.Send(data, "Генерал Werdex уровнял на " + random1 + "%");

            return "";
        }
        public static string GetJokir(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(0, 100);

            MesSend.Send(data, "хя-хяяяяяя");

            return "";
        }
        public static string GetObosr(string[] Razdelil, int idPols, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(0, 100);

            MesSend.Send(data, TestBot.Rabota.Vk.Users.UsersGetVk.Get(idPols, data) + " обосрал своё одеяло на " + random1 + "%");

            return "";
        }
        public static string GetPodogret(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(100000, 1000000);

            MesSend.Send(data, "Так, Генерал Werdex подогреть приятной монеткой в размере " + random1);

            return "";
        }
        public static string GetRazvit(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(0, 30);

            MesSend.Send(data, "Ричи Конг развил свой канал на " + random1 + "%");

            return "";
        }
        public static string Get150k(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
           

            MesSend.Send(data, "ДОНАТИМ ПРЯМ СЕЙЧАС 150К СУЧАРЫ, СТРИМ НЕ БЕСПЛАТНЫЙ!!!");

            return "";
        }
        public static string GetPyan(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(0, 120);

            MesSend.Send(data, "Сейчас Олег Элеватор пьян на " + random1 + "%");

            return "";
        }
        public static string GetKepka(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            
            MesSend.Send(data, "О, нихуя", "photo-195044271_457239027");

            return "";
        }
        public static string GetMyt(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();

            MesSend.Send(data, "Мут", "photo-195044271_457239028");

            return "";
        }
        public static string GetPivo(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();

            MesSend.Send(data, "Pivo", "photo-195044271_457239029");

            return "";
        }
        public static string GetBatya(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();

            MesSend.Send(data, "Batya", "photo-195044271_457239030");

            return "";
        }
        public static string GetKz(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();

            MesSend.Send(data, "Kz", "photo-195044271_457239031");

            return "";
        }
        public static string GetDush(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();

            MesSend.Send(data, "Душ принимаем сучары", "photo-195044271_457239032");

            return "";
        }
        public static string GetSelfie(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();

            MesSend.Send(data, "Селфи", "photo-195044271_457239033");

            return "";
        }
        public static string GetPodnimi(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();

            MesSend.Send(data, "Подними", "photo-195044271_457239034");

            return "";
        }
        public static string GetNovosti(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();

            MesSend.Send(data, "Внимание! Новости!", "photo-195044271_457239035");

            return "";
        }
        public static string GetVes(string[] Razdelil, int idPols, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(30, 80);

            MesSend.Send(data, "Сейчас " + TestBot.Rabota.Vk.Users.UsersGetVk.Get(idPols, data) + " весит " + random1 + " кг");

            return "";
        }
        public static string GetSerega(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(0, 100);

            MesSend.Send(data, "Серега любит мужские гинеталии на " + random1 + "%");

            return "";
        }
        public static string GetKrasiv(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(0, 100);

            MesSend.Send(data, "Олег Элеватор красив на " + random1 + "%");

            return "";
        }
        public static string GetNaebat(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(1000, 20000);
            string pidor = TestBot.Rabota.Vk.Messages.MessagesgetConversationMembers.GetUserMessage(data);


            MesSend.Send(data, TestBot.Rabota.Vk.Users.UsersGetVk.Get(Convert.ToInt32(pidor), data) + " Наебал Олега с донатом на " + random1 + "руб");

            return "";
        }
        public static string GetPizdanut(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(10, 1000);
            string pidor = TestBot.Rabota.Vk.Messages.MessagesgetConversationMembers.GetUserMessage(data);


            MesSend.Send(data, TestBot.Rabota.Vk.Users.UsersGetVk.Get(Convert.ToInt32(pidor), data) + " пизданул донат на " + random1 + "руб");

            return "";
        }
        public static string GetRadon(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();


            MesSend.Send(data, "Пук");

            return "";
        }
        public static string GetMmr(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();


            MesSend.Send(data, "6400 основа");

            return "";
        }
        public static string GetVods(string[] Razdelil, Variables data)
        {
            if (data.IdPolsBes == 2000000003)
            {
                try
                {
                    Rabota.MessageSend MesSend = new Rabota.MessageSend();
                    string vod1 = File.ReadAllText(@"/home/ubuntu/twitch-vod-uploader/history.json");
                    JObject json = JObject.Parse(vod1);
                    string msg = "";
                    List<string> vods = new List<string>();
                    foreach (JProperty property in json.Properties())
                    {
                        Console.WriteLine(property.Name + " - " + property.Value);
                        vods.Add("💬Название стрима: " + property.Value["title"] + "\n" + "📅Дата: " + property.Value["publishAt"] + "\n" + "🔑Ссылка: " + property.Value["directLink"]);


                    }

                    for (int i = 0; i < 5; i++)
                    {
                        msg += vods[i] + "\n\n";
                    }
                    Console.WriteLine(vods);
                    // deserialize JSON directly from a file


                    MesSend.Send(data, msg);
                }
                catch (Exception ex)
                {

                }
            }else
            {
                Rabota.MessageSend MesSend = new Rabota.MessageSend();
                MesSend.Send(data, "В этой конфе не пашет");
            }
            return "";
        }
        public static string GetFunction(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            try
            {
                MesSend.Send(data, "!ранг (вывод твой ранг)" + "\n" + "!стата (твоя статистика)" + "\n" + "!игра (задает вопрос для пользователя) [3+ ранг]" + "\n" + "!ответ <номер ответа> (номер это порядковое значение, буква или цифра) [3+ ранг]" + "\n" + "!дуэль <id> (id в формате '@durov') [3+ ранг]" + "\n" + "!рандом <сколько_чисел> <минимальное_значение> <максимальное значение> [4+ ранг] Random.org™" + "\n" + "!создать <имя_команды> <текст> [4+ ранг]" + "\n" + "!удалить <имя_команды> [4+ ранг]" + "\n" + "!повысить <id> (id в формате '@durov') [5+ ранг]" + "\n" + "!понизить <id> (id в формате '@durov') [5+ ранг]" + "\n" + "!вод (последние 5 водов с канала ричи)" + "\n");


                return "";
            }catch
            {
                
            }
            return "";
        }
                public static string GetKommands(string[] Razdelil, Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            try
            {
                myConnection = new SQLiteConnection("Data Source=tte_bot.sqlite3");

                if (!File.Exists("./tte_bot.sqlite3"))
                {


                    SQLiteConnection.CreateFile("tte_bot.sqlite3");
                }
                string query = "SELECT command FROM commands";
                SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
                

                myConnection.OpenAsync();


                SQLiteDataReader result = myCommand.ExecuteReader();
                var onlineList = new List<string>();


                if (result.HasRows)
                {

                    while (result.Read())
                    {


                        onlineList.Add(result["command"].ToString());

                        //result["online"] to string array?


                    }
                    onlineList.ToArray();
                    Console.WriteLine(onlineList[0]);
                    string msg = "!функции - для вызова справки по сервисным командам" + "\n" + "*********" + "\n";
                    for (int i = 0; i < onlineList.Count; i++)
                    {
                        try
                        {
                            //if (onlineList[i].Substring(0, 2) != "!t")
                            //{

                                msg += onlineList[i] + " | ";
                            if (i > 300)
                            {
                                MesSend.Send(data, msg);
                                onlineList.RemoveRange(0, 300);
                                i = 0;
                                msg = "\n Вторая страница \n\n";
                            }
                                
                            //}
                        }catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }

                    }
                    
                    MesSend.Send(data, msg);
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


                   // MesSend.Send(data, "!цирроз" + "\n" + "!кресло" + "\n" + "!успех" + "\n" + "!напиздел" + "\n" + "!гонки" + "\n" + "!уровнять" + "\n" + "!жокир" + "\n" + "!насрать" + "\n" + "!подогреть" + "\n" + "!развитие" + "\n" + "!150к" + "\n" + "!пьян" + "\n" + "!вес" + "\n" + "!серега" + "\n" + "!красив" + "\n" + "!наебать" + "\n" + "!пиздануть" + "\n" + "!радон" + "\n" + "!mmr" + "\n" + "!кепка" + "\n" + "!мут" + "\n" + "!пиво" + "\n" + "!батя" + "\n" + "!кз" + "\n" + "!душ" + "\n" + "!селфи" + "\n" + "!подними" + "\n" + "!новости");

            return "";
        }
    }
    public class Vod
    {
        public string title { get; set; }
        public string publishAt { get; set; }
        public string directLink { get; set; }
    }
    
}
