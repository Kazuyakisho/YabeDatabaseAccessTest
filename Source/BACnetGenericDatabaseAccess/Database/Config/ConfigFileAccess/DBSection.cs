using System.Configuration;

namespace BACnetGenericDatabaseAccess.Database.Config.ConfigFileAccess
{
    public class DBSection : ConfigurationSection
    {
        /// <summary>
        /// the name of the section group in config file
        /// </summary>
        public const string SectionName = "DBProviderSection";

        /// <summary>
        /// the name of the section in config file
        /// </summary>
        public const string DatabaseServerConnectionsCollectionName = "DatabaseConnectionsStrings";


        [ConfigurationProperty(DatabaseServerConnectionsCollectionName, IsDefaultCollection = false, Options = ConfigurationPropertyOptions.IsAssemblyStringTransformationRequired)]
        [ConfigurationCollection(typeof(DBCollection), RemoveItemName = "remove", AddItemName = "add", ClearItemsName = "clear")]
        public DBCollection Db
        {
            get
            {

                return (DBCollection)base[DatabaseServerConnectionsCollectionName];
            }

        }

    }


}
