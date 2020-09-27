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
        public static string GetUserMessage(Variables data)
        {
            
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            RequestParams reqParams = new RequestParams();
            reqParams["peer_id"] = 2000000003;
            reqParams["fields"] = "id";
            reqParams["access_token"] = data.Token;
            reqParams["v"] = data.v;
            string response = request.Get("https://api.vk.com/method/messages.getConversationMembers?", reqParams).ToString();
            JObject json = JObject.Parse(response);
            if (response.Contains("error"))
            {
                MesSend.Send(data, "Для этой команды мне нужны права администратора");
            }else
            { 
         
                int razmer = Convert.ToInt32(json["response"]["groups"].Count());
            


            JObject header = (JObject)json.SelectToken("response");
            header.Property("groups").Remove();
            


            int count1 = (Convert.ToInt32(json["response"]["count"]));
                if ((count1 - razmer) <= 0)
                {
                    MesSend.Send(data, "Вы один в беседе");
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
                    return pidor;

                }

            }

            return "";
        }

       
        public static string ciroz(Variables data)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            MesSend.Send(data, "");
            return "";
        }
    }
}
