using Casus_Blok_5__versie_2_;
using CLI_Casus_Blok_5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Casus_Blok_5__versie_2_
{
    public class Trigger
    {
        public PeripheralType Type { get; set; }
        public PeripheralId Id { get; set; }
        public int Function { get; set; }
        public int Value { get; set; }

        private int _previousValue;

        public void Execute(int updatedValue)
        {
            switch (Function)
            {
                case 0:
                    // 0 = elke waarde-verandering (waarde wordt genegeerd)
                    Console.WriteLine($"Trigger genegeerd voor: {Type} - {Id}");
                    break;
                case 1:
                    // 1 = elke waarde-verandering naar precies de opgegeven waarde
                    if (updatedValue == Value)
                        Console.WriteLine($"Functie wordt uitgevoerd voor: {Type} - {Id}");
                    break;
                case 2:
                    // 2 = elke waarde-verandering naar een waarde groter dan waarde
                    if (updatedValue > Value)
                        Console.WriteLine($"Functie wordt uitgevoerd voor: {Type} - {Id}");
                    break;
                case 3:
                    // 3 = elke waarde-verandering naar een waarde kleiner dan waarde
                    if (updatedValue < Value)
                        Console.WriteLine($"Functie wordt uitgevoerd voor: {Type} - {Id}");
                    break;
                case 4:
                    // 4 = net zoals 2, maar voorkomt repetities.
                    if (updatedValue > Value && updatedValue != _previousValue)
                    {
                        Console.WriteLine($"Functie wordt uitgevoerd voor: {Type} - {Id}");
                        _previousValue = updatedValue;
                    }
                    break;
                case 5:
                    // 5 = net zoals 3, maar voorkomt repetities.
                    if (updatedValue < Value && updatedValue != _previousValue)
                    {
                        Console.WriteLine($"Functie wordt uitgevoerd voor: {Type} - {Id}");
                        _previousValue = updatedValue;
                    }
                    break;
                case 6:
                    // 6 = delete trigger
                    Console.WriteLine($"Trigger wordt verwijderd voor: {Type} - {Id}");
                    break;
                default:
                    Console.WriteLine($"Onbekende functie: {Function} voor: {Type} - {Id}");
                    break;
            }
        }


    }
    public class TriggerCommand
    {
        private readonly Trigger _trigger;
        private readonly int _updatedValue;

        public TriggerCommand(Trigger trigger, int updatedValue)
        {
            _trigger = trigger;
            _updatedValue = updatedValue;
        }

        public void Execute()
        {
            _trigger.Execute(_updatedValue);
        }

    }

    public class TriggerInvoker
    {
        private readonly List<TriggerCommand> _commands = new List<TriggerCommand>();
        private readonly int updatedValue;

        public void AddTrigger(Trigger trigger)
        {
            _commands.Add(new TriggerCommand(trigger, updatedValue));
        }

        public void DelTrigger(Trigger trigger)
        {
            var commandToRemove = _commands.Find(command => command.Equals(new TriggerCommand(trigger, updatedValue)));
            if (commandToRemove != null)
            {
                _commands.Remove(commandToRemove);
                Console.WriteLine($"Trigger verwijderd voor: {trigger.Type} - {trigger.Id}");
            }
            else
            {
                Console.WriteLine($"Trigger niet gevonden voor verwijdering: {trigger.Type} - {trigger.Id}");
            }
        }
        public void ShowTriggers()
        {
            foreach (var command in _commands)
            {
                Console.WriteLine(command.ToString());
            }
        }
    }
}
public class Program
{
    public static void Main()           // voorbeeld voor het aanmaken van nieuwe triggers
    {

        var triggerInvoker = new TriggerInvoker();

        var trigger1 = new Trigger
        {
            Type = PeripheralType.Sensor,
            Id = PeripheralId.Movement,
            Function = 2,
            Value = 10
        };

        var trigger2 = new Trigger
        {
            Type = PeripheralType.Control,
            Id = PeripheralId.Button,
            Function = 1,
            Value = 5
        };

        triggerInvoker.AddTrigger(trigger1);
        triggerInvoker.AddTrigger(trigger2);


        triggerInvoker.ShowTriggers();          //spreekt voor zich maar zo krijg je een lijst met triggers

        var triggerToDelete = new Trigger
        {
            Type = PeripheralType.Sensor,
            Id = PeripheralId.Movement,
            Function = 6
        };

        triggerInvoker.DelTrigger(triggerToDelete);
        triggerInvoker.ShowTriggers();
    }
}