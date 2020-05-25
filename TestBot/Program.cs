using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;
using Newtonsoft.Json.Linq;
namespace TestBot
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //Rabota.Program.GetTimer();
            //Rabota.Program2.GetTimer1();
            Rabota.LongPollServer.zaprossLongPoll();
            
            
        }
    }
}
