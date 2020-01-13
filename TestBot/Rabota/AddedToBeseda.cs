using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;
using System.Threading;
using Newtonsoft.Json.Linq;
using System.Data.SQLite;

using System.IO;
using System.Drawing;
using System.Diagnostics;

namespace TestBot.Rabota
{
    class AddedToBeseda
    {
        public static void AddMe(int id_beseda)
        {
            var danni = new HttpRequest();
            danni.Cookies = new CookieDictionary();
            danni.KeepAlive = true;
            danni.UserAgent = Http.FirefoxUserAgent();

            RequestParams reqParams = new RequestParams();
            reqParams["message"] = "Здарова! Вы пригласили меня в беседу, но для работы необходимо выдать мне права администратора." + "\n" + "Для этого нажмите на название беседы и кликните по кнопке «Назначить администратором» напротив «SAMP BOT»." + "\n" + "Чтобы узнать список доступных команд введи «помощь»";
            reqParams["peer_id"] = id_beseda;
            reqParams["dont_parse_links"] = 0;
            reqParams["attachment"] = "photo-185711407_457239065";
            reqParams["forward_messages"] = "";
            reqParams["access_token"] = Variables.Token;
            reqParams["v"] = Variables.v;
            string response = danni.Post("https://api.vk.com/method/messages.send?", reqParams).ToString();



        }
        





    }
}
