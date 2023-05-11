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
        public RSASignatureProvider() : base()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="publicKey"></param>
        /// <param name="privateKey"></param>
        public RSASignatureProvider(string publicKey, string privateKey) : base()
        {
            _provider.FromXmlString(publicKey);
            _provider.FromXmlString(privateKey);
        }
    }
}
