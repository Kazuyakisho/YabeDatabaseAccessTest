using BACnetGenericDatabaseAccess.Database;
using NUnit.Framework;

namespace BACnetGenericDatabaseAccess.Cov.Abstract
{

    public abstract class DBProviderCovAbstract
    {
        private DBProvider CurrentProvider = new DBProvider();


        protected DBProviderCovAbstract(DBProvider provider)
        {
            CurrentProvider = provider;

        }


        public DBProvider Prov => CurrentProvider;


    }
}
