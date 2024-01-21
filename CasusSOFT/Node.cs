using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasusSOFT
{
    public class Node
    {
        public Guid NodeID { get; set; }
        public List<Peripheral> Peripherals { get; set; }

        public Node()
        {
            NodeID = Guid.NewGuid();
            Peripherals = new List<Peripheral>();
        }

        public void AddPeripheral(Peripheral peripheral)
        {
            Peripherals.Add(peripheral);
        }
    }

    public class Peripheral
    {
        public int Number { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
    }
}

