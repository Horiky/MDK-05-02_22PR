using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace WebApplication1.Data.Common
{
    public class Conection
    {
        readonly static string ConnectionData = "server=127.0.0.1;port=3306;database=23pr;uid=root;pwd=;";
        public static MySqlConnection MySql0pen()
        {
            MySqlConnection NewMySqlConnection = new MySqlConnection(ConnectionData);
            NewMySqlConnection.Open();
            return NewMySqlConnection;
        }

        public static MySqlDataReader MySqlQuery(string Query, MySqlConnection Connection)
        {
            MySqlCommand NewMySqlCommand = new MySqlCommand(Query, Connection);
            return NewMySqlCommand.ExecuteReader();
        }

        public static void MySqlClose(MySqlConnection connection)
        {
            connection.Close();
        }
    }
}
