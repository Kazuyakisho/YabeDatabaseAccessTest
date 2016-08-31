using BACnetGenericDatabaseAccess.Cov.Abstract;
using BACnetGenericDatabaseAccess.Cov.Interface;
using BACnetGenericDatabaseAccess.Database;

namespace BACnetGenericDatabaseAccess.Cov
{

    public class DBSubscriber : DBProviderCovAbstract, IDBCovSubscriber
    {


        public DBSubscriber(DBProvider provider) : base(provider)
        {

        }

        public bool IsValidSubscriber { get; set; }


        public void Update(DBCovDataItem dataItem)
        {
            Prov.Handle.DbAbstractFactoryQueries.CovDataItem = dataItem;
            Prov.Handle.DbAbstractFactoryQueries.InsertCovData();


        }


    }
}
