using System.Collections.Generic;

namespace BACnetGenericDatabaseAccess.Database.Abstract
{
    public abstract class DBAbstractConConfig
    {

        public abstract Dictionary<string, DBProvider> Load();
        public abstract void Add(DBProvider prov);
        public abstract void RemoveByKeyName(DBProvider prov);
        public abstract void Update(DBProvider prov);





    }
}
