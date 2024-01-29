using CLI_Casus_Blok_5;
using static CLI_Casus_Blok_5.SQLConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI_Casus_Blok_5
{
    internal class DataReciever
    {
        
        static void Main()
        {
        
            DBConnectie sqliteConnection = new DBConnectie(connectionString);
            sqliteConnection.Open();

            sqliteConnection.CreateTable("Test", "ID INTEGER PRIMARY KEY, Name TEXT, Age INTEGER");

            List<string> columns = new List<string> { "Name", "Age" };
            List<string> data = new List<string> { "John", "25" };
            sqliteConnection.InsertData("Test", columns, data);

            sqliteConnection.Close();

            SQLConnection sqlConnection = new SQLConnection(connectionString);
            sqlConnection.Open();

            List<string> sqlColumns = new List<string> { "Name", "Age" };
            List<string> sqlData = new List<string> { "Tim", "30" };
            sqlConnection.InsertData("TestTable", sqlColumns, sqlData);

            sqlConnection.Close();
        
        }
    }
}
