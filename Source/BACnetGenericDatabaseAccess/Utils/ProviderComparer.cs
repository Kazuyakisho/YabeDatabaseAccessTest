using System;
using System.Collections.Generic;
using BACnetGenericDatabaseAccess.Database;

namespace BACnetGenericDatabaseAccess.Utils
{
    public class ProviderComparer : IEqualityComparer<DBProvider>
    {
        public bool Equals(DBProvider x, DBProvider y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (x.Name == y.Name) return true;

            return false;
        }

        public bool Equals(string x, DBProvider y)
        {
            if (x == y.Name) return true;
            return false;
        }

        public int GetHashCode(DBProvider obj)
        {
            if (Object.ReferenceEquals(obj, null)) return 0;

            int hashProviderkeyName = obj.Name == null ? 0 : obj.Name.GetHashCode();
            int hashProviderName = obj.Name == null ? 0 : obj.Name.GetHashCode();
            int hashProviderProvName = obj.ProviderName == null ? 0 : obj.ProviderName.GetHashCode();
            int hashProviderConString = obj.ConnectionsString == null ? 0 : obj.ConnectionsString.GetHashCode();

            return hashProviderConString ^ hashProviderName ^ hashProviderProvName ^ hashProviderkeyName;
        }
    }
}