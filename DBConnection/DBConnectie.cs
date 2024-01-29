using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace CLI_Casus_Blok_5
{
    class DBConnectie
    {
        public string connectionString { get; private set; }
        public DBConnectie()
        {
            connectionString = "Data source=database.db; Version=3; New=True; Compress=True;";

        }

        public virtual void Open()
        {
            // opent connectie maakt niet uit welke wordt overschreven.
        }

        public virtual void Close()
        {
            // sluit database connectie
        }

        public virtual DataTable ReadData(string tableName)
        {
            DataTable dataTable = new DataTable();
            return dataTable;
        }

        public virtual void CreateTable(string tabelName, string columns) 
        {
            
        }

        public virtual void InsertData(string tabelName, List<string> columns, List<string> data)
        {

        }

    }
}