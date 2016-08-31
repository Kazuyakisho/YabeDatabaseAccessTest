using System;

namespace BACnetGenericDatabaseAccess.ConfigDataProtection.Abstracts
{
    public abstract class AProtectData
    {
        protected const string Key = "T7VTvV5gMT9pp32H144an2cMVoJv0vkc";
        protected const string IV = "rwe567B65437CC1C";
        private const string _detectionString = "!=!ENC!=!";

        public abstract string EncryptText(string decryptText);
        public abstract string DecryptText(string encryptedText);

        private bool isEncryptedString(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            return data.EndsWith(_detectionString, StringComparison.InvariantCulture);
        }

        public string GetProtectionString(string data)
        {
            if (isEncryptedString(data))
            {
                return DecryptText(data.Replace(_detectionString, ""));
            }
            else
            {
                return data;
            }


        }

        public string SetProtectionString(string data)
        {
            return EncryptText(data) + _detectionString;
        }


    }
}
