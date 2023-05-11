using EasyMicroservices.Security.Interfaces;
using System;
using System.Security.Cryptography;

namespace EasyMicroservices.Security.Providers.SignatureProviders
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseSignatureProvider : ISignatureProvider
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly RSACryptoServiceProvider _provider;
        /// <summary>
        /// 
        /// </summary>
        public BaseSignatureProvider()
        {
            _provider = new RSACryptoServiceProvider();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual byte[] SignData(byte[] data)
        {
#if (NET45)
            throw new NotImplementedException();
#else
            return _provider.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
#endif
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orginData"></param>
        /// <param name="signatureData"></param>
        /// <returns></returns>
        public virtual bool ValidateSignature(byte[] orginData, byte[] signatureData)
        {
#if (NET45)
            throw new NotImplementedException();
#else
            return _provider.VerifyData(orginData, signatureData, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
#endif
        }
    }
}
