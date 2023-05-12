using EasyMicroservices.Security.Interfaces;
using System;
using Xunit;

namespace EasyMicroservices.Security.Tests.Providers.HashProviders
{
    public abstract class BaseHashProviderTest
    {
        private readonly byte[] _testData = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 };
        protected readonly IHashProvider _provider;
        public BaseHashProviderTest(IHashProvider provider)
        {
            _provider = provider;
        }
        public virtual void ComputeHash_ReturnsExpectedHash(string expectedhashString)
        {
            byte[] hash = _provider.ComputeHash(_testData);
            Assert.Equal(expectedhashString, BitConverter.ToString(hash).Replace("-", "").ToLower());
            Assert.Equal(_provider.HashByteSize(), hash.Length);
        }
    }
}
