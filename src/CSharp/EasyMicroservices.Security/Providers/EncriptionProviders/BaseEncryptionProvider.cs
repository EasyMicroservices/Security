using EasyMicroservices.Security.Interfaces;
using EasyMicroservices.Security.Models;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EasyMicroservices.Security.Providers.EncriptionProviders
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseEncryptionProvider : IEncryptionProvider
    {
        // salt size must be at least 8 bytes, we will use 16 bytes
        private static readonly byte[] salt = Encoding.Unicode.GetBytes("EasyEasy");
        // iterations must be at least 1000, we will use 2000
        private static readonly int iterations = 2000;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="keyByteSize"></param>
        /// <param name="IvByteSize"></param>
        /// <returns></returns>
        public RSAKeyValue GenerateKeyAndIv(byte[] key, int keyByteSize, int IvByteSize)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(key, salt, iterations))
            {
                return new RSAKeyValue(pbkdf2.GetBytes(keyByteSize), pbkdf2.GetBytes(IvByteSize));
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="encryptedData"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual byte[] Decrypt(byte[] encryptedData, byte[] key)
        {
            byte[] decryptedData;
            using (Aes aes = Aes.Create())
            {
                var keyAndIv = GenerateKeyAndIv(key, 32, 16);
                aes.Key = keyAndIv.Key;
                aes.IV = keyAndIv.Iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                {
                    cs.Write(encryptedData, 0, encryptedData.Length);
                    cs.FlushFinalBlock();
                    decryptedData = ms.ToArray();
                }
            }

            return decryptedData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual byte[] Encrypt(byte[] data, byte[] key)
        {
            byte[] encryptedData;

            using (Aes aes = Aes.Create())
            {
                var keyAndIv = GenerateKeyAndIv(key, 32, 16);
                aes.Key = keyAndIv.Key;
                aes.IV = keyAndIv.Iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    cs.Write(data, 0, data.Length);
                    cs.FlushFinalBlock();
                    encryptedData = ms.ToArray();
                }
            }
            return encryptedData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual bool IsSymmetricAlgorithm()
        {
            return true;
        }
    }
}
