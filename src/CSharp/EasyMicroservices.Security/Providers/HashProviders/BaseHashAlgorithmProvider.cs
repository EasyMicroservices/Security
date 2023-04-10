using EasyMicroservices.Security.Interfaces;

namespace EasyMicroservices.Security.Providers.HashProviders
{
    public abstract class BaseHashAlgorithmProvider : IHashAlgorithm
    {
        public virtual Span<byte> ComputeHash(Span<byte> buffer)
        {
            throw new NotImplementedException();
        }
    }
}
