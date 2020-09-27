﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading;

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
                    + "&" + "group_id=" + Variables_Static.GroupId
                    + "&" + "lp_version=" + 3
                    + "&" + "access_token=" + Variables_Static.Token
                    + "&" + "v=" + Variables_Static.v).ToString();
                JObject json = JObject.Parse(response);
                if (response.Contains("failed"))
                {
                    getLongPollServer();
                    Console.WriteLine("Failed");
                }
                if (response.Contains("error"))
                {
                    getLongPollServer();
                    Console.WriteLine("Failed");
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
                Console.WriteLine(ex);
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
                    Console.WriteLine("Try");
                }
                catch (Exception ex)
                {
                    zaprossLongPoll();
                    Console.WriteLine(ex);
                }
                finally
                {
                    response = danni.Get($"{server}?act=a_check&key={key}&ts={ts}&wait=25").ToString();
                    Console.WriteLine("Finally");
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

                                    if (Convert.ToString(json["updates"][i]["object"]["action"]["member_id"]) == "-195044271")
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


                                Variables data = new Variables();
                                data.IdMes = Convert.ToInt32(json["updates"][i]["object"]["conversation_message_id"]);
                                data.Time = Convert.ToInt32(json["updates"][i]["object"]["date"]);
                                data.Title = json["updates"][i]["object"]["text"].ToString();
                                int[] Razdelit = ExtraFunction.SettingDanniEf.SettingDanniBeseda(Convert.ToInt32(json["updates"][i]["object"]["from_id"]), Convert.ToInt32(json["updates"][i]["object"]["peer_id"]));

                                data.IdPols = Razdelit[1];
                                data.IdPolsBes = Razdelit[0];


                                Rabota.Command Command = new Rabota.Command();
                                Rabota.Varb Vb = new Rabota.Varb();
                                Vb.SettText(data);
                                Command.Obrabot(data.IdPols, data);



                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($@"1. ID пользователя: {data.IdPols}. {"\n"}2. id беседы: {data.IdPolsBes}. {"\n"}3. id сообщений: {data.IdMes}. {"\n"}4. Время сообщения: {data.Time}. {"\n"}5. Сообщение: {data.Title}");
                            }
                            }

                        
                    }
                }
                ts = Convert.ToInt32(json["ts"]);

                
            }

        }
        
        
    }
}
