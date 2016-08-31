using System.Collections.Generic;
using BACnetGenericDatabaseAccess.Cov.Enum;

namespace BACnetGenericDatabaseAccess.Database.Interface
{
    interface IQuery
    {
          List<string> GetDatabases();
          List<string> GetTableNames();
          bool IsDatabase(string databaseName);
          bool IsTable(string tablename);
          bool CreateDatabase(string databaseName);
          bool CreateTable();
          bool InsertCovData();
          T ExecuteCommand<T>(DBQueryEnum enEnum, string Command);

    }
}
