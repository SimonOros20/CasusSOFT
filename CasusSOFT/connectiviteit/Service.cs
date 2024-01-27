using System;
using System.Collections.Generic;
using System.Linq;


namespace CasusSOFT.connectiviteit
{
    // Klasse die verantwoordelijk is voor het registreren en beheren van nodes
    public class Service
    {
        // Dictionary om geregistreerde nodes bij te houden, gekoppeld aan hun NodeNetworkAddress
        private Dictionary<NodeNetworkAddress, NodeIdentity> registeredNodes = new Dictionary<NodeNetworkAddress, NodeIdentity>();

        // Methode om een node te registreren met het bijbehorende NodeNetworkAddress en NodeIdentity
        public void RegisterNode(NodeNetworkAddress nodeNetworkAddress, NodeIdentity nodeIdentity)
        {
            registeredNodes[nodeNetworkAddress] = nodeIdentity;
        }

        // Methode om geregistreerde nodes af te drukken naar de console
        public void PrintRegisteredNodes()
        {
            Console.WriteLine("Registered Nodes:");

            foreach (var kvp in registeredNodes)
            {
                Console.WriteLine($"Node: {kvp.Value}, IP: {kvp.Key}");
            }
        }
    }

    public class NodeNetworkAddress
    {
    

        public NodeNetworkAddress(byte[] data, int startIndex)
        {
         
        }
    }

    public class NodeIdentity
    {
        

        public NodeIdentity(byte[] data, int startIndex)
        {
         
        }
    }
}