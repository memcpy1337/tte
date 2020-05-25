using System;
using System.Collections.Generic;
using System.Text;

namespace TestBot.Rabota
{
    class Command
    {
        public void Obrabot(int idPols)
        {

            Rabota.MessageSend MesSend = new Rabota.MessageSend();
           /* switch (Varb.RazdeliLower[0])
            {
                case "инфо": Rabota.Function.Vk.Entertainment.info.GetInfo(Varb.RazdeliLower); break;
            }
            */
            
            switch (Varb.TitleLower)
            {
                case "!цирроз": Rabota.Function.Vk.Entertainment.info.GetPidor(Varb.RazdeliLower, idPols); break;
            }
            switch (Varb.TitleLower)
            {
                case "!кепка": Rabota.Function.Vk.Entertainment.info.GetKepka(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "!мут": Rabota.Function.Vk.Entertainment.info.GetMyt(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "!пиво": Rabota.Function.Vk.Entertainment.info.GetPivo(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "!батя": Rabota.Function.Vk.Entertainment.info.GetBatya(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "!кз": Rabota.Function.Vk.Entertainment.info.GetKz(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "!душ": Rabota.Function.Vk.Entertainment.info.GetDush(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "!cелфи": Rabota.Function.Vk.Entertainment.info.GetSelfie(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "!подними": Rabota.Function.Vk.Entertainment.info.GetPodnimi(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "!новости": Rabota.Function.Vk.Entertainment.info.GetNovosti(Varb.RazdeliLower); break;
            }
            switch (Varb.RazdeliLower[0])
            {
                case "!рандом": Rabota.Function.Vk.Entertainment.info.GetRandom(Varb.RazdeliLower, idPols); break;
            }
            switch (Varb.TitleLower)
            {
                case "!radone": Rabota.Function.Vk.Entertainment.info.GetRadone(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "!команды": Rabota.Function.Vk.Entertainment.info.GetKommands(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "!кресло": Rabota.Function.Vk.Entertainment.info.GetKreslo(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "!успех": Rabota.Function.Vk.Entertainment.info.GetYspex(Varb.RazdeliLower, idPols); break;
            }
            switch (Varb.TitleLower)
            {
                case "!напиздел": Rabota.Function.Vk.Entertainment.info.GetNapizdel(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "!гонки": Rabota.Function.Vk.Entertainment.info.GetGonki(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "!уровнять": Rabota.Function.Vk.Entertainment.info.GetYrovn(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "!жокир": Rabota.Function.Vk.Entertainment.info.GetJokir(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "!насрать": Rabota.Function.Vk.Entertainment.info.GetObosr(Varb.RazdeliLower, idPols); break;
            }
            switch (Varb.TitleLower)
            {
                case "!подогреть": Rabota.Function.Vk.Entertainment.info.GetPodogret(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "!развитие": Rabota.Function.Vk.Entertainment.info.GetRazvit(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "!150к": Rabota.Function.Vk.Entertainment.info.Get150k(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "!пьян": Rabota.Function.Vk.Entertainment.info.GetPyan(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "!вес": Rabota.Function.Vk.Entertainment.info.GetVes(Varb.RazdeliLower, idPols); break;
            }
            switch (Varb.TitleLower)
            {
                case "!серега": Rabota.Function.Vk.Entertainment.info.GetSerega(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "!красив": Rabota.Function.Vk.Entertainment.info.GetKrasiv(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "!наебать": Rabota.Function.Vk.Entertainment.info.GetNaebat(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "!пиздануть": Rabota.Function.Vk.Entertainment.info.GetPizdanut(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "!радон": Rabota.Function.Vk.Entertainment.info.GetRadon(Varb.RazdeliLower); break;
            }
            switch (Varb.TitleLower)
            {
                case "!mmr": Rabota.Function.Vk.Entertainment.info.GetMmr(Varb.RazdeliLower); break;
            }
            //switch (Varb.TitleLower)
            //{
            //    case "хочу видео": Rabota.Vk.Messages.wallget2.getwall2(); break;
            //}
            //switch (Varb.TitleLower)
            //{
            //    case "хочу мем": Rabota.Vk.Messages.wallget.getwall(); break;
            //}
            //switch (Varb.TitleLower)
            //{
            //    case "онлайн дрп": Rabota.Program.GetOnline1(); break;
            //}
            //switch (Varb.TitleLower)
            //{
            //    case "онлайн арп": Rabota.Program2.GetOnline2(); break;
            //}
            //switch (Varb.TitleLower)
            //{
            //    case "топ сервера": MesSend.Send("1. Arizona RP(G)" + "\n" + "2. Diamond RP" + "\n" + "3. Evolve RP(DM)" + "\n" + "4. Advance RP" + "\n" + "5. SAMP RP"); break;
            //}



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
