using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading;

namespace TestBot.Rabota.Vk.Users
{
    class UsersGetVk
    {

        public static string Get(string user_ids)
        {
            var danni = new HttpRequest();
            RequestParams reqParams = new RequestParams();
            reqParams["user_ids"] = user_ids;
            reqParams["fields"] = "first_name, last_name";
            reqParams["access_token"] = Variables.Token;
            reqParams["v"] = Variables.v;
            string response = danni.Get("https://api.vk.com/method/users.get?", reqParams).ToString();
            if (response.Contains("error"))
            {
                return "";

            }
                JObject json = JObject.Parse(response);
            return Danni(json);




        }
        private static string Danni(JObject json)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            string pidor = (Convert.ToString(json["response"][0]["id"]));
            string name = (Convert.ToString(json["response"][0]["first_name"]));
            string surname = (Convert.ToString(json["response"][0]["last_name"]));


            Random rn = new Random();
            int rand = (rn.Next(1, 3));

            if (rand == 1)
            {
              
                    MesSend.Send("Инициирую поиск пидора...");
                    Thread.Sleep(50);
                    MesSend.Send("Сканирую...");
                    Thread.Sleep(50);
                    MesSend.Send("Пидорас это @id" + pidor + " " + "(" + name + " " + surname + ")", "photo-185711407_457239023");
                
            }
            if (rand == 2)
            {
               
                   
                    MesSend.Send("Опять в эти ваши игрульки играете? Ну ладно...");
                    Thread.Sleep(50);
                    MesSend.Send("Сканирую...");
                    Thread.Sleep(50);
                    MesSend.Send("Пидор дня он: @id" + pidor + " " + "(" + name + " " + surname + ")", "photo-185711407_457239023");
                
            }
            if (rand == 3)
            {
             
                
                    MesSend.Send("Система взломана. Нанесен урон. Запущено планирование контрмер.");
                    Thread.Sleep(50);
                    MesSend.Send("А могли бы делом заниматься...");
                    Thread.Sleep(50);
                    MesSend.Send("И прекрасный человек дня сегодня... а нет, ошибочка, всего-лишь пидор - @id" + pidor + " " + "(" + name + " " + surname + ")", "photo-185711407_457239024");
                
            }





            return "";

        }
        


    }




}
