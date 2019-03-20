using System;
using System.Data.SQLite;

namespace service
{
    public class test
    {
        SQLiteConnection m_dbConnection;
        // 创建一个空的数据库、
      public   void createNewDatabase()
        {
            SQLiteConnection.CreateFile("MyDatabase"); //123 sqlite
            createTable();
        }



        //在指定数据库中创建一个table  
        public void createTable()
        {
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase");
            m_dbConnection.Open();
            string sql =string.Format(@"CREATE TABLE Img (
             Id varchar(32),
             UserInfoId varchar(32),
             type int,
             Url nvarchar(4000),
             CreateTime datetime,
             Remark nvarchar(4000)
            )") ;
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            string sql2 = string.Format(@"CREATE TABLE UserInfo (
             Id varchar(32),
             UserName nvarchar(100),
             Phone nvarchar(60),
             Address nvarchar(1000),
             CreateTime datetime,
             MakeRoomTime nvarchar(60),
             SellingPoint nvarchar(100),
             RoomNumber nvarchar(50),
             Price nvarchar(100),
             AllPrice nvarchar(100),
             Areas nvarchar(100),
             Apartment nvarchar(100),
             Remark nvarchar(4000)
            )");
            SQLiteCommand commandc = new SQLiteCommand(sql2, m_dbConnection);
            commandc.ExecuteNonQuery();
            m_dbConnection.Close();
        }
        public void createTables()
        {
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase");
            m_dbConnection.Open();

        
            string sql2 = string.Format(@"CREATE TABLE UserInfo (
             Id varchar(32),
             UserName nvarchar(100),
             Phone nvarchar(60),
             Address nvarchar(1000),
             CreateTime datetime,
             MakeRoomTime nvarchar(60),
             SellingPoint nvarchar(100),
             RoomNumber nvarchar(50),
             Price nvarchar(100),
             AllPrice nvarchar(100),
             Areas nvarchar(100),
             Apartment nvarchar(100),
             Remark nvarchar(4000)
            )");
            SQLiteCommand commandc = new SQLiteCommand(sql2, m_dbConnection);
            commandc.ExecuteNonQuery();
            m_dbConnection.Close();
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
