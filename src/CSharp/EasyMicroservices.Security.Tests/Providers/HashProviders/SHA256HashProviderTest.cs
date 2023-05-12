using EasyMicroservices.Security.Providers.HashProviders;
using Xunit;

namespace EasyMicroservices.Security.Tests.Providers.HashProviders
{
    public class SHA256HashProviderTest : BaseHashProviderTest
    {
        public SHA256HashProviderTest() : base(new SHA256HashProvider())
        {
        }

        [Theory]
        [InlineData("74f81fe167d99b4cb41d6d0ccda82278caee9f3e2f25d5e5a3936ff3dcec60d0")]
        public override void ComputeHash_ReturnsExpectedHash(string expectedhashString)
        {
            base.ComputeHash_ReturnsExpectedHash(expectedhashString);
        }
    }
}
