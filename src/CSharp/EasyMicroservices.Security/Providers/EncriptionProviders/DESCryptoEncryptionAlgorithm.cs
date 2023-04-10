using EasyMicroservices.Security.Interfaces;
using System.Security.Cryptography;

namespace EasyMicroservices.Security.Providers.EncriptionProviders
{
    public class DESCryptoEncryptionAlgorithm : BaseEncryptionAlgorithmProvider, IEncryptionAlgorithm
    {
        private readonly DESCryptoServiceProvider _provider;
        public DESCryptoEncryptionAlgorithm()
        {
            _provider = new DESCryptoServiceProvider();
        }
        public override ReadOnlySpan<byte> Encrypt(ReadOnlySpan<byte> data, ReadOnlySpan<byte> key)
        {
            _provider.Key = key.ToArray();
            _provider.GenerateIV();
            byte[] iv = _provider.IV;
            using (var encryptor = _provider.CreateEncryptor())
            {
                byte[] encryptedData = encryptor.TransformFinalBlock(data.ToArray(), 0, data.Length);
                byte[] result = new byte[iv.Length + encryptedData.Length];
                Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                Buffer.BlockCopy(encryptedData, 0, result, iv.Length, encryptedData.Length);
                return result;
            }
        }
       
        
        public override ReadOnlySpan<byte> Decrypt(ReadOnlySpan<byte> encryptedData, ReadOnlySpan<byte> key)
        {
            _provider.Key = key.ToArray();
            byte[] iv = new byte[8];
            Buffer.BlockCopy(encryptedData.ToArray(), 0, iv, 0, iv.Length);
            byte[] data = new byte[encryptedData.Length - iv.Length];
            Buffer.BlockCopy(encryptedData.ToArray(), iv.Length, data, 0, data.Length);
            _provider.IV = iv;
            using (var decryptor = _provider.CreateDecryptor())
            {
                return decryptor.TransformFinalBlock(data, 0, data.Length);
            }
        }
       
    }
}
