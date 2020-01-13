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
    class wallget
    {
        public static string vladelec;
        public static string photka;
        public static string text1;
        public static HttpRequest request = new HttpRequest();
        public static string getwall()
        {
            Random rn = new Random();
            int rand = (rn.Next(1, 30000));

            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            RequestParams reqParams = new RequestParams();
            string response;
            reqParams["domain"] = "kaponwina";
            reqParams["count"] = "1";
            reqParams["offset"] = rand;
            reqParams["access_token"] = "fe1a4f2df311250b3e9bf921bad31da0e03208ebc466fc614e7aa49300f2a620c383baa1dd8fd75f48c29";
            reqParams["v"] = Variables.v;

            try
            {
                response = request.Get("https://api.vk.com/method/wall.get?", reqParams).ToString();
            }
            catch (Exception ex)
            {
                
                reqParams["domain"] = "kaponwina";
                reqParams["count"] = "1";
                reqParams["offset"] = rand;
                reqParams["access_token"] = "fe1a4f2df311250b3e9bf921bad31da0e03208ebc466fc614e7aa49300f2a620c383baa1dd8fd75f48c29";
                reqParams["v"] = Variables.v;
                response = request.Get("https://api.vk.com/method/wall.get?", reqParams).ToString();
            }



            JObject json = JObject.Parse(response);
            if (response.Contains("error"))
            {
                MesSend.Send("На сегодня мемасы кончились. Завтра будут новые!");
            }
            else
            {

                try
                {
                    text1 = Convert.ToString(json["response"]["items"][0]["text"]);
                    vladelec = Convert.ToString(json["response"]["items"][0]["attachments"][0]["photo"]["owner_id"]);
                    photka = Convert.ToString(json["response"]["items"][0]["attachments"][0]["photo"]["id"]);
                }
                catch (Exception ex)
                {
                    // Put the more specific exception first.
                    Vk.Messages.wallget.getwall();
                }
                finally
                {
                    MesSend.Send(text1, "photo" + vladelec + "_" + photka);
                }
            }
            return "";
        }


    }
}
