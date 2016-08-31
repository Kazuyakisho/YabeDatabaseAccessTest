using System;
using System.Reflection;
using BACnetGenericDatabaseAccess.Database.Abstract;

namespace BACnetGenericDatabaseAccess.Database.Invoker
{
    public static class DBClassInvoker
    {


        public static string ErrorMessage { get; private set; } = "No error";

        //public DBProviderHandler ProvHandler { get; private set; }

        /// <summary>
        /// Find and invoke class by connectionType
        /// </summary>
        /// <param name="connectionType"></param>
        /// <returns></returns>
        public static DBAbstractFactoryCon CreateDB(this DBAbstractFactoryCon provman, Type connectionType, string conString)
        {


            try
            {
                // Find the class
                Type database = connectionType;

                // Get it's constructor
                ConstructorInfo constructor = database.GetConstructor(new Type[] { });

                // Invoke it's constructor, which returns an instance.
                DBAbstractFactoryCon createdObject = (DBAbstractFactoryCon)constructor.Invoke(null);

                createdObject.ConnectionsString = conString;
                // Pass back the instance as a Database
                return createdObject;
            }
            catch (Exception excep)
            {
                ErrorMessage = "Error instantiating database " + connectionType + ". " + excep.Message;
                DBAbstractFactoryCon handler = null;
                return handler;
            }
        }



    }
}
