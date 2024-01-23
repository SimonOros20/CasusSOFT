using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CLI_Casus_Blok_5.Node;

namespace CLI_Casus_Blok_5
{
    public class Peripheral
    {
        public PeripheralType Type { get; }
        public PeripheralModel Model { get; }
        public int Index { get; }

        public Peripheral(PeripheralType type, PeripheralModel model, int index)
        {
            Type = type;
            Model = model;
            Index = index;
        }
    }
}
