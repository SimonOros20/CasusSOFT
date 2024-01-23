using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI_Casus_Blok_5
{
    public class FunctieBeheerInterface
    {
        public FunctieBeheerInterface()
        {

        }
        public void StartFunctieBeheer() 
        {
            while (true)
            {
                Console.WriteLine("\nFunctiebeheer Menu:");
                Console.WriteLine("1. Sensor Feeds");
                Console.WriteLine("2. Alarms");
                Console.WriteLine("3. Actions");
                Console.WriteLine("4. Afsluiten");

                Console.Write("Voer het nummer van uw keuze in: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        SensorFeedsMenu();
                        break;
                    case "2":
                        AlarmsMenu();
                        break;
                    case "3":
                        ActionsMenu();
                        break;
                    case "4":
                        Console.WriteLine("Programma wordt afgesloten.");
                        return;
                    default:
                        Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
                        break;
                }
            }
        }

        private void SensorFeedsMenu()
        {
            while (true)
            {
                Console.WriteLine("\nSensor Feeds Menu:");
                Console.WriteLine("1. Wijzigen");
                Console.WriteLine("2. Starten");
                Console.WriteLine("3. Stoppen");
                Console.WriteLine("4. Aanmaken");
                Console.WriteLine("5. Verwijderen");
                Console.WriteLine("6. Terug naar hoofdmenu");

                Console.Write("Voer het nummer van uw keuze in: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        // Code voor wijzigen van sensor feeds
                        break;
                    case "2":
                        // Code voor starten van sensor feeds
                        break;
                    case "3":
                        // Code voor stoppen van sensor feeds
                        break;
                    case "4":
                        // Code voor aanmaken van nieuwe sensor feed
                        break;
                    case "5":
                        // Code voor verwijderen van sensor feeds
                        break;
                    case "6":
                        return; // Terug naar het vorige menu
                    default:
                        Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
                        break;
                }
            }
        }

        private void AlarmsMenu()
        {
            while (true)
            {
                Console.WriteLine("\nAlarms Menu:");
                Console.WriteLine("1. Wijzigen");
                Console.WriteLine("2. Starten");
                Console.WriteLine("3. Stoppen");
                Console.WriteLine("4. Aanmaken");
                Console.WriteLine("5. Verwijderen");
                Console.WriteLine("6. Terug naar hoofdmenu");

                Console.Write("Voer het nummer van uw keuze in: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        // Code voor wijzigen van sensor feeds
                        break;
                    case "2":
                        // Code voor starten van sensor feeds
                        break;
                    case "3":
                        // Code voor stoppen van sensor feeds
                        break;
                    case "4":
                        // Code voor aanmaken van nieuwe sensor feed
                        break;
                    case "5":
                        // Code voor verwijderen van sensor feeds
                        break;
                    case "6":
                        // Code om terug te gaan naar het hoofdmenu
                        return; 
                    default:
                        Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
                        break;
                }
            }
        }

        private void ActionsMenu()
        {
            while (true)
            {
                Console.WriteLine("\nActions Menu:");
                Console.WriteLine("1. Wijzigen");
                Console.WriteLine("2. Starten");
                Console.WriteLine("3. Stoppen");
                Console.WriteLine("4. Aanmaken");
                Console.WriteLine("5. Verwijderen");
                Console.WriteLine("6. Terug naar hoofdmenu");

                Console.Write("Voer het nummer van uw keuze in: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        // Code voor wijzigen van sensor feeds
                        break;
                    case "2":
                        // Code voor starten van sensor feeds
                        break;
                    case "3":
                        // Code voor stoppen van sensor feeds
                        break;
                    case "4":
                        // Code voor aanmaken van nieuwe sensor feed
                        break;
                    case "5":
                        // Code voor verwijderen van sensor feeds
                        break;
                    case "6":
                        return; // Terug naar het vorige menu
                    default:
                        Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
                        break;
                }
            }
        }
    }
}
