using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading;
namespace TestBot.Rabota.Vk.Messages
{
    class MessagesgetConversationMembers
    {
        public static string Im = "153171922";
       public static HttpRequest request = new HttpRequest();
        public static string GetUserMessage()
        {

            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            RequestParams reqParams = new RequestParams();
            reqParams["peer_id"] = Variables.IdPolsBes;
            reqParams["fields"] = "id";
            reqParams["access_token"] = Variables.Token;
            reqParams["v"] = Variables.v;
            string response = request.Get("https://api.vk.com/method/messages.getConversationMembers?", reqParams).ToString();
            JObject json = JObject.Parse(response);
            if (response.Contains("error"))
            {
                MesSend.Send("Для этой команды мне нужны права администратора");
            }else
            { 
         
                int razmer = Convert.ToInt32(json["response"]["groups"].Count());
            


            JObject header = (JObject)json.SelectToken("response");
            header.Property("groups").Remove();
            


            int count1 = (Convert.ToInt32(json["response"]["count"]));
                if ((count1 - razmer) <= 0)
                {
                    MesSend.Send("Вы один в беседе");
                }
                else
                {
                    String[] IDs = new String[count1 - razmer];


                    for (int i = 0; i < (count1 - razmer); i++)
                    {

                        IDs[i] = Convert.ToString(json["response"]["profiles"][i]["id"]);


                    }



                    Random rn = new Random();
                    int rand = (rn.Next(1, 3));



                    string pidor = IDs[new Random().Next(0, IDs.Length)];
                    Users.UsersGetVk.Get(pidor);
                }

            }

            return "";
        }

        public static string helpme()
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            MesSend.Send("Доступны следующие команды:" + "\n" + "1. Помощь (для вызовы помощи)" + "\n" + "2. Я пидорас? - Узнать пидорас ли вы" + "\n" + "3. Найти пидора - Найти пидора в этой беседе" + "\n" + "4. Xачу мем - показать мемчик" + "\n" + "5. Хачу видео - показать видос" + "\n" + "6. Онлайн арп - показать онлайн Arizona RP" + "\n" + "7. Онлайн дрп - показать онлайн Diamond RP" + "\n" + "8. Топ сервера - вывести топ серверов");
            return "";
        }
    }
}
