using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CLI_Casus_Blok_5
{
    public class NodeBeheerInterface
    {
        public List<Node> nodes;

        public NodeBeheerInterface() 
        {
            nodes = new List<Node>();           // Deze lijst is een tijdelijke vervanger voor de database 
        }

        public void StartNodeBeheer()
        {
            while (true)
            {
                Console.WriteLine("\nNodebeheer Menu:");
                Console.WriteLine("1. Nodes bekijken");
                Console.WriteLine("2. Node toevoegen");
                Console.WriteLine("3. Node verwijderen");
                Console.WriteLine("4. Node activeren");
                Console.WriteLine("5. Node deactiveren");
                Console.WriteLine("6. Terug naar hoofdmenu");

                Console.Write("Voer het nummer van uw keuze in: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ViewNodes();
                        break;
                    case "2":
                        AddNode();
                        break;
                    case "3":
                        RemoveNode();
                        break;
                    case "4":
                        ActivateNode();
                        break;
                    case "5":
                        DeactivateNode();
                        break;
                    case "6":
                        // code om terug te gaan naar hoofdmenu
                        return; 
                    default:
                        Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
                        break;
                }
            } 
        }

        private void ViewNodes()                        
        {
            Console.WriteLine("\nLijst van Nodes:");    // hier moet code staan om data op te vragen uit de database
            foreach (var node in nodes)
            {
                Console.WriteLine($"Node ID: {node.DeploymentIdentity}, Actief: {node.IsActive}");
                Console.WriteLine("Peripherals:");
                foreach (var peripheral in node.Peripherals)
                {
                    Console.WriteLine($"- Type: {peripheral.Type}, Model: {peripheral.Model}, Index: {peripheral.Index}");
                }
                Console.WriteLine();
            }
        }

        private void AddNode()
        {
            Console.Write("Voer de Deployment Identity in (64-bit nummer): ");
            ulong deploymentIdentity = ulong.Parse(Console.ReadLine());

            Node newNode = new Node(deploymentIdentity);
            nodes.Add(newNode);

            Console.WriteLine($"Node met Deployment Identity {deploymentIdentity} toegevoegd!");
        }

        private void RemoveNode()
        {
            Console.Write("Voer de Deployment Identity in van de node om te verwijderen: ");
            ulong deploymentIdentityToRemove = ulong.Parse(Console.ReadLine());

            Node nodeToRemove = nodes.FirstOrDefault(node => node.DeploymentIdentity == deploymentIdentityToRemove);

            if (nodeToRemove != null)
            {
                nodes.Remove(nodeToRemove);
                Console.WriteLine($"Node met Deployment Identity {deploymentIdentityToRemove} verwijderd.");
            }
            else
            {
                Console.WriteLine($"Node met Deployment Identity {deploymentIdentityToRemove} niet gevonden.");
            }
        }

        private void ActivateNode()
        {
            Console.Write("Voer de Deployment Identity in van de node om te activeren: ");
            ulong deploymentIdentityToActivate = ulong.Parse(Console.ReadLine());

            Node nodeToActivate = nodes.FirstOrDefault(node => node.DeploymentIdentity == deploymentIdentityToActivate);

            if (nodeToActivate != null)
            {
                nodeToActivate.IsActive = true;
                Console.WriteLine($"Node met Deployment Identity {deploymentIdentityToActivate} geactiveerd.");
            }
            else
            {
                Console.WriteLine($"Node met Deployment Identity {deploymentIdentityToActivate} niet gevonden.");
            }
        }

        private void DeactivateNode()
        {
            Console.Write("Voer de Deployment Identity in van de node om te deactiveren: ");
            ulong deploymentIdentityToDeactivate = ulong.Parse(Console.ReadLine());

            Node nodeToDeactivate = nodes.FirstOrDefault(node => node.DeploymentIdentity == deploymentIdentityToDeactivate);

            if (nodeToDeactivate != null)
            {
                nodeToDeactivate.IsActive = false;
                Console.WriteLine($"Node met Deployment Identity {deploymentIdentityToDeactivate} gedeactiveerd.");
            }
            else
            {
                Console.WriteLine($"Node met Deployment Identity {deploymentIdentityToDeactivate} niet gevonden.");
            }
        }
    }   
}
