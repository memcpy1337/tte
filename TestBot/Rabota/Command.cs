using System;
using System.Collections.Generic;
using System.Text;

namespace TestBot.Rabota
{
    class Command
    {
        public void Obrabot(int idPols, Variables data)
        {

            Rabota.MessageSend MesSend = new Rabota.MessageSend();
            /* switch (Varb.RazdeliLower[0])
             {
                 case "инфо": Rabota.Function.Vk.Entertainment.info.GetInfo(Varb.RazdeliLower); break;
             }
             */
            try
            {
                if (Rabota.Function.Vk.Entertainment.info.CheckRang(data) == "1") return;
                switch (Varb.TitleLower)
                {
                    case "!цирроз": Rabota.Function.Vk.Entertainment.info.GetPidor(Varb.RazdeliLower, idPols, data); return;

                    case "!кепка": Rabota.Function.Vk.Entertainment.info.GetKepka(Varb.RazdeliLower, data); return;

                    case "!мут": Rabota.Function.Vk.Entertainment.info.GetMyt(Varb.RazdeliLower, data); return;

                    case "!пиво": Rabota.Function.Vk.Entertainment.info.GetPivo(Varb.RazdeliLower, data); return;


                    case "!батя": Rabota.Function.Vk.Entertainment.info.GetBatya(Varb.RazdeliLower, data); return;


                    case "!кз": Rabota.Function.Vk.Entertainment.info.GetKz(Varb.RazdeliLower, data); return;


                    case "!душ": Rabota.Function.Vk.Entertainment.info.GetDush(Varb.RazdeliLower, data); return;

                    case "!cелфи": Rabota.Function.Vk.Entertainment.info.GetSelfie(Varb.RazdeliLower, data); return;

                    case "!подними": Rabota.Function.Vk.Entertainment.info.GetPodnimi(Varb.RazdeliLower, data); return;

                    case "!новости": Rabota.Function.Vk.Entertainment.info.GetNovosti(Varb.RazdeliLower, data); return;

                    //switch (Varb.RazdeliLower[0])
                    //{
                    case "!рандом": Rabota.Function.Vk.Entertainment.info.GetRandom(Varb.RazdeliLower, idPols, data); return;



                    case "!radone": Rabota.Function.Vk.Entertainment.info.GetRadone(Varb.RazdeliLower, data); return;

                    case "!команды": Rabota.Function.Vk.Entertainment.info.GetKommands(Varb.RazdeliLower, data); return;

                    case "!функции": Rabota.Function.Vk.Entertainment.info.GetFunction(Varb.RazdeliLower, data); return;

                    case "!ранг": Rabota.Function.Vk.Entertainment.info.MyRang(Varb.RazdeliLower, data); return;


                    case "!кресло": Rabota.Function.Vk.Entertainment.info.GetKreslo(Varb.RazdeliLower, data); return;


                    case "!успех": Rabota.Function.Vk.Entertainment.info.GetYspex(Varb.RazdeliLower, idPols, data); return;


                    case "!напиздел": Rabota.Function.Vk.Entertainment.info.GetNapizdel(Varb.RazdeliLower, data); return;


                    case "!гонки": Rabota.Function.Vk.Entertainment.info.GetGonki(Varb.RazdeliLower, data); return;


                    case "!уровнять": Rabota.Function.Vk.Entertainment.info.GetYrovn(Varb.RazdeliLower, data); return;


                    case "!жокир": Rabota.Function.Vk.Entertainment.info.GetJokir(Varb.RazdeliLower, data); return;


                    case "!насрать": Rabota.Function.Vk.Entertainment.info.GetObosr(Varb.RazdeliLower, idPols, data); return;


                    case "!подогреть": Rabota.Function.Vk.Entertainment.info.GetPodogret(Varb.RazdeliLower, data); return;


                    case "!развитие": Rabota.Function.Vk.Entertainment.info.GetRazvit(Varb.RazdeliLower, data); return;


                    case "!150к": Rabota.Function.Vk.Entertainment.info.Get150k(Varb.RazdeliLower, data); return;


                    case "!пьян": Rabota.Function.Vk.Entertainment.info.GetPyan(Varb.RazdeliLower, data); return;


                    case "!вес": Rabota.Function.Vk.Entertainment.info.GetVes(Varb.RazdeliLower, idPols, data); return;


                    case "!серега": Rabota.Function.Vk.Entertainment.info.GetSerega(Varb.RazdeliLower, data); return;


                    case "!красив": Rabota.Function.Vk.Entertainment.info.GetKrasiv(Varb.RazdeliLower, data); return;




                    case "!наебать": Rabota.Function.Vk.Entertainment.info.GetNaebat(Varb.RazdeliLower, data); return;


                    case "!пиздануть": Rabota.Function.Vk.Entertainment.info.GetPizdanut(Varb.RazdeliLower, data); return;


                    case "!радон": Rabota.Function.Vk.Entertainment.info.GetRadon(Varb.RazdeliLower, data); return;


                    case "!mmr":
                        Rabota.Function.Vk.Entertainment.info.GetMmr(Varb.RazdeliLower, data);
                        return;

                    case "!вод":
                        Rabota.Function.Vk.Entertainment.info.GetVods(Varb.RazdeliLower, data);
                        return;

                }
                switch (Varb.RazdeliLower[0])
                {

                    case "!рандом": Rabota.Function.Vk.Entertainment.info.GetRandom(Varb.RazdeliLower, idPols, data); return;
                    case "!создать": Rabota.Function.Vk.Entertainment.info.Sozdat(Varb.RazdeliLower, data); return;
                    case "!удалить": Rabota.Function.Vk.Entertainment.info.Ydalit(Varb.RazdeliLower, data); return;
                    case "!повысить": Rabota.Function.Vk.Entertainment.info.UpRang(Varb.RazdeliLower, data); return;
                    case "!понизить": Rabota.Function.Vk.Entertainment.info.DownRang(Varb.RazdeliLower, data); return;
                    case "!игра": Rabota.Function.Vk.Entertainment.info.Game(Varb.RazdeliLower, data); return;
                    case "!ответ": Rabota.Function.Vk.Entertainment.info.GameAnswer(Varb.RazdeliLower, data); return;
                    case "!дуэль": Rabota.Function.Vk.Entertainment.info.Duel(Varb.RazdeliLower, data); return;
                    case "!пуля": Rabota.Function.Vk.Entertainment.info.ChooseBullet(Varb.RazdeliLower, data); return;
                    case "!стата": Rabota.Function.Vk.Entertainment.info.GetStats(Varb.RazdeliLower, data); return;

                }
                if (Varb.RazdeliLower[0].Substring(0, 1) == "!")
                {
                    Rabota.Function.Vk.Entertainment.info.GetCustomCommand(Varb.RazdeliLower[0], data);
                    return;

                }

            }
            catch
            {

            }

        }
    }


    public class Varb

    {
        public static string Title { get; set; }
        public static string TitleLower { get; set; }
        public static string[] Razdeli { get; set; }
        public static string[] RazdeliLower { get; set; }

        public void SettText(Variables data)
        {
            Title = data.Title;
            TitleLower = data.Title.ToLower();
            Razdeli = data.Title.Split(' ');
            RazdeliLower = data.Title.ToLower().Split(' ');

            
        }
    }
}
