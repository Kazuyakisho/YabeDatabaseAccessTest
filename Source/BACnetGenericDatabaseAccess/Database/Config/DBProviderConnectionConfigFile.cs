using BACnetGenericDatabaseAccess.ConfigDataProtection;
using BACnetGenericDatabaseAccess.ConfigDataProtection.Abstracts;
using BACnetGenericDatabaseAccess.Database.Abstract;
using BACnetGenericDatabaseAccess.Database.Config.ConfigFileAccess;
using BACnetGenericDatabaseAccess.Database.Enum;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace BACnetGenericDatabaseAccess.Database.Config
{
    class DBProviderConnectionConfigFile : DBAbstractConConfig
    {
        private ExeConfigurationFileMap configMap;
        private Configuration config;
        private AProtectData protectData = new AProtectDataAes();

        public DBProviderConnectionConfigFile()
        {

            configMap = new ExeConfigurationFileMap();
        }


        public override Dictionary<string, DBProvider> Load()
        {

            Dictionary<string, DBProvider> dic = new Dictionary<string, DBProvider>();
            configMap.ExeConfigFilename = Environment.CurrentDirectory + @"\DBManager.config";

            config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

            var section = config.GetSection(DBSection.SectionName) as DBSection;

            if (section != null)
            {
                foreach (DBElement c in section.Db)
                {
                    bool isSubscriber;

                    DBProvider prov = new DBProvider
                    {

                        Name = c.Name,
                        ProviderName = c.ProviderName,
                        ConnectionType = Type.GetType(c.DatabaseClassName),
                        EnumDb = (EnumDB)System.Enum.Parse(typeof(EnumDB), c.DatabaseClassName, true),




                    };

                    prov.ConnectionsString = protectData.GetProtectionString(c.ConnectionString);

                    //try parse is subscriber
                    prov.IsSubsriber = (bool.TryParse(c.IsSubscriber, out isSubscriber)) && isSubscriber;

                    prov.SetAttributes();
                    prov.SetDBConnection();
                    prov.SetDB();
                    prov.SetQueries();
                    dic.Add(prov.Name, prov);
                }
            }

            return dic;
        }

        public override void Add(DBProvider prov)
        {
            config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            var section = config.GetSection(DBSection.SectionName) as DBSection;



            //if it is false add the new provider to config, if it is true update the config file
            if (section != null)
            {

                //protect string 
                prov.ConnectionsString = protectData.SetProtectionString(prov.ConnectionsString);

                //add to config file 
                section.Db.Add(new DBElement(prov));


            }


            //save the modifications to configfile
            config.Save(ConfigurationSaveMode.Modified);

            //refresh the connectionsstringsection
            ConfigurationManager.RefreshSection(DBSection.DatabaseServerConnectionsCollectionName);
        }

        public override void RemoveByKeyName(DBProvider prov)
        {
            config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            var section = config.GetSection(DBSection.SectionName) as DBSection;

            //if it is false add the new provider to config, if it is true update the config file
            if (section != null)
            {
                //remove the connectionstrin in configfile
                section.Db.RemoveByKeyName(prov.Name);


            }


            //save the modifications to configfile
            config.Save(ConfigurationSaveMode.Modified);

            //refresh the connectionsstringsection
            ConfigurationManager.RefreshSection(DBSection.DatabaseServerConnectionsCollectionName);
        }

        public override void Update(DBProvider prov)
        {
            config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            var section = config.GetSection(DBSection.SectionName) as DBSection;

            //protect connection string
            prov.ConnectionsString = protectData.SetProtectionString(prov.ConnectionsString);

            //update the config file
            section.Db.Update(prov.Name, new DBElement(prov));

            //save the modifications to configfile
            config.Save(ConfigurationSaveMode.Modified);


            ConfigurationManager.RefreshSection(DBSection.DatabaseServerConnectionsCollectionName);

        }




    }
}
