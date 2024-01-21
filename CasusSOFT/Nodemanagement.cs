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
        }

        public void DeactivateNode(Node node)
        {
        }

        public List<Node> GetNodeList()
        {
            return nodes;
        }
    }
}