namespace BACnetGenericDatabaseAccess.Utils
{
    public static class StringConverter
    {

        public static string ConvertConnectionString(this string str)
        {
            return str.Replace("[", string.Empty).Replace("]", string.Empty);
        }
    }
}
