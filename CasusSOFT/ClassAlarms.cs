using System.Runtime.CompilerServices;

namespace ClassAlarms
{


    public class Alarms
    {
        
        static void Main(string[] args)
        {
            SetAlarmRelay(false);
            SetAlarmMovement(false);
        }

        public static void SetAlarmRelay(bool Relay)
        {
            if (Relay == true) 
            {
                Console.WriteLine("Relay has switched!");
            }
            else
            {
                Console.WriteLine("Relay alarm is not active!");
            }
        }

        public static void SetAlarmMovement(bool Movement) 
        {
            if (Movement == true) 
            {
                Console.WriteLine("There was movement!");           
            }
            else
            {
                Console.WriteLine("Movement alarm is not active!");
            }
        }

        public static void SetAlarmTemperature(int SetTemperature) 
        {
            int Temperature = 0;

            if (SetTemperature == Temperature)
            {
                Console.WriteLine("Temperature is achieved!");
            }
            else
            {
                Console.WriteLine("Temperature alarm is not active!");
            }
  
        }  
