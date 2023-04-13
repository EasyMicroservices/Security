using EasyMicroservices.Security.Interfaces;
using System.Security.Cryptography;

namespace EasyMicroservices.Security.Providers.HashProviders
{
    public class MD5HashAlgorithm : BaseHashAlgorithmProvider, IHashAlgorithm
    {
        public override Span<byte> ComputeHash(Span<byte> buffer)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(buffer.ToArray());
                return new Span<byte>(hash);
            }
        }
        public override int HashByteSize() => 16;
        
    }
}
