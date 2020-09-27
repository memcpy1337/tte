using System;
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
    class MessageSend
    {
        public void SendLog(string Message)
        {
            var danni = new HttpRequest();
            danni.Cookies = new CookieDictionary();
            danni.KeepAlive = true;
            danni.UserAgent = Http.FirefoxUserAgent();

            RequestParams reqParams = new RequestParams();
            reqParams["message"] = Message;
            reqParams["peer_id"] = 2000000002; //+1
            reqParams["dont_parse_links"] = 0;
            reqParams["forward_messages"] = "";
            reqParams["access_token"] = Variables_Static.Token;
            reqParams["v"] = Variables_Static.v;
            string response = danni.Post("https://api.vk.com/method/messages.send?", reqParams).ToString();

            Random rn = new Random();
            
        }
        public void Send(Variables data, string Message, string Media = "")
        {
            var danni = new HttpRequest();
            danni.Cookies = new CookieDictionary();
            danni.KeepAlive = true;
            danni.UserAgent = Http.FirefoxUserAgent();

            RequestParams reqParams = new RequestParams();
            reqParams["message"] = Message;
            reqParams["peer_id"] = data.IdPolsBes; //+1
            reqParams["dont_parse_links"] = 0;
            reqParams["attachment"] = Media;
            reqParams["forward_messages"] = "";
            reqParams["access_token"] = data.Token;
            reqParams["v"] = data.v;
            string response = danni.Post("https://api.vk.com/method/messages.send?", reqParams).ToString();

           
            

            if(response.Contains("error"))
            {
                JObject json = JObject.Parse(response);
                if (Convert.ToInt32(json["error"]["error_code"]) == 14)
                {
                    
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($@"Капча, решаем");
                    string captcha_key = CaptchaOk(json["error"]["captcha_img"].ToString());
                    Console.WriteLine($@"Решили капчу");


                    reqParams = new RequestParams();
                    reqParams["message"] = Message;
                    reqParams["captcha_key"] = captcha_key;
                    reqParams["message"] = json["error"]["captcha_sid"].ToString();
                    reqParams["peer_id"] = data.IdPolsBes;
                    reqParams["attachment"] = Media;
                    reqParams["forward_messages"] = data.IdMes;
                    reqParams["access_token"] = data.Token;
                    reqParams["v"] = data.v;
                    response = danni.Post("https://api.vk.com/method/messages.send?", reqParams).ToString();


                }
            }
        }
        
        private static string CaptchaOk(string LinkImage)
        {
            var danni = new HttpRequest();
            danni.Get(LinkImage).ToFile("captcha.jpg");
            return "";
        }

    }
}
