using System.Diagnostics;
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
                Console.WriteLine($"Relay has switched!");
            }
            else
            {
                Console.WriteLine($"Relay alarm is not active!");
            }
        }

        public static void SetAlarmMovement(bool Movement) 
        {
            if (Movement == true) 
            {
                Console.WriteLine($"There was movement!");           
            }
            else
            {
                Console.WriteLine("$Movement alarm is not active!");
            }
        }

        public static void SetAlarmTemperature(int SetTemperature) 
        {
            int Temperature = 0;

            if (SetTemperature == Temperature)
            {
                Console.WriteLine("$Temperature is achieved!");
            }
            else
            {
                Console.WriteLine("$Temperature alarm is not active!");
            }

        }

        public static void SetAlarmSwitch(bool Switch)
        {
            if (Switch == true) 
            {
                Console.WriteLine($"Switch is on");
            }
            else
            {
                Console.WriteLine($"Switch alarm is not active!");
            }
        }

        public static void SetAlarmButton(int minutes, int seconds)    
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime;
 
        }

        public static void SetAlarmDial(int number)
        {
            int i = 0;
            while (i <= 350) 
            {
                Console.WriteLine(i.ToString());
                i++;
            }
            if (number == i)
            {
                Console.WriteLine($"Number has reached!");
            }
            else
            {
                Console.WriteLine($"Dial alarm is not active!");
            }
        }

        public static void SetAlarmBuzzer(int freq)
        {
            int i = 0;
            while (i <= 32765)
            {
                Console.WriteLine(i.ToString());
                i++;
            }
            if (freq == i)
            {
                Console.WriteLine($"Frequency has reached!");
            }
            else 
            {
                Console.WriteLine($"Buzzer alarm is not active!");
            }

        }

        public static void GetStatus()
        {
            
        }

        public static void AlarmModus(int hour, int minutes, int seconds) 
        {
                DateTime currentTime = DateTime.Now;
                DateTime alarmTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, hour, minutes, seconds);

                if (alarmTime > currentTime)
                {
                    TimeSpan timeAlarm = currentTime - alarmTime;
                    Console.WriteLine($"Alarm untill{alarmTime}, in {timeAlarm.TotalSeconds} seconds");
                    System.Threading.Thread.Sleep((int)timeAlarm.TotalMilliseconds);
                    Console.WriteLine($"Alarm!");
                }
                else
                {
                    Console.WriteLine($"Alarm time invalid, try again!");
                }
        }
    }

    class NodeTrigger
    {
        static void Main()
        {
            Console.WriteLine("Give a Node and a Pheripheral ID: ");
        }

        public static void Trigger(int Node, int PheripheralId)
        {
            
           switch (PheripheralId)
           {
               case 1:
                    return self.adc.read_uv();
           }
        }

        public static void Triggerr(int PeripheralType, string PeripheralId)
        {
            if (PeripheralType == 1 && PeripheralId == "Button")
            {
                if ("Button" = true)
                {
                    Led = true;

                    if (Led = true && Relay = true)
                    {
                        Relay = false;
                    }

                    else
                    {
                        Relay = true;
                    }
                }

                else
                {
                    Led = false;
                }
            }

            if (PeripheralType == 2 && PeripheralId == "Temperature")
            {

                if ("Temperature" = >23)
                {
                    Buzzer = true;
                }
                else
                {
                    Buzzer = false;
                }
            }
        }   
    }
}