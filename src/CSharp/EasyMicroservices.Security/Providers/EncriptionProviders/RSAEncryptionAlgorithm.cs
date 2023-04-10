using EasyMicroservices.Security.Interfaces;
using System.Security.Cryptography;

namespace EasyMicroservices.Security.Providers.EncriptionProviders
{
    public class RSAEncryptionAlgorithm: BaseEncryptionAlgorithmProvider, IEncryptionAlgorithm
    {
        private readonly RSACryptoServiceProvider _provider;
        public RSAEncryptionAlgorithm()
        {
            _provider = new RSACryptoServiceProvider();
        }
        public RSAEncryptionAlgorithm(string publicKey, string privateKey)
        {
            _provider = new RSACryptoServiceProvider();
            _provider.FromXmlString(publicKey);
            _provider.FromXmlString(privateKey);
        }
        public override ReadOnlySpan<byte> Encrypt(ReadOnlySpan<byte> data, ReadOnlySpan<byte> key)
        {

            return _provider.Encrypt(data.ToArray(), true);
        }
        public override ReadOnlySpan<byte> Decrypt(ReadOnlySpan<byte> encryptedData, ReadOnlySpan<byte> key)
        {
            return _provider.Decrypt(encryptedData.ToArray(), true);
        }   
    }
}

