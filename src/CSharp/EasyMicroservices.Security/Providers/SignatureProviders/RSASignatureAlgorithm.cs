using EasyMicroservices.Security.Interfaces;

namespace EasyMicroservices.Security.Providers.SignatureProviders
{
    public class RSASignatureAlgorithm : BaseSignatureAlgorithmProvider, ISignatureAlgorithm
    {
        public RSASignatureAlgorithm():base()
        {
            
        }
        public RSASignatureAlgorithm(string publicKey, string privateKey) : base()
        {
           
            _provider.FromXmlString(publicKey);
            _provider.FromXmlString(privateKey);
        }
        
    }
}
