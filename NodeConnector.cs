using System;
using System.Net;
using System.Net.Sockets;

namespace CasusSOFT.connectiviteit
{
    // Klasse voor het opzetten van een verbinding met een node via TCP
    public class NodeConnector
    {
        private readonly IPAddress ipAddress;  
        private readonly int port;              

        // Constructor om een NodeConnector-instantie te initialiseren met een IP-adres en poortnummer
        public NodeConnector(string ipAddress, int port) : this(IPAddress.Parse(ipAddress), port)
        {
        }

        public NodeConnector(IPAddress ipAddress, int port)
        {
            this.ipAddress = ipAddress;
            this.port = port;
        }

        // Methode om verbinding te maken met de node en een NodeConnection-instantie terug te geven
        public NodeConnection Connect()
        {
            var tcpClient = new TcpClient();

            // Verbind met de node op het gespecificeerde IP-adres en poortnummer
            tcpClient.Connect(new IPEndPoint(ipAddress, port));

            // Geef een nieuwe NodeConnection-instantie terug gekoppeld aan de TcpClient
            return new NodeConnection(tcpClient);
        }
    }
}
