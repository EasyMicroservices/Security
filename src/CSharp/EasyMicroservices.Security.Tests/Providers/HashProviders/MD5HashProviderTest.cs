using EasyMicroservices.Security.Providers.HashProviders;
using System.Collections.Generic;
using System.Security.Cryptography;
using Xunit;

namespace EasyMicroservices.Security.Tests.Providers.HashProviders
{
    public class MD5HashProviderTest : BaseHashProviderTest
    {
        public MD5HashProviderTest() : base(new MD5HashProvider())
        {
        }

        public override HashAlgorithm GetHashAlgorithm()
        {
            return MD5.Create();
        }
    }
}
