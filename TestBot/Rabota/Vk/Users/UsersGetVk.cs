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

        public static string Get(int user_ids, Variables data)
        {
            var danni = new HttpRequest();
            RequestParams reqParams = new RequestParams();
            reqParams["user_ids"] = user_ids;
            reqParams["fields"] = "first_name, last_name";
            reqParams["access_token"] = data.Token;
            reqParams["v"] = data.v;
            string response = danni.Get("https://api.vk.com/method/users.get?", reqParams).ToString();
            if (response.Contains("error"))
            {
                return "";

            }
                JObject json = JObject.Parse(response);
            return Danni(json);




        }
        public static string Get(string user_ids, Variables data)
        {
            var danni = new HttpRequest();
            RequestParams reqParams = new RequestParams();
            reqParams["user_ids"] = user_ids;
            reqParams["fields"] = "first_name, last_name";
            reqParams["access_token"] = data.Token;
            reqParams["v"] = data.v;
            string response = danni.Get("https://api.vk.com/method/users.get?", reqParams).ToString();
            if (response.Contains("error"))
            {
                return "";

            }
            JObject json = JObject.Parse(response);
            return Danni1(json);

        }
        private static string Danni1(JObject json)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            string pidor = (Convert.ToString(json["response"][0]["id"]));
       


            return pidor;

        }
        private static string Danni(JObject json)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            string pidor = (Convert.ToString(json["response"][0]["id"]));
            string name = (Convert.ToString(json["response"][0]["first_name"]));
            string surname = (Convert.ToString(json["response"][0]["last_name"]));


            return name + " " + surname;

        }
 
        public static string CheckMsgId(Variables data)
        {
            try
            {
                var danni = new HttpRequest();
                RequestParams reqParams = new RequestParams();
                int peer_id = 0;
                if (data.IdPolsBes == 2000000004)
                {
                    peer_id = 2000000118;
                }
                else if (data.IdPolsBes == 2000000003)
                {
                    peer_id = 2000000125;
                }else if (data.IdPolsBes == 2000000002)
                {
                    peer_id = 2000000127;
                }else
                {
                    return "";
                }
                    reqParams["peer_id"] = peer_id;

                reqParams["conversation_message_ids"] = data.IdMes;/*Variables.IdMes*/
              
                reqParams["access_token"] = data.Token_Usr;
                reqParams["v"] = data.v;
             
                string response = danni.Get("https://api.vk.com/method/messages.getByConversationMessageId?", reqParams).ToString();
               
                JObject json = JObject.Parse(response);
                string msg_id = Convert.ToString(json["response"]["items"][0]["id"]);
                //if (response.Contains("error"))
                //{
                //    return "";

                //}
                return msg_id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "";
            }
            return "";
        }

                public static string Delete(int msg_id, Variables data)
                {
            try
            {
                var danni = new HttpRequest();
                RequestParams reqParams = new RequestParams();
                string id_ms = CheckMsgId(data);
                if (id_ms == "")
                {
                    return "";
                }

                reqParams["message_ids"] = id_ms;
                
                reqParams["delete_for_all"] = 1;
                reqParams["access_token"] = data.Token_Usr;
                reqParams["v"] = data.v;
                string response = danni.Get("https://api.vk.com/method/messages.delete?", reqParams).ToString();
                if (response.Contains("error"))
                {
                    return "";

                }
             
            }catch (Exception)
            {
                
            }

            return "";
        }


    }




}
