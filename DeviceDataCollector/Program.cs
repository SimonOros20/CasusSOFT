using DataCollector;
using System;
using System.Collections.Generic;
using System.Text.Json;
using GatewayConnector;

namespace DataCollector
{

    public enum PeripheralType
    {
        Unused = 0,
        Sensor = 1,
        Control = 2,
        Actuator = 3,
        Indicator = 4
    }

    public enum PeripheralId
    {
        Unused = 0,
        Movement = 0,
        Light = 1,
        Temperature = 2,
        Switch = 0,
        Button = 1,
        Dial = 2,
        Relay = 0,
        Buzzer = 0,
        Led = 1,
        LedRGB = 2
    }

    public class Peripheral
    {
        public string PeripheralName { get; set; }
        public PeripheralType Type { get; set; }
        public PeripheralId Id { get; set; }
    }

    public class DataList
    {

    }

    public class DataTuple
    {
        public DataList DataList { get; set; }
        public DateTime Time { get; set; }
    }

    public class DataCollector : GatewayCommandsInterface
    {
        public GatewayConnection connection;

        public DataCollector(GatewayConnection connection)
        {
            this.connection = connection;
        }


        public bool Hello()
        {
            DataCollection<Peripheral, DataTuple> dataCollection = new DataCollection<Peripheral, DataTuple>();
            var connector = new GatewayConnector.GatewayConnector("127.0.0.1", 33369); // <-- Hier is een connectie voor nodig ter implementie

            using (var connection = connector.Connect())
                try
                {
                string receivedMessage = connection.ReceiveMessage();
                List<Peripheral> nodeList = GetNodeList(receivedMessage);

                foreach (var label in nodeList)
                {
                    if (dataCollection.ContainsLabel(label.PeripheralName))
                    {
                        DataList dataList = GetDataList();
                        DateTime time = DateTime.Now;

                        DataTuple dataTuple = new DataTuple { DataList = dataList, Time = time };
                        dataCollection.AddData(label, dataTuple);
                        InsertDataIntoDatabase(label, dataList, time);

                        }
                        else
                    {
                        dataCollection.AddNewLabel(label);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void InsertDataIntoDatabase(Peripheral label, DataList dataList, DateTime time)
        {
            try
            {
                string tableName = label.PeripheralName;
                string typeValue = label.Type.ToString();
                string idValue = label.Id.ToString();
                List<string> columns = new List<string> { tableName, typeValue, idValue};
                List<string> data = new List<string> { label.PeripheralName, dataList.GetType().ToString(), time.ToString()};

                sqlConnection.InsertData(tableName, columns, data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static string ReceiveMessage()
        {
            return "ReceivedMessage";
        }

        public static List<Peripheral> GetNodeList(string message)
        {
            return new List<Peripheral>
            {
                new Peripheral { PeripheralName = "Node1", Type = PeripheralType.Control, Id = PeripheralId.Switch },
                new Peripheral { PeripheralName = "Node2", Type = PeripheralType.Sensor, Id = PeripheralId.Buzzer }
            };
        }

        public static DataList GetDataList()
        {
            return new DataList();
        }

        public List<GatewayNode> GetNodeList()
        {
            throw new NotImplementedException();
        }

        public List<GatewayNodePeriperals> GetPeriperhals(string nodeIdentifier)
        {
            throw new NotImplementedException();
        }

        public class DataCollection<Label, Data>
        {
            private Dictionary<string, List<DataTuple>> dataDictionary;

            public DataCollection()
            {
                dataDictionary = new Dictionary<string, List<DataTuple>>();
            }

            public bool ContainsLabel(string labelName)
            {
                return dataDictionary.ContainsKey(labelName);
            }

            public void AddData(Peripheral peripheral, DataTuple dataTuple)
            {
                string labelName = peripheral.PeripheralName;

                if (!dataDictionary.ContainsKey(labelName))
                {
                    dataDictionary[labelName] = new List<DataTuple>();
                }

                dataDictionary[labelName].Add(dataTuple);
            }

            public void AddNewLabel(Peripheral peripheral)
            {
                string labelName = peripheral.PeripheralName;

                if (!dataDictionary.ContainsKey(labelName))
                {
                    dataDictionary[labelName] = new List<DataTuple>();
                }
            }
        }
    }
}
