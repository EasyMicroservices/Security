using EasyMicroservices.Security.Providers.HashProviders;
using System.Security.Cryptography;
using Xunit;

namespace EasyMicroservices.Security.Tests.Providers.HashProviders
{
    public class SHA384HashProviderTest : BaseHashProviderTest
    {
        public SHA384HashProviderTest() : base(new SHA384HashProvider())
        {
        }

        public override HashAlgorithm GetHashAlgorithm()
        {
            return SHA384.Create();
        }
    }
}
