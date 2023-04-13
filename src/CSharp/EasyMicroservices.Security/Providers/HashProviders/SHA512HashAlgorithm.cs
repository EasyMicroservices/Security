using EasyMicroservices.Security.Interfaces;
using System.Security.Cryptography;

namespace EasyMicroservices.Security.Providers.HashProviders
{
    public class SHA512HashAlgorithm : BaseHashAlgorithmProvider, IHashAlgorithm
    {
        public override Span<byte> ComputeHash(Span<byte> buffer)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] hash = sha512.ComputeHash(buffer.ToArray());
                return new Span<byte>(hash);
            }
        }
        public override int HashByteSize() => 64;
        
    }
}
