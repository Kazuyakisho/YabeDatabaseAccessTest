using System.Configuration;

namespace BACnetGenericDatabaseAccess.Database.Config.ConfigFileAccess
{
    public class DBCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new DBElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DBElement)element).Name;
        }

        public DBElement this[int index]
        {
            get { return (DBElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null) BaseRemove(index);
                BaseAdd(index, value);
            }
        }

        public void Add(DBElement addDb)
        {
            BaseAdd(addDb);


        }

        public void Clear()
        {
            BaseClear();
        }

        public void Remove(DBElement db)
        {
            BaseRemove(db);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void RemoveByKeyName(string name)
        {
            BaseRemove(name);
        }

        public void Update(string name, DBElement element)
        {
            RemoveByKeyName(name);
            Add(element);
        }
    }

}