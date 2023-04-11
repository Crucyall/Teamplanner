using System;
using System.Data.SQLite;

namespace Teamplanner
{
    internal class versionprüfung
    {
        string version_temp;
        string version_aktuell;
        public void version_prüfer(MainWindow test)
        {
            test.dbDownload(AppDomain.CurrentDomain.BaseDirectory + @"plannersavetemp.db");
            SQLiteDataReader reader;
            SQLiteConnection connection = new SQLiteConnection(@"Data Source =plannersavetemp.db");
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);

            command.CommandText = String.Format("SELECT VersionNr FROM Version");

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                test.version_temp = reader.GetString(0);
            }
            reader.Close();
            connection.Close();

            SQLiteDataReader reader2;
            SQLiteConnection connection2 = new SQLiteConnection(@"Data Source = plannersave.db");
            connection2.Open();
            SQLiteCommand command2 = new SQLiteCommand(connection2);

            command2.CommandText = String.Format("SELECT VersionNr FROM Version");
            reader2 = command2.ExecuteReader();

            while (reader2.Read())
            {
                test.version_aktuell = reader2.GetString(0);
            }
            reader2.Close();
            connection2.Close();
        }


    }
}
