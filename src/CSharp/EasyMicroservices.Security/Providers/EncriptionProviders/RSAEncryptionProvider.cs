using EasyMicroservices.Security.Interfaces;
using System.Security.Cryptography;

namespace EasyMicroservices.Security.Providers.EncriptionProviders
{
    /// <summary>
    /// 
    /// </summary>
    public class RSAEncryptionProvider : BaseEncryptionProvider, IEncryptionProvider
    {
        private readonly RSA _provider;
        /// <summary>
        /// 
        /// </summary>
        public RSAEncryptionProvider()
        {
            _provider = RSA.Create();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="publicKey"></param>
        /// <param name="privateKey"></param>
        public RSAEncryptionProvider(string publicKey, string privateKey)
        {
            _provider = RSA.Create();
            _provider.FromXmlString(publicKey);
            _provider.FromXmlString(privateKey);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public override byte[] Encrypt(byte[] data, byte[] key)
        {
#if(NET45 || NET452)
            return _provider.EncryptValue(data);
#else
            return _provider.Encrypt(data, RSAEncryptionPadding.Pkcs1);
#endif
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="encryptedData"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public override byte[] Decrypt(byte[] encryptedData, byte[] key)
        {
#if (NET45|| NET452)
            return _provider.DecryptValue(encryptedData);
#else
            return _provider.Decrypt(encryptedData, RSAEncryptionPadding.Pkcs1);
#endif
        }
    }
}

