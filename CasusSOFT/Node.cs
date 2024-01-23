using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CLI_Casus_Blok_5
{
    public class Node
    {
        public ulong DeploymentIdentity { get; set; }
        public List<Peripheral> Peripherals { get; set; }
        public bool IsActive { get; set; }

        public Node(ulong deploymentIdentity) 
        {
            DeploymentIdentity = deploymentIdentity;
            Peripherals = new List<Peripheral>();
            IsActive = false;
        }

        private void AddPeripheral(PeripheralType type, PeripheralModel model, int index)
        {
            // Check of er niet meer dan 8 peripherals op de node staan.
            if (Peripherals.Count >= 8)  
            {
                Console.WriteLine("Maximaal aantal peripherals bereikt voor deze node.");
                return;
            }

            // Check of de index niet al in gebruik is.
            if (Peripherals.Any(p => p.Index == index))
            {
                Console.WriteLine($"Peripheral met index {index} bestaat al voor deze node.");
                return;
            }

            // Voeg de nieuwe peripheral toe aan de lijst
            Peripherals.Add(new Peripheral(type, model, index));
            Console.WriteLine($"Peripheral {type} - {model} toegevoegd aan node {DeploymentIdentity} op index {index}.");
        }

        public enum PeripheralType 
        {
            Sensor,
            Control,
            Actuator
        }

        public enum PeripheralModel
        {
            Color,
            Movement,
            Water,
            Temperature,
            PressureAir,
            PressureWater,
            Switch,
            SLider
        }
    }
}
