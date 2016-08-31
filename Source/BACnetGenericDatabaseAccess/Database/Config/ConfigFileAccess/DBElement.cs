using System.Configuration;

namespace BACnetGenericDatabaseAccess.Database.Config.ConfigFileAccess
{

    public class DBElement : ConfigurationElement
    {
        public DBElement()
        {

        }


        public DBElement(DBProvider prov)
        {
            Name = prov.Name;
            ProviderName = prov.ProviderName;
            DatabaseClassName = prov.EnumDb.ToString();
            ConnectionString = prov.ConnectionsString;
        }


        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("providerName", IsRequired = true)]
        public string ProviderName
        {
            get { return (string)this["providerName"]; }
            set { this["providerName"] = value; }
        }

        [ConfigurationProperty("connectionString", IsRequired = true)]
        public string ConnectionString
        {
            get { return (string)this["connectionString"]; }
            set { this["connectionString"] = value; }
        }

        [ConfigurationProperty("databaseClassName", IsRequired = true)]
        public string DatabaseClassName
        {
            get { return (string)this["databaseClassName"]; }
            set { this["databaseClassName"] = value; }
        }

        [ConfigurationProperty("isSubscriber", IsRequired = true)]
        public string IsSubscriber
        {
            get { return (string)this["isSubscriber"]; }
            set { this["isSubscriber"] = value; }
        }




    }
}
