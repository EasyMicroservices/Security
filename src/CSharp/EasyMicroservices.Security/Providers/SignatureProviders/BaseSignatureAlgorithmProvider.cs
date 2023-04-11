using EasyMicroservices.Security.Interfaces;

namespace EasyMicroservices.Security.Providers.SignatureProviders
{
    public abstract class BaseSignatureAlgorithmProvider : ISignatureAlgorithm
    {
        public virtual ReadOnlySpan<byte> SignData(ReadOnlySpan<byte> data)
        {
            throw new NotImplementedException();
        }

        public virtual bool ValidateSignature(string data, string signature)
        {
            throw new NotImplementedException();
        }
    }
}
