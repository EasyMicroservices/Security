using EasyMicroservices.Security.Providers.HashProviders;
using Xunit;

namespace EasyMicroservices.Security.Tests.Providers.HashProviders
{
    public class SHA1HashProviderTest : BaseHashProviderTest
    {
        public SHA1HashProviderTest() : base(new SHA1HashProvider())
        {
        }

        [Theory]
        [InlineData("11966ab9c099f8fabefac54c08d5be2bd8c903af")]
        public override void ComputeHash_ReturnsExpectedHash(string expectedhashString)
        {
            base.ComputeHash_ReturnsExpectedHash(expectedhashString);
        }
    }
}
