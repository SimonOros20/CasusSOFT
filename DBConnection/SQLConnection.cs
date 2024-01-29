using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace CLI_Casus_Blok_5
{
    class SQLConnection : DBConnectie
    {
        private SQLConnection sqlConnection;
        private List<string> dataFailures;


        public SQLConnection(string connectionString) : base()
        {
            this.sqlConnection = new SQLConnection(connectionString);
            this.dataFailures = new List<string>();
        }

        public override void Open()
        {
            try
            {
                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public override void Close()
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public override void CreateTable(string tableName, string columns)
        {
            try
            {
                using (SQLiteCommand command = new($"CREATE TABLE IF NOT EXISTS {tableName} ({columns})"))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public override DataTable ReadData(string tableName)
        {
            DataTable dataTable = new ();
            try
            {
                using (SQLiteCommand sqlite_cmd = new ($"SELECT * FROM {tableName}"))
                {
                    using (SQLiteDataReader sqliteDataReader = sqlite_cmd.ExecuteReader())
                    {
                        dataTable.Load(sqliteDataReader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return dataTable;
        }

        public override void InsertData(string tableName, List<string> columns, List<string> data)
        {
            try
            {
                string columnNames = string.Join(", ", columns);

                using (SQLiteCommand command = new ($"CREATE TABLE IF NOT EXISTS {tableName} ({columns})"))
                {
                    command.ExecuteNonQuery();
                }
                try
                {
                    string parameterNames = string.Join(", ", columns.Select(c => "@" + c));

                    using (SQLiteCommand sqlite_cmd = new ())
                    {
                        sqlite_cmd.CommandText = $"INSERT INTO {tableName} ({columnNames}) VALUES ({parameterNames})";

                        for (int i = 0; i < columns.Count; i++)
                        {
                            sqlite_cmd.Parameters.AddWithValue("@" + columns[i], data[i]);
                        }

                        sqlite_cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void DataFailure(string tableName, string columns)
        {
            string faultLine = tableName + ": " + columns;
            dataFailures.Add(faultLine);
        }



    }


}