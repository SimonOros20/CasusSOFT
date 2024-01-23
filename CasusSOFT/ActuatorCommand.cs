using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasusSOFT
{
    // Interface voor actuatorcommando's
    public interface IActuatorCommand
    {
        void Execute();
    }

    // Commando om het relais in te schakelen
    public class TurnOnRelaisCommand : IActuatorCommand
    {
        private readonly Actuator _actuator;

        // Constructor om het actuatorobject in te stellen
        public TurnOnRelaisCommand(Actuator actuator)
        {
            _actuator = actuator;
        }

        // Uitvoeren van het commando om het relais in te schakelen
        public void Execute()
        {
            _actuator.ControlRelais(true);
        }
    }

    // Commando om het relais uit te schakelen
    public class TurnOffRelaisCommand : IActuatorCommand
    {
        private readonly Actuator _actuator;

        // Constructor om het actuatorobject in te stellen
        public TurnOffRelaisCommand(Actuator actuator)
        {
            _actuator = actuator;
        }

        // Uitvoeren van het commando om het relais uit te schakelen
        public void Execute()
        {
            _actuator.ControlRelais(false);
        }
    }

    // Klasse die de actuatorfunctionaliteit bevat
    public class Actuator
    {
        // Methode om het relais te bedienen (in- of uitschakelen)
        public void ControlRelais(bool turnOn)
        {
            // Controleer of het relais moet worden ingeschakeld of uitgeschakeld
            if (turnOn)
            {
                Console.WriteLine("Relais is aan");
            }
            else
            {
                Console.WriteLine("Relais is uit");
            }
        }
    }
}
