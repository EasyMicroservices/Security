using EasyMicroservices.Security.Providers.HashProviders;
using System.Security.Cryptography;
using Xunit;

namespace EasyMicroservices.Security.Tests.Providers.HashProviders
{
    public class SHA256HashProviderTest : BaseHashProviderTest
    {
        public SHA256HashProviderTest() : base(new SHA256HashProvider())
        {
        }

        public override HashAlgorithm GetHashAlgorithm()
        {
            return SHA256.Create();
        }
    }
}
