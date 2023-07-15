using EasyMicroservices.Utilities.IO.Interfaces;

namespace EasyMicroservices.Security.Providers.SignatureProviders
{
    /// <summary>
    /// 
    /// </summary>
    public class RSASignatureProvider : BaseSignatureProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="streamMiddleware"></param>
        public RSASignatureProvider(IStreamMiddleware streamMiddleware = default) : base(streamMiddleware)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="publicKey"></param>
        /// <param name="privateKey"></param>
        /// <param name="streamMiddleware"></param>
        public RSASignatureProvider(string publicKey, string privateKey, IStreamMiddleware streamMiddleware = default) : base(streamMiddleware)
        {
            _provider.FromXmlString(publicKey);
            _provider.FromXmlString(privateKey);
        }
    }
}
