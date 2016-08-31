using BACnetGenericDatabaseAccess.Cov;
using BACnetGenericDatabaseAccess.Database;
using BACnetGenericDatabaseAccess.Database.Abstract;
using BACnetGenericDatabaseAccess.Database.Config;
using BACnetGenericDatabaseAccess.Database.Enum;
using BACnetGenericDatabaseAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BACnetGenericDatabaseAccess
{
    public class DBManager
    {



        //Init singelton = Thread Save
        private static readonly Lazy<DBManager> _instance = new Lazy<DBManager>(() => new DBManager());

        /// <summary>
        /// Returns the currently available database providers
        /// </summary>
        public Dictionary<string, DBProvider> DbProviders { get; private set; } = new Dictionary<string, DBProvider>();

        //list of conDataitems
        public Dictionary<string, DBCovDataItem> DbCovDataItems = new Dictionary<string, DBCovDataItem>();

        //list of DB subsriber
        public Dictionary<string, DBSubscriber> DbSubsribers = new Dictionary<string, DBSubscriber>();

        //DateTime
        public DateTimeSettings daysOfWeek;


        //providerconnection handling by configfile
        public DBAbstractConConfig DbProviderConnection;

        //start treadsave manager
        public static DBManager Instance => _instance.Value;


        //current provider
        public DBProvider CurrentProvider { get; private set; } = new DBProvider();

        /// <summary>
        /// Load connection from config file
        /// </summary>
        private DBManager()
        {
            daysOfWeek = new DateTimeSettings();

        }

        public bool LoadConnectionsFromConfigFile()
        {
            DbProviderConnection = new DBProviderConnectionConfigFile();
            DbProviders = DbProviderConnection.Load();

            if (DbProviders.Count == 0)
            {
                return false;
            }
            return true;

        }

        //Try the connection from the current provider
        public bool TryConnection()
        {

            try
            {

                //Covariance for calling method without type
                CurrentProvider.Handle.CreateOpenConnection<object>();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// Set the currentprovider by connectionstring
        /// </summary>
        /// <param name="connectionString"></param>
        public void SetCurrentProviderByConnectionString(string connectionString)
        {
            CurrentProvider.ConnectionsString = connectionString;

        }

        /// <summary>
        /// Set the current provider by attributes
        /// </summary>
        /// <param name="providersourcEnumDb">Provider source - MySql, MicrosoftSQL, PostgreSQL, OleDB, Odbc</param>
        /// <param name="connectionname">Unique connectionname</param>
        /// <param name="host">Host</param>
        /// <param name="port"></param>
        /// <param name="username"></param>
        /// <param name="passwaord"></param>
        public void SetCurrentProviderByAttributes(EnumDB providersourcEnumDb, string connectionname, string host, string port, string username, string passwaord, string databasename = "")
        {
            try
            {
                ushort hostport;
                bool isNumeric = ushort.TryParse(port, out hostport);

                CurrentProvider.ConStringPort = isNumeric ? hostport : Convert.ToUInt16(3306);
                CurrentProvider.Name = connectionname;
                CurrentProvider.EnumDb = providersourcEnumDb;
                CurrentProvider.ConStringServer = host;
                CurrentProvider.ConStringPW = passwaord;
                CurrentProvider.ConStringUserName = username;
                CurrentProvider.ConStringDataBase = databasename;
                CurrentProvider.SetConnectionString();
                CurrentProvider.SetDBConnection();
                CurrentProvider.SetQueries();
                if (CurrentProvider.ProviderName == null) CurrentProvider.SetProviderName();



            }
            catch (Exception)
            {

                throw;
            }




        }

        public bool IsConnectionName(string connectionName)
        {
            return DbProviders.ContainsKey(connectionName);


        }

        public bool SaveCurrentProvider(string databaseName)
        {

            using (DBProvider tempProvider = CurrentProvider)
            {
                tempProvider.ConStringDataBase = databaseName;
                if (!tempProvider.SetConnectionString())
                {
                    
                    return false;
                }

                CurrentProvider = tempProvider;
                
            }
           
            CurrentProvider.SetDB();
            CurrentProvider.SetQueries();
            Add();
            return true;
        }

        /// <summary>
        /// Set the current provider by keyname from dictionary
        /// </summary>
        /// <param name="keyName"></param>
        public void SetCurrentProviderByKeyname(string keyName)
        {
            CurrentProvider = DbProviders.Single(q => q.Key == keyName).Value;


        }

        /// <summary>
        /// Set a new current provider, used for new template
        /// </summary>
        public void SetCurrentProvider()
        {
            CurrentProvider = new DBProvider();

        }

        #region provider handling
        public void Add()
        {
            if (CurrentProvider == null || !CurrentProvider.IsValidWithDatabase())
            {
                return;
            }
            if (DbProviders.ContainsKey(CurrentProvider.Name))
            {
                DbProviders[CurrentProvider.Name] = CurrentProvider;
                DbProviderConnection.Update(CurrentProvider);
                return;
            }
            if (!DbProviders.ContainsKey(CurrentProvider.Name))
            {
                DbProviders.Add(CurrentProvider.Name, CurrentProvider);
                DbProviderConnection.Add(CurrentProvider);
            }

        }


        public void Remove()
        {
            if (CurrentProvider == null)
            {
                return;
            }
            if (DbProviders.ContainsValue(CurrentProvider))
            {
                //if provider is a subscriber remove from subscriber first
                //if (DbSubsribers.ContainsKey(CurrentProvider.Name))
                //    DbSubsribers.Remove(CurrentProvider.Name);

                DbProviders.Remove(CurrentProvider.Name);
                DbProviderConnection.RemoveByKeyName(CurrentProvider);

            }
        }

        public void ClearDicProvider()
        {

            DbProviders.Clear();
        }


        /// <summary>
        /// Update the provider by keyname in dictionoary and config file
        /// </summary>
        /// <param name="keyname">connectionname</param>
        public void UpdateDBProvider(string keyname)
        {
            if (DbProviders.ContainsKey(keyname))
                DbProviders[keyname] = CurrentProvider;
            DbProviderConnection.Update(DbProviders[keyname]);
        }

        #endregion

        public void AddDBSubscriber()
        {
            if (!DbSubsribers.ContainsKey(CurrentProvider.Name))
            {

                CurrentProvider.IsSubsriber = true;
                DbSubsribers.Add(CurrentProvider.Name, new DBSubscriber(CurrentProvider));
            }

        }


        public void RemoveDBSubscriber(string name)
        {

            if (DbSubsribers.ContainsKey(name))
            {
                DbSubsribers[name].Prov.IsSubsriber = false;
                DbSubsribers[name].IsValidSubscriber = false;
                DbSubsribers.Remove(name);
                foreach (var item in DbCovDataItems)
                {
                    if(item.Value.Subscribers.ContainsKey(name))
                    item.Value.Subscribers.Remove(name);
                }
            }
        }

        public void AddCovDataItem(string sub_key, DBCovDataItem covDataItem, string subscriber_Key)
        {
            //if there are no subscribers - return
            if (DbSubsribers.Count == 0) return;

            //if the subscriber is not aivailable return
            if (!DbSubsribers.ContainsKey(subscriber_Key)) return;

            //if the current cov data is not in dictionary then add the item
            if (!DbCovDataItems.ContainsKey(sub_key))
            {
                DbCovDataItems.Add(sub_key, covDataItem);

            }

            if (!DbCovDataItems[sub_key].Subscribers.ContainsKey(subscriber_Key))
            {
                DbCovDataItems[sub_key].AddSubscriber(subscriber_Key, DbSubsribers[subscriber_Key]);

            }

            DbSubsribers[subscriber_Key].IsValidSubscriber = true;
            DbSubsribers[subscriber_Key].Prov.Handle.DbAbstractFactoryQueries.CovDataItem = covDataItem;
            DbSubsribers[subscriber_Key].Prov.Handle.DbAbstractFactoryQueries.CreateTable();


        }

        public bool RemoveDBSubscriberInCovDataItem(string sub_key, string subscriber_Key)
        {
            if (!DbCovDataItems.ContainsKey(sub_key)) return false;
            DbCovDataItems[sub_key].Subscribers[subscriber_Key].IsValidSubscriber = false;
            DbCovDataItems[sub_key].RemoveSubscriber(subscriber_Key);
            return true;

        }

        public bool IsValidSubscriber(string sub_key, string subscriber_key)
        {
            if (DbCovDataItems.Count != 0 &&
                DbCovDataItems.ContainsKey(sub_key) &&
                DbCovDataItems[sub_key].Subscribers.Count != 0 &&
                DbCovDataItems[sub_key].Subscribers.ContainsKey(subscriber_key) &&
                DbCovDataItems[sub_key].Subscribers[subscriber_key].IsValidSubscriber) return true;
            return false;



        }
        public bool RemoveCovDataItem(string sub_key)
        {
            if (!DbCovDataItems.ContainsKey(sub_key))
            {
                foreach (var dbSubscriber in DbSubsribers)
                {
                    dbSubscriber.Value.IsValidSubscriber = false;
                }
                return false;
            }
            if (DbCovDataItems.ContainsKey(sub_key))
            {

                DbCovDataItems.Remove(sub_key);
                return false;
            }

            return true;

        }
    }
}