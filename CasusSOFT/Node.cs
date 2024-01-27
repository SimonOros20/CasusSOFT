using System;
using System.Collections.Generic;

namespace CasusSOFT
{
    // Basisklasse voor nodes
    public class Node
    {
        public Guid NodeID { get; set; }
        public List<Peripheral> Peripherals { get; set; }

        // Constructor om een unieke NodeID toe te wijzen en de lijst van peripherals te initialiseren
        public Node()
        {
            NodeID = Guid.NewGuid();
            Peripherals = new List<Peripheral>();
        }

        // Methode om een peripheral toe te voegen aan de lijst
        public void AddPeripheral(Peripheral peripheral)
        {
            Peripherals.Add(peripheral);
        }
    }

    // Klasse die de eigenschappen van een peripheral definieert
    public class Peripheral
    {
        public int Number { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
    }

    // Klasse die specifieke eigenschappen van een node binnen deze namespace definieert
    namespace Nodemanagement
    {
        public class ManagedNode : Node
        {
            public int NodeId { get; set; }
        }

        // Klasse voor het beheren van nodes
        public class NodeManagement
        {
            private List<ManagedNode> nodes;

            // Constructor om een nieuwe lijst van nodes te initialiseren
            public NodeManagement()
            {
                nodes = new List<ManagedNode>();
            }

            // Methode om een node toe te voegen aan de lijst en een bericht af te drukken
            public void AddNode(ManagedNode newNode)
            {
                nodes.Add(newNode);
                Console.WriteLine($"Node: {newNode} toegevoegd.");
            }

            // Methode om een node te verwijderen uit de lijst en een bericht af te drukken
            public void RemoveNode(ManagedNode removeNode)
            {
                if (nodes.Contains(removeNode))
                {
                    nodes.Remove(removeNode);
                    Console.WriteLine($"Node: {removeNode} verwijderd.");
                }
                else
                {
                    Console.WriteLine("Node niet toegevoegd.");
                }
            }

            // Methode om een node te activeren en een bericht af te drukken
            public void ActivateNode(ManagedNode activateNode)
            {
                if (nodes.Contains(activateNode))
                {
                    Console.WriteLine($"Node:{activateNode} geactiveerd.");
                }
                else
                {
                    Console.WriteLine("Node niet gevonden.");
                }
            }

            // Methode om een node te deactiveren en een bericht af te drukken
            public void DeactivateNode(ManagedNode deactivateNode)
            {
                if (nodes.Contains(deactivateNode))
                {
                    Console.WriteLine($"Node: {deactivateNode} gedeactiveerd.");
                }
                else
                {
                    Console.WriteLine("Node niet gevonden.");
                }
            }
        }
    }
}
