using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasusSOFT
{
    // Interface voor indicatorcommando's
    public interface IIndicatorCommand
    {
        void Execute();
    }

    // Commando voor het aansturen van een zoemer (buzzer)
    public class BuzzerCommand : IIndicatorCommand
    {
        private readonly Indicator _indicator;
        private readonly int _frequentie;
        private readonly int _duur;

        // Constructor om het indicatorobject en de parameters voor frequentie en duur in te stellen
        public BuzzerCommand(Indicator indicator, int frequentie, int duur)
        {
            _indicator = indicator;
            _frequentie = frequentie;
            _duur = duur;
        }

        // Uitvoeren van het commando om de zoemer aan te sturen
        public void Execute()
        {
            _indicator.Buzzer(_frequentie, _duur);
        }
    }

    // Commando voor het aansturen van een enkele kleur LED
    public class SingleColorLEDCommand : IIndicatorCommand
    {
        private readonly Indicator _indicator;
        private readonly string _color;

        // Constructor om het indicatorobject en de kleur in te stellen
        public SingleColorLEDCommand(Indicator indicator, string color)
        {
            _indicator = indicator;
            _color = color;
        }

        // Uitvoeren van het commando om de enkele kleur LED aan te sturen
        public void Execute()
        {
            _indicator.SingleColorLED(_color);
        }
    }

    // Commando voor het aansturen van een RGB LED
    public class RGBLEDCommand : IIndicatorCommand
    {
        private readonly Indicator _indicator;
        private readonly int _red;
        private readonly int _green;
        private readonly int _blue;

        // Constructor om het indicatorobject en de RGB-waarden in te stellen
        public RGBLEDCommand(Indicator indicator, int red, int green, int blue)
        {
            _indicator = indicator;
            _red = red;
            _green = green;
            _blue = blue;
        }

        // Uitvoeren van het commando om de RGB LED aan te sturen
        public void Execute()
        {
            _indicator.RGBLED(_red, _green, _blue);
        }
    }

    // Klasse die de indicatorfunctionaliteiten bevat
    public class Indicator
    {
        // Methode om de zoemer aan te sturen met de opgegeven frequentie en duur
        public void Buzzer(int frequentie, int duur)
        {
            // Implementeer de aansturing van de zoemer (buzzer)
        }



        // Methode om de enkele kleur LED aan te sturen met de opgegeven kleur
        public void SingleColorLED(string color)
        {
            // Implementeer de aansturing van de enkele kleur LED
        }




        // Methode om de RGB LED aan te sturen met de opgegeven RGB-waarden
        public void RGBLED(int red, int green, int blue)
        {
            // Implementeer de aansturing van de RGB LED
        }
    }
}
