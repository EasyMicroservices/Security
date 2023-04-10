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

            var keyAndIv = GenerateKeyAndIv(key,8,8);
            _provider.Key = keyAndIv.Key;
            _provider.IV= keyAndIv.Iv;
        
            using (var encryptor = _provider.CreateEncryptor())
            {
                byte[] encryptedData = encryptor.TransformFinalBlock(data.ToArray(), 0, data.Length);
                byte[] result = new byte[keyAndIv.Iv.Length + encryptedData.Length];
                Buffer.BlockCopy(keyAndIv.Iv, 0, result, 0, keyAndIv.Iv.Length);
                Buffer.BlockCopy(encryptedData, 0, result, keyAndIv.Iv.Length, encryptedData.Length);
                return result;
            }
        }
       
        
        public override ReadOnlySpan<byte> Decrypt(ReadOnlySpan<byte> encryptedData, ReadOnlySpan<byte> key)
        {
            var keyAndIv = GenerateKeyAndIv(key,8,8);
            _provider.Key = keyAndIv.Key;
            _provider.IV = keyAndIv.Iv;            
            Buffer.BlockCopy(encryptedData.ToArray(), 0, keyAndIv.Iv, 0, keyAndIv.Iv.Length);
            byte[] data = new byte[encryptedData.Length - keyAndIv.Iv.Length];
            Buffer.BlockCopy(encryptedData.ToArray(), keyAndIv.Iv.Length, data, 0, data.Length);
          
            using (var decryptor = _provider.CreateDecryptor())
            {
                return decryptor.TransformFinalBlock(data, 0, data.Length);
            }
        }
       
    }
}
