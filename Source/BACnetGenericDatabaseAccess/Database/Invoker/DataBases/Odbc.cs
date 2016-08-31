using System.Data;
using System.Data.Odbc;
using BACnetGenericDatabaseAccess.Database.Abstract;
using BACnetGenericDatabaseAccess.Database.Invoker.DataBases.Queries;

namespace BACnetGenericDatabaseAccess.Database.Invoker.DataBases
{
    public class Odbc : DBAbstractFactoryCon
    {
        public override T CreateConnection<T>()
        {

            return (T)(object)new OdbcConnection(ConnectionsString);
        }

        public override T CreateCommand<T>()
        {
            return (T)(object)new OdbcCommand();
        }

        /// <summary>
        /// T is object of conenction
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public override T CreateOpenConnection<T>()
        {
            var con = CreateConnection<OdbcConnection>();
            con.Open();
            return (T)(object)con;
        }

        public override T CreateDataAdapter<T>()
        {
            return (T)(object)new OdbcDataAdapter();
        }

        public override T CreateDataAdapter<T, C>(string commandText, C connection)
        {
            OdbcCommand command = CreateCommand<OdbcCommand>();
            command.CommandText = commandText;
            command.Connection = connection as OdbcConnection;


            return (T)(object)new OdbcDataAdapter(commandText, command.Connection);
        }

        public override T CreateDataAdapter<T, C>(C command)
        {
            OdbcCommand sqlcommand = CreateCommand<OdbcCommand>();
            return (T)(object)new OdbcDataAdapter(sqlcommand);
        }

        public override T CreateCommand<T, C>(string commandText, C connection)
        {
            OdbcCommand command = CreateCommand<OdbcCommand>();

            command.CommandText = commandText;
            command.Connection = connection as OdbcConnection;
            command.CommandType = CommandType.Text;

            return (T)(object)command;
        }

        public override T CreateStoredProcCommand<T, C>(string procName, C connection)
        {
            OdbcCommand command = CreateCommand<OdbcCommand>();
            command.CommandText = procName;
            command.Connection = connection as OdbcConnection;
            command.CommandType = CommandType.StoredProcedure;

            return (T)(object)command;
        }

        public override T CreateParameter<T>(string parameterName, object parameterValue)
        {
            return (T)(object)new OdbcParameter(parameterName, parameterValue);
        }

        public override void CreateQueries()
        {
            DbAbstractFactoryQueries = new OdbcDbAbstractFactoryQueries(this);

        }
    }
}
