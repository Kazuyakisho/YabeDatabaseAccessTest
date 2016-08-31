using System.Data;
using BACnetGenericDatabaseAccess.Database.Abstract;
using BACnetGenericDatabaseAccess.Database.Invoker.DataBases.Queries;
using Npgsql;

namespace BACnetGenericDatabaseAccess.Database.Invoker.DataBases
{
    public class PostgreSql : DBAbstractFactoryCon
    {
        public override T CreateConnection<T>()
        {
            return (T)(object)new NpgsqlConnection(ConnectionsString);
        }

        public override T CreateCommand<T>()
        {
            return (T)(object)new NpgsqlCommand();
        }

        public override T CreateOpenConnection<T>()
        {
            var con = CreateConnection<NpgsqlConnection>();
            con.Open();
            return (T)(object)con;
        }

        public override T CreateDataAdapter<T>()
        {
            return (T)(object)new NpgsqlDataAdapter();
        }

        public override T CreateDataAdapter<T, C>(string commandText, C connection)
        {
            NpgsqlCommand command = CreateCommand<NpgsqlCommand>();
            command.CommandText = commandText;
            command.Connection = connection as NpgsqlConnection;

            return (T)(object)new NpgsqlDataAdapter(commandText, command.Connection);
        }

        public override T CreateDataAdapter<T, K>(K command)
        {
            NpgsqlCommand sqlcommand = CreateCommand<NpgsqlCommand>();
            return (T)(object)new NpgsqlDataAdapter(sqlcommand);
        }

        public override T CreateCommand<T, C>(string commandText, C connection)
        {
            NpgsqlCommand command = CreateCommand<NpgsqlCommand>();

            command.CommandText = commandText;
            command.Connection = connection as NpgsqlConnection;
            command.CommandType = CommandType.Text;

            return (T)(object)command;
        }

        public override T CreateStoredProcCommand<T, C>(string procName, C connection)
        {
            NpgsqlCommand command = CreateCommand<NpgsqlCommand>();
            command.CommandText = procName;
            command.Connection = connection as NpgsqlConnection;
            command.CommandType = CommandType.StoredProcedure;

            return (T)(object)command;
        }

        public override T CreateParameter<T>(string parameterName, object parameterValu)
        {
            return (T)(object)new NpgsqlParameter(parameterName, parameterValu);
        }

        public override void CreateQueries()
        {
            DbAbstractFactoryQueries = new PostgreSqlDbAbstractFactoryQueries(this);
        }
    }
}
