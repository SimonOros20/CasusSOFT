using CasusSOFT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasusSOFT
{
    // Interface voor sensorcommando's
    public interface ISensorCommand
    {
        void Execute(); // Methode om het commando uit te voeren
    }

    // Commando voor bewegingssensor
    public class BewegingCommand : ISensorCommand
    {
        private readonly Sensor _sensor;

        // Constructor om het sensorobject te ontvangen
        public BewegingCommand(Sensor sensor)
        {
            _sensor = sensor;
        }

        // Implementatie van Execute-methode voor bewegingssensor
        public void Execute()
        {
            _sensor.Beweging();
        }
    }

    // Commando voor lichtintensiteitssensor
    public class LichtIntensiteitCommand : ISensorCommand
    {
        private readonly Sensor _sensor;
        private readonly int _intensiteit;

        // Constructor om sensorobject en intensiteit te ontvangen
        public LichtIntensiteitCommand(Sensor sensor, int intensiteit)
        {
            _sensor = sensor;
            _intensiteit = intensiteit;
        }

        // Implementatie van Execute-methode voor lichtintensiteitssensor
        public void Execute()
        {
            _sensor.LichtIntensiteit(_intensiteit);
        }
    }

    // Commando voor temperatuursensor
    public class TemperatuurCommand : ISensorCommand
    {
        private readonly Sensor _sensor;
        private readonly int _temp;

        // Constructor om sensorobject en temperatuur te ontvangen
        public TemperatuurCommand(Sensor sensor, int temp)
        {
            _sensor = sensor;
            _temp = temp;
        }

        // Implementatie van Execute-methode voor temperatuursensor
        public void Execute()
        {
            _sensor.Temperatuur(_temp);
        }
    }

    // Sensorklasse die van Node erft
    public class Sensor : Node
    {
        private readonly int _sensorId;

        // Constructor om sensor-ID te ontvangen
        public Sensor(int sensorId)
        {
            _sensorId = sensorId;
        }

        // Methode om beweging te rapporteren
        public void Beweging()
        {
            Console.WriteLine($"Er is beweging op Sensor {_sensorId}");
        }

        // Methode om lichtintensiteit te rapporteren
        public void LichtIntensiteit(int intensiteit)
        {
            Console.WriteLine($"Lichtintensiteit op Sensor {_sensorId}: {intensiteit}");
        }

        // Methode om temperatuur te rapporteren
        public void Temperatuur(int temp)
        {
            Console.WriteLine($"Temperatuur op Sensor {_sensorId}: {temp}");
        }
    }
}
