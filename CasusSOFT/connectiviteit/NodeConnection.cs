using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace CasusSOFT.connectiviteit
{
    // Enum voor verschillende commando's die naar de node kunnen worden gestuurd
    public enum NodeCommands
    {
        ListPeripherals = 0,
    }

    // Klasse voor het opzeten van een verbinding met een node
    public class NodeConnection : IDisposable
    {
        private readonly TcpClient tcpClient;
        private readonly NetworkStream stream;

        // Constructor om een NodeConnection-instantie te initialiseren met een gegeven TcpClient
        public NodeConnection(TcpClient tcpClient)
        {
            this.tcpClient = tcpClient;
            stream = tcpClient.GetStream();
        }

        // Methode om een integer om te zetten naar een byte-array
        private void IntToBytes(int toEncode, byte[] bytes, int offset)
        {
            bytes[offset] = (byte)(toEncode >> 24 & 0xff);
            bytes[offset + 1] = (byte)(toEncode >> 16 & 0xff);
            bytes[offset + 2] = (byte)(toEncode >> 8 & 0xff);
            bytes[offset + 3] = (byte)(toEncode & 0xff);
        }

        // Methode om een frame te schrijven naar de node met optionele parameters
        private async Task WriteFrame(int pa, int pb = 0, int pc = 0, int pd = 0)
        {
            byte[] outBuffer = new byte[16];

            IntToBytes(pa, outBuffer, 0);
            IntToBytes(pb, outBuffer, 4);
            IntToBytes(pc, outBuffer, 8);
            IntToBytes(pd, outBuffer, 12);

            await stream.WriteAsync(outBuffer);
        }

        // Buffer voor het ontvangen van frames van de node
        private byte[] accumulator = new byte[16];
        private int accumulatorIdx = 0;

        // Methode om een frame van de node te lezen
        private async Task<bool> ReadFrame()
        {
            var inBuffer = new byte[16];

            for (; ; )
            {
                var read = await stream.ReadAsync(inBuffer);

                if (read == 0)
                {
                    return false;
                }

                for (int i = 0; i < read; i++)
                {
                    accumulator[accumulatorIdx] = inBuffer[i];

                    accumulatorIdx++;

                    if (accumulatorIdx == 16)
                    {
                        accumulatorIdx = 0;

                        return true;
                    }
                }
            }
        }

        // Methode om de lijst met peripherals op te vragen van de node
        public async Task<byte[]?> ListPeripherals()
        {
            await WriteFrame((int)NodeCommands.ListPeripherals);

            return await ReadFrame() ? (byte[])accumulator.Clone() : null;
        }

        // Implementatie van de IDisposable-interface om resources vrij te geven
        public void Dispose()
        {
            stream.Dispose();
            tcpClient.Dispose();
        }
    }
}
