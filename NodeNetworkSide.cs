using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace CasusSOFT.connectiviteit
{
    // Klasse die luistert naar inkomende verbindingen van nodes
    public class NodeNetworkSide : IDisposable
    {
        private readonly TcpListener tcpListener;        // Luisteraar voor inkomende verbindingen
        private byte[] accumulator = new byte[16];        // Accumulator voor het bufferen van inkomende berichten
        private int accumulator_idx = 0;                  // Index voor de accumulator

        // Constructor om een NodeNetworkSide-instantie te initialiseren met een service, IP-adres en poortnummer
        public NodeNetworkSide(Service service, IPAddress ipAddress, int port)
        {
            Service = service;
            tcpListener = new TcpListener(ipAddress, port);
        }

        // Eigenschap om de bijbehorende service te krijgen
        public Service Service { get; }

        // Methode om een foutcode naar de node te sturen
        private async Task SendErrorCode(NetworkStream networkStream, byte code)
        {
            // Stel een foutbericht in met de opgegeven foutcode en stuur het naar de node
            var message = new byte[]
            {
                0x34, 0x4e, 0x44, 0xff,
                0x00, 0x00, 0x00, code,
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00
            };

            await networkStream.WriteAsync(message, 0, message.Length);
        }

        // Methode om een bevestigingsbericht naar de node te sturen
        private async Task SendConfirmation(NetworkStream networkStream)
        {
            // Stel een bevestigingsbericht in en stuur het naar de node
            var message = new byte[]
            {
                0x34, 0x4e, 0x44, 0x00,
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00
            };

            await networkStream.WriteAsync(message, 0, message.Length);
        }

        // Methode om een XNGP-bericht te interpreteren
        private async Task<bool> InterpretMessage(NetworkStream networkStream)
        {
            Console.WriteLine($"Ontvangen XNGP-bericht: {BitConverter.ToString(accumulator)}");

            // Controleer of het ontvangen bericht het juiste 'magic number' heeft
            if (!(accumulator[0] == 0x34 &&
                  accumulator[1] == 0x47 &&
                  accumulator[2] == 0x57))
            {
                Console.WriteLine("Ontvangen bericht heeft het verkeerde 'magic number'");
                await SendErrorCode(networkStream, 0xff);
                return false;
            }

            // Controleer het type bericht en neem de juiste actie
            if (accumulator[3] == 0x00)
            {
                var nodeNetworkAddress = new NodeNetworkAddress(accumulator, 4);
                var nodeIdentity = new NodeIdentity(accumulator, 8);

                Console.WriteLine($"Node '{nodeIdentity}' met IP {nodeNetworkAddress} geregistreerd");

                Service.RegisterNode(nodeNetworkAddress, nodeIdentity);
            }
            else if (accumulator[3] == 0xff)
            {
                Console.WriteLine("Einde van event-uitwisseling met node");
                await SendConfirmation(networkStream);
                return false;
            }

            return true;
        }

        // Methode voor het behandelen van een client
        private async Task ClientHandler(IPEndPoint clientIp, NetworkStream networkStream)
        {
            var inBuffer = new byte[16];

            for (; ; )
            {
                var read = await networkStream.ReadAsync(inBuffer);

                if (read == 0)
                {
                    Console.WriteLine($"Verbinding met client {clientIp.Address} verbroken.");
                    networkStream.Close();
                    return;
                }

                // Vul de accumulator met inkomende gegevens en interpreteer het bericht als de accumulator vol is
                for (int i = 0; i < read; i++)
                {
                    accumulator[accumulator_idx] = inBuffer[i];

                    accumulator_idx++;

                    if (accumulator_idx == 16)
                    {
                        accumulator_idx = 0;

                        // Als het interpreteren van het bericht niet succesvol is, sluit de verbinding
                        if (!await InterpretMessage(networkStream))
                        {
                            networkStream.Close();
                            return;
                        }
                    }
                }
            }
        }

        // Methode om het luisteren te starten voor inkomende verbindingen
        public async Task Start()
        {
            tcpListener.Start();

            Console.WriteLine("Dit deel van de service is actief en operationeel!");

            while (true)
            {
                var client = await tcpListener.AcceptTcpClientAsync();

                _ = Task.Run(async () =>
                {
                    using (client)
                    {
                        IPEndPoint? clientIp = client.Client.RemoteEndPoint as IPEndPoint;

                        if (clientIp == null)
                        {
                            Console.WriteLine("Geen IP-adres beschikbaar");
                            client.Close();
                            return;
                        }

                        Console.WriteLine($"Verbinding met client {clientIp.Address} tot stand gebracht.");

                        try
                        {
                            using (var networkStream = client.GetStream())
                            {
                                await ClientHandler(clientIp, networkStream);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            Console.WriteLine($"Communicatie met client {clientIp.Address} mislukt.");
                        }
                    }
                });
            }
        }

        // Methode om resources vrij te geven bij het afsluiten
        public void Dispose()
        {
            tcpListener.Stop();
        }
    }
}
