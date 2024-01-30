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
        public byte[] Address { get; }

        public NodeNetworkAddress(byte[] data, int startIndex)
        {
            //  we gaan ervan uit dat het netwerkadres een array van 4 bytes is (IPv4-adres)
            Address = new byte[4];
            Array.Copy(data, startIndex, Address, 0, 4);
        }

        public override string ToString()
        {
            return $"{Address[0]}.{Address[1]}.{Address[2]}.{Address[3]}";
        }
    }

    public class NodeIdentity
    {
        public string Identity { get; }

        public NodeIdentity(byte[] data, int startIndex)
        {
            byte identityLength = data[startIndex];
            Identity = System.Text.Encoding.UTF8.GetString(data, startIndex + 1, identityLength);
        }

        public override string ToString()
        {
            return Identity;
        }
    }
}
