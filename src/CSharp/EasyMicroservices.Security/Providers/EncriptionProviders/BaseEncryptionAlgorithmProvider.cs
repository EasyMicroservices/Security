using EasyMicroservices.Security.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace EasyMicroservices.Security.Providers.EncriptionProviders
{
    public abstract class BaseEncryptionAlgorithmProvider : IEncryptionAlgorithm
    {
        // salt size must be at least 8 bytes, we will use 16 bytes
        private static readonly byte[] salt = Encoding.Unicode.GetBytes("EasyEasy");
        // iterations must be at least 1000, we will use 2000
        private static readonly int iterations = 2000;

        public (byte[] Key, byte[] Iv) GenerateKeyAndIv(ReadOnlySpan<byte> key,int keyByteSize, int IvByteSize)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(key.ToArray(), salt, iterations, HashAlgorithmName.SHA256))
            {
                return (pbkdf2.GetBytes(keyByteSize), pbkdf2.GetBytes(IvByteSize));
            }

        }
        public virtual ReadOnlySpan<byte> Decrypt(ReadOnlySpan<byte> encryptedData, ReadOnlySpan<byte> key)
        {
            ReadOnlySpan<byte> decryptedData;
            using (Aes aes = Aes.Create())
            {
                var keyAndIv = GenerateKeyAndIv(key,32,16);
                aes.Key = keyAndIv.Key;
                aes.IV = keyAndIv.Iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                {
                    cs.Write(encryptedData.ToArray(), 0, encryptedData.Length);
                    cs.FlushFinalBlock();
                    decryptedData = ms.ToArray();
                }
            }

            return decryptedData;
        }

        public virtual ReadOnlySpan<byte> Encrypt(ReadOnlySpan<byte> data, ReadOnlySpan<byte> key)
        {
            ReadOnlySpan<byte> encryptedData;

            using (Aes aes = Aes.Create())
            {
                var keyAndIv = GenerateKeyAndIv(key, 32, 16);
                aes.Key = keyAndIv.Key;
                aes.IV = keyAndIv.Iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    cs.Write(data.ToArray(), 0, data.Length);
                    cs.FlushFinalBlock();
                    encryptedData = ms.ToArray();
                }
            }
            return encryptedData;
        }

        public virtual bool IsSymmetricAlgorithm()
        {
            return true;
        }
    }
}
