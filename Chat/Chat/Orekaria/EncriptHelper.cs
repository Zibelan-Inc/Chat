using System;
using System.Security.Cryptography;
using System.Text;

namespace Chat
{
    internal class EncriptHelper
    {
        private static readonly UTF8Encoding Encoder = new UTF8Encoding();

        public static string EncryptString(string message, string passphrase)
        {
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] key = mD5CryptoServiceProvider.ComputeHash(Encoder.GetBytes(passphrase));
            TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
            tripleDESCryptoServiceProvider.Key = key;
            tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
            tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
            TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider2 = tripleDESCryptoServiceProvider;
            byte[] bytes = Encoder.GetBytes(message);
            ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider2.CreateEncryptor();
            byte[] inArray = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
            tripleDESCryptoServiceProvider2.Clear();
            mD5CryptoServiceProvider.Clear();
            return Convert.ToBase64String(inArray);
        }

        public static string DecryptString(string message, string passphrase)
        {
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] key = mD5CryptoServiceProvider.ComputeHash(Encoder.GetBytes(passphrase));
            TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
            tripleDESCryptoServiceProvider.Key = key;
            tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
            tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
            TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider2 = tripleDESCryptoServiceProvider;
            byte[] array = Convert.FromBase64String(message);
            ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider2.CreateDecryptor();
            byte[] bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
            tripleDESCryptoServiceProvider2.Clear();
            mD5CryptoServiceProvider.Clear();
            return Encoder.GetString(bytes);
        }
    }
}