using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace TestBot.Rabota
{
    class LongPollServer
    {
        private static string[] getLongPollServer()
        {
            var danni = new HttpRequest();
            danni.UserAgent = Http.OperaUserAgent();
            danni.Cookies = new CookieDictionary();
            danni.KeepAlive = true;
            string[] Danni = { };
            try
            {
                string response = danni.Get("https://api.vk.com/method/"
                    + "groups.getLongPollServer" + "?"
                    + "&" + "group_id=" + Variables.GroupId
                    + "&" + "lp_version=" + 3
                    + "&" + "access_token=" + Variables.Token
                    + "&" + "v=" + Variables.v).ToString();
                JObject json = JObject.Parse(response);
                if (response.Contains("failed"))
                {
                    getLongPollServer();
                }
                if (response.Contains("error"))
                {
                    getLongPollServer();
                }

                Danni = new string[]
                {
                json["response"]["server"].ToString(),
                json["response"]["key"].ToString(),
                json["response"]["ts"].ToString()
                };
                
            }
            catch (Exception ex)
            {
                getLongPollServer();
            }
           
                return Danni;
            
            
        }



        public static string zaprossLongPoll()
        {
            string server, key;
            int ts;
            string[] Danni = getLongPollServer();
            try
            {
                server = Danni[0];
                key = Danni[1];
                ts = Convert.ToInt32(Danni[2]);
            }
            catch (Exception ex)
            {
                zaprossLongPoll();
            }
            finally
            {
                server = Danni[0];
                key = Danni[1];
                ts = Convert.ToInt32(Danni[2]);
            }
            

            HttpRequest danni = new HttpRequest();
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            while (true)
            {
                string response;
                try
                {
                   danni.Get($"{server}?act=a_check&key={key}&ts={ts}&wait=25").ToString();
                }
                catch (Exception ex)
                {
                    zaprossLongPoll();
                }
                finally
                {
                    response = danni.Get($"{server}?act=a_check&key={key}&ts={ts}&wait=25").ToString();
                }



                JObject json = JObject.Parse(response);

                if (response.Contains("failed"))
                {
                    if (Convert.ToInt32(json["failed"]) == 1) { ts = Convert.ToInt32(json["ts"]); }
                    else if (Convert.ToInt32(json["failed"]) == 2) { Danni = getLongPollServer(); key = Danni[1]; }
                    else if (Convert.ToInt32(json["failed"]) == 3) { Danni = getLongPollServer(); key = Danni[1]; ts = Convert.ToInt32(Danni[2]); }
                }
                else
                {
                    for (int i = 0; i < json["updates"].Count(); i++)
                    {
                        
                        if (Convert.ToString(json["updates"][i]["type"]) == "message_new")
                        {
                            if (response.Contains("chat_invite_user"))
                            {
                                if (Convert.ToString(json["updates"][i]["object"]["action"]["type"]) == "chat_invite_user")
                                {

                                    if (Convert.ToString(json["updates"][i]["object"]["action"]["member_id"]) == "-185711407")
                                    {
                                        int id_beseda = Convert.ToInt32(json["updates"][i]["object"]["peer_id"]);
                                        Rabota.AddedToBeseda.AddMe(id_beseda);
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            else

                            
                            {


                                Variables.IdMes = Convert.ToInt32(json["updates"][i]["object"]["id"]);
                                Variables.Time = Convert.ToInt32(json["updates"][i]["object"]["date"]);
                                Variables.Title = json["updates"][i]["object"]["text"].ToString();
                                int[] Razdelit = ExtraFunction.SettingDanniEf.SettingDanniBeseda(Convert.ToInt32(json["updates"][i]["object"]["from_id"]), Convert.ToInt32(json["updates"][i]["object"]["peer_id"]));

                                Variables.IdPols = Razdelit[1];
                                Variables.IdPolsBes = Razdelit[0];

                                Rabota.Command Command = new Rabota.Command();
                                Rabota.Varb Vb = new Rabota.Varb();
                                Vb.SettText();
                                Command.Obrabot();

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($@"1. ID пользователя: {Variables.IdPols}. {"\n"}2. id беседы: {Variables.IdPolsBes}. {"\n"}3. id сообщений: {Variables.IdMes}. {"\n"}4. Время сообщения: {Variables.Time}. {"\n"}5. Сообщение: {Variables.Title}");
                            }
                            }

                        
                    }
                }
                ts = Convert.ToInt32(json["ts"]);

                
            }

        }
    }
}
