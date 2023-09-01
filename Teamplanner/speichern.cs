using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Windows.Documents;

namespace Teamplanner
{
    internal class speichern
    {
        List<Spieler> speichers = new();
        List<Spielec> speichersc = new();
        List<Spielerstats> speicherstats = new();
        public void indbspeichernplayer(List<Spieler> spieler)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source = plannersave.db");
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);

            foreach (Spieler item in spieler)
            {
                command.CommandText = String.Format("REPLACE into Spieler(ID,Name,Spielerrolle,Teamrolle,Team) values ('{0}','{1}','{2}','{3}','{4}')", item.index, item.Name, item.Spielerrolle, item.TeamRolle, item.team);
                command.ExecuteNonQuery();
            }

            connection.Close();

        }

        public List<Spieler> dbladenplayer()
        {
            speichers = new();
            SQLiteDataReader reader;
            bool checkBox = false;
            SQLiteConnection connection = new SQLiteConnection("Data Source = plannersave.db");
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);

            command.CommandText = String.Format("SELECT * FROM Spieler");

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                speichers.Add(new Spieler() { Name = reader["name"].ToString(), Spielerrolle = reader["Spielerrolle"].ToString(), TeamRolle = reader["Teamrolle"].ToString(), index = Convert.ToInt32(reader["ID"].ToString()), check = checkBox, team = reader["Team"].ToString() });

            }
            reader.Close();
            connection.Close();

            return speichers;
        }

        public void indbspeichernspiele(ObservableCollection<Spielec> spieler)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source = plannersave.db");
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);

            foreach (Spielec item in spieler)
            {
                command.CommandText = String.Format("REPLACE into Spiele(ID,Team1,Score1,Score2,Team2,Players,Map) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", item.index, item.Team1, item.Score1, item.Score2, item.Team2, item.players, item.map);
                command.ExecuteNonQuery();
            }

            connection.Close();

        }

        public List<Spielec> dbladenspiele()
        {
            speichersc = new();
            SQLiteDataReader reader;

            SQLiteConnection connection = new SQLiteConnection("Data Source = plannersave.db");
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);

            command.CommandText = String.Format("SELECT * FROM Spiele");

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                speichersc.Add(new Spielec()
                {
                    Team1 = reader["Team1"].ToString(),
                    Score1 = Convert.ToInt32(reader["Score1"].ToString()),
                    Score2 = Convert.ToInt32(reader["Score2"].ToString()),
                    Team2 = reader["Team2"].ToString(),
                    players = reader["Players"].ToString(),
                    map = reader["Map"].ToString(),
                    index = Convert.ToInt32(reader["ID"].ToString()),
                    check = false
                });

            }
            reader.Close();
            connection.Close();

            return speichersc;
        }
        public void indbspeichernspielerstats(ObservableCollection<Spielerstats> spielerstats)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source = plannersave.db");
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);

            foreach (Spielerstats item in spielerstats)
            {
                command.CommandText = String.Format("REPLACE into SpielerStats(ID,Name,Kills,Death,Entry,KPR,Map,Rounds) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", item.matchid, item.name, item.kills, item.deaths, item.entry, item.kpr, item.map, item.rounds);
                command.ExecuteNonQuery();
            }

            connection.Close();

        }

        public List<Spielerstats> dbladenspielerstats()
        {
            speicherstats = new();
            SQLiteDataReader reader;

            SQLiteConnection connection = new SQLiteConnection("Data Source = plannersave.db");
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);

            command.CommandText = String.Format("SELECT * FROM SpielerStats");

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                speicherstats.Add(new Spielerstats()
                {
                    name = reader["Name"].ToString(),
                    kills = Convert.ToInt32(reader["Kills"].ToString()),
                    deaths = Convert.ToInt32(reader["Death"].ToString()),
                    entry = reader["Entry"].ToString(),
                    kpr = Convert.ToDouble(reader["KPR"].ToString()),
                    map = reader["Map"].ToString(),
                    rounds = Convert.ToInt32(reader["Rounds"].ToString()),
                    matchid = Convert.ToInt32(reader["ID"].ToString())
                });

            }
            reader.Close();
            connection.Close();

            return speicherstats;
        }


        public void indblöschennplayer(Spieler spieler)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source = plannersave.db");
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);


            command.CommandText = String.Format("DELETE from Spieler Where ID =" + spieler.index);
            command.ExecuteNonQuery();


            connection.Close();

        }

        public void indblöschenspiele(Spielec spieler)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source = plannersave.db");
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);


            command.CommandText = String.Format("DELETE from SpielerStats Where ID =" + spieler.index);
            command.ExecuteNonQuery();
            command.CommandText = String.Format("DELETE from Spiele Where ID =" + spieler.index);
            command.ExecuteNonQuery();


            connection.Close();

        }
        public void indbspeichernteams(Team team)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source = plannersave.db");
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);


            command.CommandText = String.Format("REPLACE into Teams( ID,Name,Besitzer,Spieleranzahl) values ({0},'{1}','{2}','{3}')",team.id,team.Name,team.Owner,team.membercount);
            command.ExecuteNonQuery();


            connection.Close();

        }
        public List<Team> teamladen()
        {
            Team team = new Team();
            List<Team> twsat= new List<Team>();
            SQLiteDataReader reader;

            SQLiteConnection connection = new SQLiteConnection("Data Source = plannersave.db");
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);

            command.CommandText = String.Format("SELECT * FROM Teams");

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                twsat.Add(team = new Team()
                {
                    id =Convert.ToInt32( reader["ID"].ToString()),
                    Name = reader["Name"].ToString(),
                    Owner = reader["Besitzer"].ToString(),
                    membercount = Convert.ToInt32(reader["Spieleranzahl"].ToString()),
                });

            }
            reader.Close();
            connection.Close();
            return twsat;

        }


    }
}
