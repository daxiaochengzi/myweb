using System;
using System.Data.SQLite;

namespace service
{
    public class test
    {
        SQLiteConnection m_dbConnection;
        // 创建一个空的数据库
      public   void createNewDatabase()
        {
            SQLiteConnection.CreateFile("MyDatabase.sqlite"); //123
        }



        //在指定数据库中创建一个table  
        public void createTable()
        {
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite");
            m_dbConnection.Open();
            string sql = "create table highscores (name varchar(20), score int)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        //插入一些数据  
        public void fillTable()
        {
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite");
            m_dbConnection.Open();
            string sql = "insert into highscores (name, score) values ('Me', 3000)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "insert into highscores (name, score) values ('Myself', 6000)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "insert into highscores (name, score) values ('And I', 9001)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        public void printHighscores()
        {
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite");
            m_dbConnection.Open();

            string sql = "select * from highscores order by score desc";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var namedata = reader["name"].ToString();
                // Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);

            }
        }
    }
}
