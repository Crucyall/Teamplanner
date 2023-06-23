using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace Teamplanner
{
    class dbupdate
    {

        public void update(MainWindow mainWindow) 
        {
            SQLiteDataReader reader;
            SQLiteConnection connection = new SQLiteConnection(@"Data Source =plannersave.db");
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = String.Format("ATTACH DATABBASE plannersavetemp.db AS Update");
            reader = command.ExecuteReader();

            SQLiteDataReader reader2;
            SQLiteConnection connection2 = new SQLiteConnection(@"Data Source = plannersavetemp.db");
        

        }
    }
}
