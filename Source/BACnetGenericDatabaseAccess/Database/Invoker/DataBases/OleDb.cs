using System.Data;
using System.Data.OleDb;
using BACnetGenericDatabaseAccess.Database.Abstract;
using BACnetGenericDatabaseAccess.Database.Invoker.DataBases.Queries;

namespace BACnetGenericDatabaseAccess.Database.Invoker.DataBases
{
    class OleDb : DBAbstractFactoryCon
    {
        public override T CreateConnection<T>()
        {

            return (T)(object)new OleDbConnection(ConnectionsString);
        }

        public override T CreateCommand<T>()
        {
            return (T)(object)new OleDbCommand();
        }

        /// <summary>
        /// T is object of conenction
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public override T CreateOpenConnection<T>()
        {
            var con = CreateConnection<OleDbConnection>();
            con.Open();
            return (T)(object)con;
        }

        public override T CreateDataAdapter<T>()
        {
            return (T)(object)new OleDbDataAdapter();
        }

        public override T CreateDataAdapter<T, C>(string commandText, C connection)
        {
            OleDbCommand command = CreateCommand<OleDbCommand>();
            command.CommandText = commandText;
            command.Connection = connection as OleDbConnection;


            return (T)(object)new OleDbDataAdapter(commandText, command.Connection);
        }

        public override T CreateDataAdapter<T, C>(C command)
        {
            OleDbCommand sqlcommand = CreateCommand<OleDbCommand>();
            return (T)(object)new OleDbDataAdapter(sqlcommand);
        }

        public override T CreateCommand<T, C>(string commandText, C connection)
        {
            OleDbCommand command = CreateCommand<OleDbCommand>();

            command.CommandText = commandText;
            command.Connection = connection as OleDbConnection;
            command.CommandType = CommandType.Text;

            return (T)(object)command;
        }

        public override T CreateStoredProcCommand<T, C>(string procName, C connection)
        {
            OleDbCommand command = CreateCommand<OleDbCommand>();
            command.CommandText = procName;
            command.Connection = connection as OleDbConnection;
            command.CommandType = CommandType.StoredProcedure;

            return (T)(object)command;
        }

        public override T CreateParameter<T>(string parameterName, object parameterValue)
        {
            return (T)(object)new OleDbParameter(parameterName, parameterValue);
        }

        public override void CreateQueries()
        {
            DbAbstractFactoryQueries = new OleDbAbstractFactoryQuery(this);

        }
    }
}
