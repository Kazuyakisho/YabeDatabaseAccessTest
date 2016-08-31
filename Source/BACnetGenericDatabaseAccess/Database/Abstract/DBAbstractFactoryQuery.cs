using BACnetGenericDatabaseAccess.Cov.Enum;
using BACnetGenericDatabaseAccess.Cov.Interface;
using System;
using System.Collections.Generic;

namespace BACnetGenericDatabaseAccess.Database.Abstract
{
    public abstract class DBAbstractFactoryQuery
    {
        public string ErrorMessage { get; set; }
        public Exception ex { get; set; }
        public IDBCovDataItem CovDataItem { get; set; }

        protected DBAbstractFactoryCon ConMan;

        protected DBAbstractFactoryQuery(DBAbstractFactoryCon man)
        {
            ConMan = man;
        }

        protected string Command;

        public abstract List<string> GetDatabases();
        public abstract List<string> GetTableNames();
        public abstract bool IsDatabase(string databaseName);
        public abstract bool IsTable(string tablename);
        public abstract bool CreateDatabase(string databaseName);
        public abstract bool CreateTable();
        public abstract bool InsertCovData();
        protected abstract T ExecuteCommand<T>(DBQueryEnum enEnum, string Command);

    }
}
