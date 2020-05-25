using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xNet;

namespace TestBot.Rabota.Function.Vk.Entertainment
{
    class info
    {
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
        public static string GetPidor(string[] Razdelil, int idPols)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(0, 100);
           
                MesSend.Send(TestBot.Rabota.Vk.Users.UsersGetVk.Get(idPols) + " болен циррозом на " + random1 + "%");
            
            return "";
        }
        public static string GetRandom(string[] Razdelil, int idPols)
        {
            string msg;
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            if ((idPols == 153171922) || (idPols == 261341610) || (idPols == 379958162))
            {
                try
                {
                    if (Convert.ToInt32(Razdelil[1]) <= 0)
                    {
                        MesSend.Send("Количество зарандомленных чисел не может быть меньше 0" + "\n" + "Правильная команда !рандом [кол-во чисел] [мин] [макс]");
                        return "";
                    }
                    if (Convert.ToInt32(Razdelil[2]) >= Convert.ToInt32(Razdelil[3]))
                    {
                        MesSend.Send("Минимальное число не может быть больше или равным максимальному" + "\n" + "Правильная команда !рандом [кол-во чисел] [мин] [макс]");
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
                        MesSend.Send(Convert.ToString(json1["result"]["random"]["data"][i]));

                    }
                    MesSend.SendLog(response);
                }
                catch
                {
                    MesSend.Send("Возникла ошибка");
                    return "";
                }
            }


            return "";
        }
        public static string GetRadone(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            MesSend.Send("Radone проперделся на 100%");

            return "";
        }
        public static string GetKreslo(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            MesSend.Send("Кресло", "photo-" + "195044271" + "_" + "457239017");

            return "";
        }
        public static string GetYspex(string[] Razdelil, int idPols)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(0, 100);

            MesSend.Send(TestBot.Rabota.Vk.Users.UsersGetVk.Get(idPols) + " успешен на " + random1 + "%");

            return "";
        }
        public static string GetNapizdel(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(10000, 80000);

            MesSend.Send("Генерал Werdex напиздел с донатом на сумму " + random1 + " рублей");

            return "";
        }
        public static string GetGonki(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();

            MesSend.Send("Давайте устроим гонки в чяти ♿♿♿♿♿♿♿♿♿♿♿♿♿♿♿♿♿♿");

            return "";
        }
        public static string GetYrovn(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(0, 100);

            MesSend.Send("Генерал Werdex уровнял на " + random1 + "%");

            return "";
        }
        public static string GetJokir(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(0, 100);

            MesSend.Send("хя-хяяяяяя");

            return "";
        }
        public static string GetObosr(string[] Razdelil, int idPols)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(0, 100);

            MesSend.Send(TestBot.Rabota.Vk.Users.UsersGetVk.Get(idPols) + " обосрал своё одеяло на " + random1 + "%");

            return "";
        }
        public static string GetPodogret(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(100000, 1000000);

            MesSend.Send("Так, Генерал Werdex подогреть приятной монеткой в размере " + random1);

            return "";
        }
        public static string GetRazvit(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(0, 30);

            MesSend.Send("Ричи Конг развил свой канал на " + random1 + "%");

            return "";
        }
        public static string Get150k(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
           

            MesSend.Send("ДОНАТИМ ПРЯМ СЕЙЧАС 150К СУЧАРЫ, СТРИМ НЕ БЕСПЛАТНЫЙ!!!");

            return "";
        }
        public static string GetPyan(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(0, 120);

            MesSend.Send("Сейчас Олег Элеватор пьян на " + random1 + "%");

            return "";
        }
        public static string GetKepka(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            
            MesSend.Send("О, нихуя", "photo-195044271_457239027");

            return "";
        }
        public static string GetMyt(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();

            MesSend.Send("Мут", "photo-195044271_457239028");

            return "";
        }
        public static string GetPivo(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();

            MesSend.Send("Pivo", "photo-195044271_457239029");

            return "";
        }
        public static string GetBatya(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();

            MesSend.Send("Batya", "photo-195044271_457239030");

            return "";
        }
        public static string GetKz(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();

            MesSend.Send("Kz", "photo-195044271_457239031");

            return "";
        }
        public static string GetDush(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();

            MesSend.Send("Душ принимаем сучары", "photo-195044271_457239032");

            return "";
        }
        public static string GetSelfie(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();

            MesSend.Send("Селфи", "photo-195044271_457239033");

            return "";
        }
        public static string GetPodnimi(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();

            MesSend.Send("Подними", "photo-195044271_457239034");

            return "";
        }
        public static string GetNovosti(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();

            MesSend.Send("Внимание! Новости!", "photo-195044271_457239035");

            return "";
        }
        public static string GetVes(string[] Razdelil, int idPols)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(30, 80);

            MesSend.Send("Сейчас " + TestBot.Rabota.Vk.Users.UsersGetVk.Get(idPols) + " весит " + random1 + " кг");

            return "";
        }
        public static string GetSerega(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(0, 100);

            MesSend.Send("Серега любит мужские гинеталии на " + random1 + "%");

            return "";
        }
        public static string GetKrasiv(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(0, 100);

            MesSend.Send("Олег Элеватор красив на " + random1 + "%");

            return "";
        }
        public static string GetNaebat(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(1000, 20000);
            string pidor = TestBot.Rabota.Vk.Messages.MessagesgetConversationMembers.GetUserMessage();


            MesSend.Send(TestBot.Rabota.Vk.Users.UsersGetVk.Get(Convert.ToInt32(pidor)) + " Наебал Олега с донатом на " + random1 + "руб");

            return "";
        }
        public static string GetPizdanut(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(10, 1000);
            string pidor = TestBot.Rabota.Vk.Messages.MessagesgetConversationMembers.GetUserMessage();


            MesSend.Send(TestBot.Rabota.Vk.Users.UsersGetVk.Get(Convert.ToInt32(pidor)) + " пизданул донат на " + random1 + "руб");

            return "";
        }
        public static string GetRadon(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();


            MesSend.Send("Пук");

            return "";
        }
        public static string GetMmr(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();


            MesSend.Send("6400 основа");

            return "";
        }
        public static string GetKommands(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();


            MesSend.Send("!цирроз" + "\n" + "!кресло" + "\n" + "!успех" + "\n" + "!напиздел" + "\n" + "!гонки" + "\n" + "!уровнять" + "\n" + "!жокир" + "\n" + "!насрать" + "\n" + "!подогреть" + "\n" + "!развитие" + "\n" + "!150к" + "\n" + "!пьян" + "\n" + "!вес" + "\n" + "!серега" + "\n" + "!красив" + "\n" + "!наебать" + "\n" + "!пиздануть" + "\n" + "!радон" + "\n" + "!mmr" + "\n" + "!кепка" + "\n" + "!мут" + "\n" + "!пиво" + "\n" + "!батя" + "\n" + "!кз" + "\n" + "!душ" + "\n" + "!селфи" + "\n" + "!подними" + "\n" + "!новости");

            return "";
        }
    }
}
