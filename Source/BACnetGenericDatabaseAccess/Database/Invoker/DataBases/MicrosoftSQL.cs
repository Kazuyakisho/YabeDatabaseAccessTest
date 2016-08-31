using System.Data;
using System.Data.SqlClient;
using BACnetGenericDatabaseAccess.Database.Abstract;
using BACnetGenericDatabaseAccess.Database.Invoker.DataBases.Queries;

namespace BACnetGenericDatabaseAccess.Database.Invoker.DataBases
{
    public class MicrosoftSQL : DBAbstractFactoryCon
    {


        public override T CreateConnection<T>()
        {

            return (T)(object)new SqlConnection(ConnectionsString);
        }

        public override T CreateCommand<T>()
        {
            return (T)(object)new SqlCommand();
        }

        /// <summary>
        /// T is object of conenction
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public override T CreateOpenConnection<T>()
        {
            var con = CreateConnection<SqlConnection>();
            con.Open();
            return (T)(object)con;
        }

        public override T CreateDataAdapter<T>()
        {
            return (T)(object)new SqlDataAdapter();
        }

        public override T CreateDataAdapter<T, C>(string commandText, C connection)
        {
            SqlCommand command = CreateCommand<SqlCommand>();
            command.CommandText = commandText;
            command.Connection = connection as SqlConnection;


            return (T)(object)new SqlDataAdapter(commandText, command.Connection);
        }

        public override T CreateDataAdapter<T, C>(C command)
        {
            SqlCommand sqlcommand = CreateCommand<SqlCommand>();
            return (T)(object)new SqlDataAdapter(sqlcommand);
        }

        public override T CreateCommand<T, C>(string commandText, C connection)
        {
            SqlCommand command = CreateCommand<SqlCommand>();

            command.CommandText = commandText;
            command.Connection = connection as SqlConnection;
            command.CommandType = CommandType.Text;

            return (T)(object)command;
        }

        public override T CreateStoredProcCommand<T, C>(string procName, C connection)
        {
            SqlCommand command = CreateCommand<SqlCommand>();
            command.CommandText = procName;
            command.Connection = connection as SqlConnection;
            command.CommandType = CommandType.StoredProcedure;

            return (T)(object)command;
        }

        public override T CreateParameter<T>(string parameterName, object parameterValue)
        {
            return (T)(object)new SqlParameter(parameterName, parameterValue);
        }

        public override void CreateQueries()
        {
            DbAbstractFactoryQueries = new MicrosoftSqlDbAbstractFactoryQueries(this);

        }

    }
}
