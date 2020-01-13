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
    class SendHouse
    {
        
        public static string Send1(string[] Razdelil)


            
        {

           
            var danni = new HttpRequest();
            danni.Cookies = new CookieDictionary();
            danni.KeepAlive = true;
            danni.UserAgent = Http.FirefoxUserAgent();
            
            RequestParams reqParams = new RequestParams();
             
             string msg = String.Concat<string>(Razdelil);


            reqParams["message"] = msg;
            reqParams["peer_id"] = 2000000001;
            reqParams["dont_parse_links"] = 0;
            reqParams["attachment"] = "";
            reqParams["forward_messages"] = "";
            reqParams["access_token"] = "f6d44bc00fb13a6b680832f53d31b832dec9e875635c96e2b651bcac011ab8c212fe0c9ab7f6067c8725b";
            reqParams["v"] = Variables.v;
            string response = danni.Post("https://api.vk.com/method/messages.send?", reqParams).ToString();

            Random rn = new Random();
            Thread.Sleep(rn.Next(2000, 3000));

            if (response.Contains("error"))
            {
                JObject json = JObject.Parse(response);
                if (Convert.ToInt32(json["error"]["error_code"]) == 14)
                {
                    Rucaptcha.Key = Variables.RucaptchKey;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($@"Капча, решаем");
                    string captcha_key = CaptchaOk(json["error"]["captcha_img"].ToString());
                    Console.WriteLine($@"Решили капчу");


                    reqParams = new RequestParams();
                    reqParams["message"] = "";
                    reqParams["captcha_key"] = captcha_key;
                    reqParams["message"] = json["error"]["captcha_sid"].ToString();
                    reqParams["peer_id"] = 2000000109;
                    reqParams["attachment"] = "";
                    reqParams["forward_messages"] = Variables.IdMes;
                    reqParams["access_token"] = Variables.Token;
                    reqParams["v"] = Variables.v;
                    response = danni.Post("https://api.vk.com/method/messages.send?", reqParams).ToString();

                    return "";
                }
                return "";
            }
            return "";
        }

        private static string CaptchaOk(string LinkImage)
        {
            var danni = new HttpRequest();
            danni.Get(LinkImage).ToFile("captcha.jpg");
            return Rucaptcha.Recognize("captcha.jpg");
        }

    }
}
