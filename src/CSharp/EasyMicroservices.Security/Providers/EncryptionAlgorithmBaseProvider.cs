using EasyMicroservices.Security.Interfaces;
using System.Security.Cryptography;

namespace EasyMicroservices.Security.Providers
{
    public abstract class EncryptionAlgorithmBaseProvider : IEncryptionAlgorithm
    {
        public virtual ReadOnlySpan<byte> Decrypt(ReadOnlySpan<byte> encryptedData, ReadOnlySpan<byte> key)
        {
            ReadOnlySpan<byte> decryptedData;
            using (Aes aes = Aes.Create())
            {
                aes.Key = key.ToArray();
                aes.IV = encryptedData.ToArray().Take(aes.BlockSize / 8).ToArray();

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                {
                    cs.Write(encryptedData.ToArray(), aes.BlockSize / 8, encryptedData.Length - aes.BlockSize / 8);
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
                aes.Key = key.ToArray();
                aes.GenerateIV();

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
