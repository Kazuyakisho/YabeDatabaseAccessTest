namespace BACnetGenericDatabaseAccess.Cov.Interface
{
    //observer
    public interface IDBCovSubscriber
    {

        bool IsValidSubscriber { get; set; }
        void Update(DBCovDataItem dataItem);


    }



}
