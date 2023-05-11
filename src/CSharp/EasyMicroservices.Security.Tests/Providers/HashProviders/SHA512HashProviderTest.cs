using EasyMicroservices.Security.Providers.HashProviders;
using Xunit;

namespace EasyMicroservices.Security.Tests.Providers.HashProviders
{
    public class SHA512HashProviderTest : BaseHashProviderTest
    {
        public SHA512HashProviderTest() : base(new SHA512HashProvider())
        {
        }

        [Theory]
        [InlineData("50540bc4ae31875fceb3829434c55e3c2b66ddd7227a883a3b4cc8f6cda965ad1712b3ee0008f9cee08da93f5234c1a7bf0e2570ef56d65280ffea691b953efe")]
        public override void ComputeHash_ReturnsExpectedHash(string expectedhashString)
        {
            base.ComputeHash_ReturnsExpectedHash(expectedhashString);
        }
    }
}
