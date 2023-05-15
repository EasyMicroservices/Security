using EasyMicroservices.Security.Interfaces;
using EasyMicroservices.Security.Models;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EasyMicroservices.Security.Providers.EncryptionProviders
{
    /// <summary>
    /// 
    /// </summary>
    public class AesEncryptionProvider : BaseEncryptionProvider, IEncryptionProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public AesEncryptionProvider(byte[] key)
        {
            Key = key;
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] Key { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encryptedData"></param>
        /// <returns></returns>
        public override byte[] Decrypt(byte[] encryptedData)
        {
            byte[] decryptedData;
            using (Aes aes = Aes.Create())
            {
                var keyAndIv = GenerateKeyAndIv(Key, 32, 16);
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
        /// <returns></returns>
        public override byte[] Encrypt(byte[] data)
        {
            byte[] encryptedData;

            using (Aes aes = Aes.Create())
            {
                var keyAndIv = GenerateKeyAndIv(Key, 32, 16);
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
    }
}
