using EasyMicroservices.Security.Providers.HashProviders;
using System.Collections.Generic;
using Xunit;

namespace EasyMicroservices.Security.Tests.Providers.HashProviders
{
    public class MD5HashAlgorithmTest : BaseHashAlgorithmProviderTest
    {
        public MD5HashAlgorithmTest() : base(new MD5HashAlgorithm())
        {
        }

        [Theory]
        [InlineData("7cfdd07889b3295d6a550914ab35e068")]
        public override void ComputeHash_ReturnsExpectedHash(string expectedhashString)
        {
            base.ComputeHash_ReturnsExpectedHash(expectedhashString);
        }
    }
}
