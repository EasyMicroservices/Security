using EasyMicroservices.Security.Providers.HashProviders;
using System.Security.Cryptography;
using Xunit;

namespace EasyMicroservices.Security.Tests.Providers.HashProviders
{
    public class SHA512HashProviderTest : BaseHashProviderTest
    {
        public SHA512HashProviderTest() : base(new SHA512HashProvider())
        {
        }

        public override HashAlgorithm GetHashAlgorithm()
        {
            return SHA512.Create();
        }
    }
}
