using System;
using System.Configuration;
using System.Data.SqlClient;

namespace _02
{
    public class User
    {
        private readonly UserId id;
        private UserName name;

        public User(UserName name)
        {
            string seqId;
            // データべースの接続設定からコネクションを作成して
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                // 採番テーブルを利用し採番処理を行っている
                command.CommandText = "SELECT seq = (NEXT VALUE FOR UserSeq)";
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var rawSeqId = reader["seq"];
                        seqId = rawSeqId.ToString();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
        }

        public User(UserId id, UserName name)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (name == null) throw new ArgumentNullException(nameof(name));

            this.id = id;
            this.name = name;
        }

        public void ChangeName(UserName name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            this.name = name;
        }
    }
}
