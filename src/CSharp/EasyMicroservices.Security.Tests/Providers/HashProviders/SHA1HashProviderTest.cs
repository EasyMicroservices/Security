using EasyMicroservices.Security.Providers.HashProviders;
using System.Security.Cryptography;
using Xunit;

namespace EasyMicroservices.Security.Tests.Providers.HashProviders
{
    public class SHA1HashProviderTest : BaseHashProviderTest
    {
        public SHA1HashProviderTest() : base(new SHA1HashProvider())
        {
        }

        public override HashAlgorithm GetHashAlgorithm()
        {
            return SHA1.Create();
        }
    }
}
