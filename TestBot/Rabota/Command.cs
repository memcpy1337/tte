using System;
using System.Collections.Generic;
using System.Text;

namespace TestBot.Rabota
{
    class Command
    {
        public void Obrabot()
        {

            Rabota.MessageSend MesSend = new Rabota.MessageSend();
           /* switch (Varb.RazdeliLower[0])
            {
                case "инфо": Rabota.Function.Vk.Entertainment.info.GetInfo(Varb.RazdeliLower); break;
            }
            */
            switch (Varb.TitleLower)
            {
                case "я пидорас?": Rabota.Function.Vk.Entertainment.info.GetPidor(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "найти пидора": Rabota.Vk.Messages.MessagesgetConversationMembers.GetUserMessage(); break;
            }
            switch (Varb.TitleLower)
            {
                case "помощь": Rabota.Vk.Messages.MessagesgetConversationMembers.helpme(); break;
            }
            switch (Varb.TitleLower)
            {
                case "хачу мем": Rabota.Vk.Messages.wallget.getwall(); break;
            }
            switch (Varb.TitleLower)
            {
                case "хачу видео": Rabota.Vk.Messages.wallget2.getwall2(); break;
            }
            switch (Varb.TitleLower)
            {
                case "хочу видео": Rabota.Vk.Messages.wallget2.getwall2(); break;
            }
            switch (Varb.TitleLower)
            {
                case "хочу мем": Rabota.Vk.Messages.wallget.getwall(); break;
            }
            switch (Varb.TitleLower)
            {
                case "онлайн дрп": Rabota.Program.GetOnline1(); break;
            }
            switch (Varb.TitleLower)
            {
                case "онлайн арп": Rabota.Program2.GetOnline2(); break;
            }
            switch (Varb.TitleLower)
            {
                case "топ сервера": MesSend.Send("1. Arizona RP(G)" + "\n" + "2. Diamond RP" + "\n" + "3. Evolve RP(DM)" + "\n" + "4. Advance RP" + "\n" + "5. SAMP RP"); break;
            }



        }
    }


    public class Varb

    {
        public static string Title { get; set; }
        public static string TitleLower { get; set; }
        public static string[] Razdeli { get; set; }
        public static string[] RazdeliLower { get; set; }

        public void SettText()
        {
            Title = Variables.Title;
            TitleLower = Variables.Title.ToLower();
            Razdeli = Variables.Title.Split(' ');
            RazdeliLower = Variables.Title.ToLower().Split(' ');

            
        }
    }
}
