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
            // Initialisatie van de verschillende componenten
            service = new Service();
            nodeManagement = new NodeManagement();
            nodeNetworkSide = new NodeNetworkSide(service, IPAddress.Parse("127.0.0.1"), 8080);
        }

        public void Start()
        {
            // Voeg een node toe aan het nodeManagement
            nodeManagement.AddNode(new Node());

            // Start luisteren naar inkomende verbindingen
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
