using EasyMicroservices.Security.Interfaces;
using System.Security.Cryptography;

namespace EasyMicroservices.Security.Providers.HashProviders
{
    public class SHA1HashAlgorithm : BaseHashAlgorithmProvider, IHashAlgorithm
    {
        public override Span<byte> ComputeHash(Span<byte> buffer)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] hash = sha1.ComputeHash(buffer.ToArray());
                return new Span<byte>(hash);
            }
        }
        public override int HashByteSize() => 20;
        
    }
}
