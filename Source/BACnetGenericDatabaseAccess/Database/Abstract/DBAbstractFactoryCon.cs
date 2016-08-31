namespace BACnetGenericDatabaseAccess.Database.Abstract
{
    public abstract class DBAbstractFactoryCon
    {


        public string ConnectionsString { get; set; }
        public string DatabaseName { get; set; }
        public DBAbstractFactoryQuery DbAbstractFactoryQueries { get; set; }

        #region Abstract Functions

        //Generic for PostgreSQL and other SQL Provider 
        public abstract T CreateConnection<T>();
        public abstract T CreateCommand<T>();
        public abstract T CreateOpenConnection<T>();
        public abstract T CreateDataAdapter<T>();
        public abstract T CreateDataAdapter<T, C>(string commandText, C connection);
        public abstract T CreateDataAdapter<T, K>(K command);
        public abstract T CreateCommand<T, C>(string commandText, C connection);
        public abstract T CreateStoredProcCommand<T, C>(string procName, C connection);
        public abstract T CreateParameter<T>(string parameterName, object parameterValu);
        public abstract void CreateQueries();

        #endregion

    }
}
