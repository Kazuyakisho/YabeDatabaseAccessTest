using System.Data;
using BACnetGenericDatabaseAccess.Database.Abstract;
using BACnetGenericDatabaseAccess.Database.Invoker.DataBases.Queries;
using MySql.Data.MySqlClient;

namespace BACnetGenericDatabaseAccess.Database.Invoker.DataBases
{
    public class MySql : DBAbstractFactoryCon
    {


        public override T CreateConnection<T>()
        {

            return (T)(object)new MySqlConnection(ConnectionsString);
        }

        public override T CreateCommand<T>()
        {
            return (T)(object)new MySqlCommand();
        }

        public override T CreateOpenConnection<T>()
        {
            var con = CreateConnection<MySqlConnection>();
            con.Open();
            return (T)(object)con;
        }

        public override T CreateDataAdapter<T>()
        {
            return (T)(object)new MySqlDataAdapter();
        }

        public override T CreateDataAdapter<T, C>(string commandText, C connection)
        {
            MySqlCommand command = CreateCommand<MySqlCommand>();
            command.CommandText = commandText;
            command.Connection = connection as MySqlConnection;


            return (T)(object)new MySqlDataAdapter(commandText, command.Connection);
        }

        public override T CreateDataAdapter<T, C>(C command)
        {
            MySqlCommand sqlcommand = CreateCommand<MySqlCommand>();
            return (T)(object)new MySqlDataAdapter(sqlcommand);
        }

        public override T CreateCommand<T, C>(string commandText, C connection)
        {
            MySqlCommand command = CreateCommand<MySqlCommand>();

            command.CommandText = commandText;
            command.Connection = connection as MySqlConnection;
            command.CommandType = CommandType.Text;

            return (T)(object)command;
        }

        public override T CreateStoredProcCommand<T, C>(string procName, C connection)
        {
            MySqlCommand command = CreateCommand<MySqlCommand>();
            command.CommandText = procName;
            command.Connection = connection as MySqlConnection;
            command.CommandType = CommandType.StoredProcedure;

            return (T)(object)command;
        }

        public override T CreateParameter<T>(string parameterName, object parameterValue)
        {
            return (T)(object)new MySqlParameter(parameterName, parameterValue);
        }

        public override void CreateQueries()
        {
            DbAbstractFactoryQueries = new MySqlDbAbstractFactoryQueries(this);

        }


    }
}
