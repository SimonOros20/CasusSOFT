using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasusSOFT
{
    // Interface voor bedieningscommando's
    public interface IControlCommand
    {
        void Execute();
    }

    // Commando voor het inschakelen van de bediening
    public class AanCommand : IControlCommand
    {
        private readonly Control _control;

        // Constructor om het controleobject in te stellen
        public AanCommand(Control control)
        {
            _control = control;
        }

        // Uitvoeren van het commando om de bediening in te schakelen
        public void Execute()
        {
            _control.Aan();
        }
    }

    // Commando voor het uitschakelen van de bediening
    public class UitCommand : IControlCommand
    {
        private readonly Control _control;

        // Constructor om het controleobject in te stellen
        public UitCommand(Control control)
        {
            _control = control;
        }

        // Uitvoeren van het commando om de bediening uit te schakelen
        public void Execute()
        {
            _control.Uit();
        }
    }

    // Commando voor het indrukken van een knop op de bediening
    public class ButtonCommand : IControlCommand
    {
        private readonly Control _control;

        // Constructor om het controleobject in te stellen
        public ButtonCommand(Control control)
        {
            _control = control;
        }

        // Uitvoeren van het commando om een knop op de bediening in te drukken
        public void Execute()
        {
            _control.Button();
        }
    }

    // Commando voor het instellen van de regeling op de bediening
    public class RegelingCommand : IControlCommand
    {
        private readonly Control _control;
        private readonly int _value;

        // Constructor om het controleobject en de waarde in te stellen
        public RegelingCommand(Control control, int value)
        {
            _control = control;
            _value = value;
        }

        // Uitvoeren van het commando om de regeling op de bediening in te stellen
        public void Execute()
        {
            _control.Regeling(_value);
        }
    }

    // Klasse die de bedieningsfunctionaliteiten bevat
    public class Control
    {
        // Methode om de bediening in te schakelen
        public void Aan()
        {
            Console.WriteLine("Aan!");
        }

        // Methode om de bediening uit te schakelen
        public void Uit()
        {
            Console.WriteLine("Uit!");
        }

        // Methode om aan te geven dat een knop op de bediening is ingedrukt
        public void Button()
        {
            Console.WriteLine("Knop is ingedrukt");
        }

        // Methode om de regeling op de bediening in te stellen
        public void Regeling(int value)
        {
            // Controleer of de waarde binnen het juiste bereik ligt
            if (value < 0 || value > 100)
            {
                Console.WriteLine("Regeling mogelijk tussen 0 en 100");
            }
            else
            {
                Console.WriteLine($"Dimmer staat op: {value}");
            }
        }
    }
}
