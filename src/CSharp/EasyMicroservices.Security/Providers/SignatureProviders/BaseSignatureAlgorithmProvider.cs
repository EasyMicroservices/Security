using EasyMicroservices.Security.Interfaces;
using System;

namespace EasyMicroservices.Security.Providers.SignatureProviders
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseSignatureAlgorithmProvider : ISignatureProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual byte[] SignData(byte[] data)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual bool ValidateSignature(string data, string signature)
        {
            throw new NotImplementedException();
        }
    }
}
