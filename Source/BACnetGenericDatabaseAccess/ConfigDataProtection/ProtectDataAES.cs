using BACnetGenericDatabaseAccess.ConfigDataProtection.Abstracts;
using System;
using System.Security.Cryptography;
using System.Text;

namespace BACnetGenericDatabaseAccess.ConfigDataProtection
{
    public class AProtectDataAes : AProtectData
    {


        public override string EncryptText(string decryptText)
        {

            byte[] plainTextBytes = Encoding.ASCII.GetBytes(decryptText);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = Encoding.ASCII.GetBytes(Key);
            aes.IV = Encoding.ASCII.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            ICryptoTransform crypto = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] encrypted = crypto.TransformFinalBlock(plainTextBytes, 0, plainTextBytes.Length);
            crypto.Dispose();
            return Convert.ToBase64String(encrypted);
        }

        public override string DecryptText(string encryptedText)
        {

            byte[] encryptedByte = Convert.FromBase64String(encryptedText);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = Encoding.ASCII.GetBytes(Key);
            aes.IV = Encoding.ASCII.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            ICryptoTransform crypto = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] secret = crypto.TransformFinalBlock(encryptedByte, 0, encryptedByte.Length);
            crypto.Dispose();
            return Encoding.ASCII.GetString(secret);
        }
    }
}
