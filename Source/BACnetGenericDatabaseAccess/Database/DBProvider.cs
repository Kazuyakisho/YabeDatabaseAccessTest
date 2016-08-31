using BACnetGenericDatabaseAccess.Database.Abstract;
using BACnetGenericDatabaseAccess.Database.Enum;
using BACnetGenericDatabaseAccess.Database.Invoker;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using System;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace BACnetGenericDatabaseAccess.Database
{
    [TestFixture]
    public class DBProvider : IDisposable

    {


        private string _pathClassInvoke = "BACnetGenericDatabaseAccess.Database.Invoker.DataBases.";


        private EnumDB _enumDB;

        /// <summary>
        /// Providers - MySQL, Odbc, OleDb, MicrosoftSql, PostrgreSQL
        /// </summary>
        public EnumDB EnumDb
        {
            get { return _enumDB; }
            set
            {
                //for invoking class
                _enumDB = value;
                ClassName = _pathClassInvoke + value;

                ConnectionType = Type.GetType(ClassName);




            }
        }

        /// <summary>
        /// Type for use connection initialization and invoking class
        /// </summary>
        /// 
        public Type ConnectionType { get; set; }

        /// <summary>
        /// Is the currentprovider a subscriber for the subscriberlist
        /// </summary>
        public bool IsSubsriber { get; set; } = false;


        /// <summary>
        /// Database connection String to open connection
        /// </summary>
        public string ConnectionsString { get; set; } = string.Empty;

        /// Is used for Form Layout
        /// <summary>
        /// The splitted connectionstring - SERVER
        /// </summary>
        public string ConStringServer { get; set; } = "Server Name";

        /// <summary>
        /// The splitted connectionstring - PW
        /// </summary>
        public string ConStringPW { get; set; } = "Password";

        private string _conStringDatabase = "Choose your database";
        /// <summary>
        /// The splitted connectionstring - DB Name
        /// </summary>
        public string ConStringDataBase
        {
            get { return _conStringDatabase; }
            set
            {
                _conStringDatabase = value;
                if (Handle != null) Handle.DatabaseName = value;

            }
        }

        /// <summary>
        /// The splitted connectionstring - Port
        /// </summary>
        public uint ConStringPort { get; set; } = 0;

        /// <summary>
        /// The splitted string other Attributes
        /// </summary>
        public string ConStringAddAtributes { get; set; } = "";

        /// <summary>
        /// The splitted connectionstring - Username
        /// </summary>
        public string ConStringUserName { get; set; } = "User Id";

        /// <summary>
        /// The name of the connection Name
        /// </summary>
        public string Name { get; set; } = "Name your connection";

        /// <summary>
        /// The Name of Assembly + SQL Modul - doesn't used now
        /// </summary>
        public string ProviderName { get; set; }

        private string _classname;

        /// <summary>
        /// Unique Classname for invoking class via connectiontype
        /// </summary>
        public string ClassName
        {
            get { return _classname; }
            set
            {
                _classname = value;
                ConnectionType = Type.GetType(ClassName);
            }
        }


        /// <summary>
        /// Checked if a new instance of provider is valid 
        /// </summary>
        public bool IsValidWithDatabase()
        {
            if (!(ConnectionsString == "" || Name == "" || ClassName == "" || ProviderName == "" || ConStringDataBase == ""))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Used for creating database and queries
        /// </summary>
        public DBAbstractFactoryCon Handle { get; set; }

        /// <summary>
        /// Creting Queries in Handle
        /// </summary>
        public void SetQueries()
        {
            if (Handle != null)
                Handle.CreateQueries();


        }

        public void SetDB()
        {
            if (Handle != null)
                Handle.DatabaseName = ConStringDataBase;


        }

        /// <summary>
        /// Create DB in Handle and set DatabaseName
        /// </summary>
        public void SetDBConnection()
        {
            if (ConnectionType != null)
            {
                Handle = Handle.CreateDB(ConnectionType, ConnectionsString);

            }

        }

        [Test]
        /// <summary>
        /// Try to set connection attributes from connectionstring
        /// </summary>
        public void SetAttributes()
        {

            switch (EnumDb)
            {
                case EnumDB.MySql:
                    try
                    {

                        MySqlConnectionStringBuilder mySqlConnectionStringBuilder = new MySqlConnectionStringBuilder();
                        mySqlConnectionStringBuilder.ConnectionString = ConnectionsString;


                        ConStringServer = mySqlConnectionStringBuilder.Server;
                        ConStringPort = mySqlConnectionStringBuilder.Port;
                        ConStringDataBase = mySqlConnectionStringBuilder.Database;
                        ConStringUserName = mySqlConnectionStringBuilder.UserID;
                        ConStringPW = mySqlConnectionStringBuilder.Password;

                    }
                    catch (Exception exc)
                    {


                    }
                    break;

                case EnumDB.MicrosoftSql:
                    try
                    {
                        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
                        sqlConnectionStringBuilder.ConnectionString = ConnectionsString;

                        ConStringServer = sqlConnectionStringBuilder.DataSource;
                        ConStringPort = 0;
                        ConStringDataBase = sqlConnectionStringBuilder.InitialCatalog;
                        ConStringUserName = sqlConnectionStringBuilder.UserID;
                        ConStringPW = sqlConnectionStringBuilder.Password;

                    }
                    catch (Exception exc)
                    {


                    }
                    break;

                case EnumDB.OdeBc:
                    try
                    {
                        OdbcConnectionStringBuilder odbcConnectionStringBuilder = new OdbcConnectionStringBuilder();
                        odbcConnectionStringBuilder.ConnectionString = ConnectionsString;

                        ConStringServer = odbcConnectionStringBuilder.Driver;
                        ConStringPort = 0;
                        ConStringDataBase = odbcConnectionStringBuilder.Dsn;
                        ConStringUserName = "";
                        ConStringPW = "";

                    }
                    catch (Exception exc)
                    {


                    }
                    break;




            }
        }

        /// <summary>
        /// Set the provider name if doesn't exist
        /// </summary>
        public void SetProviderName()
        {
            switch (EnumDb)
            {
                case EnumDB.MySql:
                    ProviderName = "MySql.Data.MySqlClient";
                    break;
                case EnumDB.PostgreSql:
                    ProviderName = "Npgsql";
                    break;
                default:
                    ProviderName = "System.Data";
                    break;

            }
        }

        /// <summary>
        /// Set the connection string by using attributes from the databaseconnectionform
        /// </summary>
        public bool SetConnectionString()
        {

            try
            {
                switch (EnumDb)
                {

                    case EnumDB.MySql:
                        MySqlConnectionStringBuilder mySqlConnectionStringBuilder = new MySqlConnectionStringBuilder();
                        mySqlConnectionStringBuilder.Server = ConStringServer;
                        mySqlConnectionStringBuilder.Port = ConStringPort;
                        if (ConStringDataBase != "" || ConStringDataBase != "Choose your database")
                            mySqlConnectionStringBuilder.Database = ConStringDataBase;
                        mySqlConnectionStringBuilder.UserID = ConStringUserName;
                        mySqlConnectionStringBuilder.Password = ConStringPW;

                        ConnectionsString = mySqlConnectionStringBuilder.GetConnectionString(true);

                        if (IsValidWithDatabase())
                        {
                            Handle.ConnectionsString = ConnectionsString;

                            return true;
                        }

                        return false;




                    case EnumDB.MicrosoftSql:
                        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
                        sqlConnectionStringBuilder.DataSource = ConStringServer;
                        sqlConnectionStringBuilder.Password = ConStringPW;
                        sqlConnectionStringBuilder.InitialCatalog = ConStringDataBase;
                        sqlConnectionStringBuilder.UserID = ConStringUserName;

                        return true;


                }
            }
            catch (Exception)
            {

                return false;
            }

            return false;

        }


        ~DBProvider()
        {
            Dispose();
        }
        public void Dispose()
        {

            GC.SuppressFinalize(this);

        }
    }
}
