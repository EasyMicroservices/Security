using EasyMicroservices.Security.Providers.HashProviders;
using Xunit;

namespace EasyMicroservices.Security.Tests.Providers.HashProviders
{
    public class SHA384HashProviderTest : BaseHashProviderTest
    {
        public SHA384HashProviderTest() : base(new SHA384HashProvider())
        {
        }

        [Theory]
        [InlineData("d88875db0f77aad8f3d994fe68cd1cc7ec3a4ff14378b7feb991e54784850192145854c36e5a40a0c2e80da2002d7cc8")]
        public override void ComputeHash_ReturnsExpectedHash(string expectedhashString)
        {
            base.ComputeHash_ReturnsExpectedHash(expectedhashString);
        }
    }
}
