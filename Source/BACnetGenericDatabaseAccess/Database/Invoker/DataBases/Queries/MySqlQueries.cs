using BACnetGenericDatabaseAccess.Cov.Enum;
using BACnetGenericDatabaseAccess.Database.Abstract;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace BACnetGenericDatabaseAccess.Database.Invoker.DataBases.Queries
{
    public class MySqlDbAbstractFactoryQueries : DBAbstractFactoryQuery
    {

        public MySqlDbAbstractFactoryQueries(DBAbstractFactoryCon ConMan) : base(ConMan)
        {
        }

        public override List<string> GetDatabases()
        {

            Command = "SHOW DATABASES";

            return ExecuteCommand<List<string>>(DBQueryEnum.SHOW, Command);
        }

        public override List<string> GetTableNames()
        {
            Command = $"SHOW TABLES FROM {ConMan.DatabaseName}";

            return ExecuteCommand<List<string>>(DBQueryEnum.SHOW, Command);

        }

        public override bool CreateDatabase(string databaseName)
        {
            if (databaseName == "") return false;

            if (!IsDatabase(databaseName))
            {
                Command = $"CREATE DATABASE {databaseName}";
                if (ExecuteCommand<bool>(DBQueryEnum.CREATE, Command)) return true;
            }
            return false;
        }

        public override bool CreateTable()
        {
            if (CovDataItem.TableName == "") return false;

            if (!IsTable(CovDataItem.TableName))
            {

                Command = $"CREATE TABLE {CovDataItem.TableName} ({nameof(CovDataItem.ObjectTime)} DATETIME NOT NULL, " +
                                                                 $"{nameof(CovDataItem.ObjectName)} VARCHAR(100)," +
                                                                 $"{nameof(CovDataItem.ObjectStatus)} VARCHAR(20)," +
                                                                 $"{nameof(CovDataItem.ObjectValue)}  VARCHAR(20)," +
                                                                 $" PRIMARY KEY ({nameof(CovDataItem.ObjectTime)}))";
                ExecuteCommand<bool>(DBQueryEnum.CREATE, Command);
                return true;
            }
            return false;
        }

        public override bool InsertCovData()
        {
            if (IsTable(CovDataItem.TableName))
            {
                Command = $"INSERT IGNORE INTO {CovDataItem.TableName} ({nameof(CovDataItem.ObjectTime)} , " +
                           $"{nameof(CovDataItem.ObjectName)} ," +
                           $"{nameof(CovDataItem.ObjectStatus)} ," +
                           $"{nameof(CovDataItem.ObjectValue)} )" +
                           $" VALUES ( " +
                           $"'{CovDataItem.ObjectTime.ToString("yyyy-MM-dd HH:mm:ss")}'," +
                           $"'{CovDataItem.ObjectName}'," +
                           $"'{CovDataItem.ObjectStatus}'," +
                           $"'{CovDataItem.ObjectValue}')";

                ExecuteCommand<bool>(DBQueryEnum.INSERT, Command);
                return true;
            }
            CreateTable();
            return false;
        }

        public override bool IsDatabase(string databaseName)
        {


            List<string> list = new List<string>(GetDatabases());
            return list.Count != 0 && list.Contains(databaseName);
        }

        public override bool IsTable(string tableName)
        {

            List<string> list = new List<string>(GetTableNames());
            return list.Contains(tableName);
        }

        protected override T ExecuteCommand<T>(DBQueryEnum enEnum, string Command)
        {
            try
            {
                using (var con = ConMan.CreateOpenConnection<IDbConnection>())
                {



                    if (enEnum == DBQueryEnum.CREATE)
                    {
                        var trans = con.BeginTransaction();
                        try
                        {
                            var da = ConMan.CreateDataAdapter<IDbDataAdapter, IDbConnection>(Command, con);


                            da.SelectCommand.ExecuteNonQuery();
                            //commit transaction
                            trans.Commit();
                            return (T)(object)true;
                        }
                        catch (Exception)
                        {

                            try
                            {
                                //try to rollback transaction
                                trans.Rollback();
                            }
                            catch (Exception)
                            {

                                return (T)(object)false;
                            }

                        }


                    }

                    if (enEnum == DBQueryEnum.INSERT)
                    {
                        var trans = con.BeginTransaction();
                        try
                        {
                            var da = ConMan.CreateDataAdapter<IDbDataAdapter, IDbConnection>(Command, con);


                            da.SelectCommand.ExecuteNonQuery();
                            //commit transaction
                            trans.Commit();
                            return (T)(object)true;
                        }
                        catch (Exception)
                        {

                            try
                            {
                                //try to rollback transaction
                                trans.Rollback();
                            }
                            catch (Exception)
                            {

                                return (T)(object)false;
                            }

                        }
                       
                        
                    }

                    if (typeof(T) == typeof(List<string>))
                    {
                        List<string> list = new List<string>();

                        using (var com = ConMan.CreateCommand<IDbCommand, IDbConnection>(Command, con))
                        {

                            using (var reader = com.ExecuteReader())
                            {
                                if (reader.FieldCount < 1) return (T)(object)list;
                                while (reader.Read())
                                {
                                    string row = "";
                                    for (int i = 0; i < reader.FieldCount; i++)
                                        row += reader.GetValue(i).ToString();
                                    list.Add(row);
                                    //list.Add((string)reader[_commandReader]);
                                }
                                return (T)(object)list;
                            }

                        }



                    }
                }

            }
            catch (MySqlException ex)
            {

                ErrorMessage = ex.Message;

            }





            return (T)(object)false;
        }




    }
}
