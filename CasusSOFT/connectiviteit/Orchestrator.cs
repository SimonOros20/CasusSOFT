using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net;

namespace CasusSOFT.connectiviteit
{
    public class Orchestrator
    {
        private readonly NodeManagement nodeManagement;
        private readonly NodeNetworkSide nodeNetworkSide;
        private readonly Service service;

        public Orchestrator()
        {
            nodeManagement = new NodeManagement();
            nodeNetworkSide = new NodeNetworkSide(service, IPAddress.Parse("127.0.0.1"), 8080);
            service = new Service();
        }

        public void Start()
        {
            nodeManagement.AddNode(new Node());
            nodeNetworkSide.Start();

            // Voer andere starttaken uit

            Console.WriteLine("Orchestrator gestart.");
        }

        public void Stop()
        {
            // Stop logica voor componenten
            nodeNetworkSide.Dispose();

            // Voer andere stop taken uit

            Console.WriteLine("Orchestrator gestopt.");
        }
    }
}

