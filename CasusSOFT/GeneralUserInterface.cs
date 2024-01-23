using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CLI_Casus_Blok_5
{
    public class GeneralUserInterface
    {   
        // private GatewayConnection gatewayConnection;

        public GeneralUserInterface()
        {
           //  gatewayConnection = new GatewayConnection(); 
        }

        public  void Start()
        {
            Console.WriteLine("Maak een keuze uit de onderstaande opties:\n");

            Console.WriteLine("1. Functiebeheer.");
            Console.WriteLine("2. Nodebeheer.\n");

            Console.WriteLine("Voor uw keuze hier in: ");
            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                FunctieBeheerInterface functieBeheer = new ();
                functieBeheer.StartFunctieBeheer();
            }
            else if (userInput == "2")
            {
                NodeBeheerInterface nodeBeheer = new ();
                nodeBeheer.StartNodeBeheer();
            }
            else
            {
                Console.WriteLine("Verkeerde input. Kies 1 of 2.");
            }
        }
    }
}
