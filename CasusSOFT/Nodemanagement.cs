using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasusSOFT
{
    public class NodeManagement
    {
        private List<Node> nodes;

        public NodeManagement()
        {
            nodes = new List<Node>();
        }

        public void AddNode(Node node)
        {
            nodes.Add(node);
        }

        public void RemoveNode(Node node)
        {
            nodes.Remove(node);
        }

        public void ActivateNode(Node node)
        {
            if (nodes.Contains(node))
            {
                // Voeg hier code toe om een node te activeren, bijvoorbeeld: node.Activate();
                Console.WriteLine($"Node {node} geactiveerd.");
            }
            else
            {
                Console.WriteLine($"Node {node} niet gevonden in de lijst.");
            }
        }

        public void DeactivateNode(Node node)
        {
            if (nodes.Contains(node))
            {
                // Voeg hier code toe om een node te deactiveren, bijvoorbeeld: node.Deactivate();
                Console.WriteLine($"Node {node} gedeactiveerd.");
            }
            else
            {
                Console.WriteLine($"Node {node} niet gevonden in de lijst.");
            }
        }

        public List<Node> GetNodeList()
        {
            return nodes;
        }
    }
}
