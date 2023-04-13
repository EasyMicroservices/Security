using EasyMicroservices.Security.Interfaces;
using System.Security.Cryptography;

namespace EasyMicroservices.Security.Providers.HashProviders
{
    public abstract class BaseHashAlgorithmProvider : IHashAlgorithm
    {
        public virtual Span<byte> ComputeHash(Span<byte> buffer)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(buffer.ToArray());
                return new Span<byte>(hash);
            }
        }

        public virtual int HashByteSize() => 32;
     
    }
}
