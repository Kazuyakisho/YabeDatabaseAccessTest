namespace BACnetGenericDatabaseAccess.Database.Interface
{
    public interface IDbConnectionStringBuilder
    {
        T GetConnectionStringBuilder<T>();

    }
}
