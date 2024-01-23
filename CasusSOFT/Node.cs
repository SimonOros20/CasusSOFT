using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}

// Namespace voor specifieke nodefunctionaliteiten
namespace Nodemanagement
{
    // Klasse die specifieke eigenschappen van een node binnen deze namespace definieert
    public class Node
    {
        private int nodeId;

        public int NodeId
        {
            get { return nodeId; }
            set { nodeId = value; }
        }
    }

    // Klasse voor het beheren van nodes
    public class NodeManagement
    {
        private List<Node> nodes;

        // Constructor om een nieuwe lijst van nodes te initialiseren
        public NodeManagement()
        {
            nodes = new List<Node>();
        }

        // Methode om een node toe te voegen aan de lijst en een bericht af te drukken
        public void AddNode(Node nieuweNode)
        {
            nodes.Add(nieuweNode);
            Console.WriteLine($"Node: {nieuweNode} toegevoegd.");
        }

        // Methode om een node te verwijderen uit de lijst en een bericht af te drukken
        public void RemoveNode(Node verwijderNode)
        {
            if (nodes.Contains(verwijderNode))
            {
                nodes.Remove(verwijderNode);
                Console.WriteLine($"Node: {verwijderNode} verwijderd.");
            }
            else
            {
                Console.WriteLine("Node niet toegevoegd.");
            }
        }

        // Methode om een node te activeren en een bericht af te drukken
        public void ActivateNode(Node activeerNode)
        {
            if (nodes.Contains(activeerNode))
            {
                Console.WriteLine($"Node:{activeerNode} geactiveerd.");
            }
            else
            {
                Console.WriteLine("Node niet gevonden.");
            }
        }

        // Methode om een node te deactiveren en een bericht af te drukken
        public void DeactivateNode(Node deactiveerNode)
        {
            if (nodes.Contains(deactiveerNode))
            {
                Console.WriteLine($"Node: {deactiveerNode} gedeactiveerd.");
            }
            else
            {
                Console.WriteLine("Node niet gevonden.");
            }
        }
    }
}
