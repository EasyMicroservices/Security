using EasyMicroservices.Security.Interfaces;
using System.Security.Cryptography;

namespace EasyMicroservices.Security.Providers.HashProviders
{
    public class SHA384HashAlgorithm : BaseHashAlgorithmProvider, IHashAlgorithm
    {
        public override Span<byte> ComputeHash(Span<byte> buffer)
        {
            using (SHA384 sha384 = SHA384.Create())
            {
                byte[] hash = sha384.ComputeHash(buffer.ToArray());
                return new Span<byte>(hash);
            }
        }
        public override int HashByteSize() => 48;
       
    }
}
