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

        public static string Get(int user_ids)
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


            return name + " " + surname;

        }
        


    }




}
