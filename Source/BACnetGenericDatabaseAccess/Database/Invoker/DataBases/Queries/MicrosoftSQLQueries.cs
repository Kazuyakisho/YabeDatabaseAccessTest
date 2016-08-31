using System;
using System.Collections.Generic;
using BACnetGenericDatabaseAccess.Cov.Enum;
using BACnetGenericDatabaseAccess.Database.Abstract;

namespace BACnetGenericDatabaseAccess.Database.Invoker.DataBases.Queries
{
    public class MicrosoftSqlDbAbstractFactoryQueries : DBAbstractFactoryQuery
    {
        public MicrosoftSqlDbAbstractFactoryQueries(DBAbstractFactoryCon man) : base(man)
        {
        }

        public override List<string> GetDatabases()
        {
            throw new NotImplementedException();
        }

        public override List<string> GetTableNames()
        {
            throw new NotImplementedException();
        }

        public override bool IsDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        public override bool IsTable(string tablename)
        {
            throw new NotImplementedException();
        }

        public override bool CreateDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        public override bool CreateTable()
        {
            throw new NotImplementedException();
        }

        public override bool InsertCovData()
        {
            throw new NotImplementedException();
        }

        protected override T ExecuteCommand<T>(DBQueryEnum enEnum, string Command)
        {
            throw new NotImplementedException();
        }
    }
}
