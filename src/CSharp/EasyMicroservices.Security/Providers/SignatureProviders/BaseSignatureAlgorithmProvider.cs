using EasyMicroservices.Security.Interfaces;
using System.Security.Cryptography;

namespace EasyMicroservices.Security.Providers.SignatureProviders
{
    public abstract class BaseSignatureAlgorithmProvider : ISignatureAlgorithm
    {
        protected readonly RSACryptoServiceProvider _provider;
        public BaseSignatureAlgorithmProvider()
        {
            _provider=new RSACryptoServiceProvider();
        }
        public virtual ReadOnlySpan<byte> SignData(ReadOnlySpan<byte> data)
        {
            return _provider.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }

        public virtual bool ValidateSignature(ReadOnlySpan<byte> orginData, ReadOnlySpan<byte> signatureData)
        {
            return _provider.VerifyData(orginData, signatureData, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }
    }
}
