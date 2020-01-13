using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestBot.Rabota.Function.Vk.Entertainment
{
    class info
    {
       /* public static string GetInfo(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            if(Razdelil.Count() == 1)
            {
                MesSend.Send(Rabota.Vk.Users.UsersGetVk.Get());
            }else if(Razdelil.Count() == 2)
            {
                if (Razdelil[1].Contains("https://vk.com/id"))
                    Razdelil[1] = Razdelil[1].Replace("https://vk.com/id", "");
                else
                    Razdelil[1] = Razdelil[1].Replace("https://vk.com/", "");
                MesSend.Send(Rabota.Vk.Users.UsersGetVk.Get(Razdelil[1]));
            }
            return "";
        }
        */
        public static string GetPidor(string[] Razdelil)
        {
            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            Random rnd = new Random();
            int random1 = rnd.Next(0, 100);
            if (random1 <= 50)
            {
                MesSend.Send("Вы не пидорас (пока что)");
            }else
            {
                MesSend.Send("Вы пидорас на " + random1 + "%" + "! Поздравляю.");
            }
            return "";
        }
    }
}
