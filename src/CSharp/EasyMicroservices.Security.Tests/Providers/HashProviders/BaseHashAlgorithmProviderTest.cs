using EasyMicroservices.Security.Interfaces;
using Xunit;

namespace EasyMicroservices.Security.Tests.Providers.HashProviders
{
    public abstract class BaseHashAlgorithmProviderTest
    {
        private readonly byte[] _testData = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 };
        protected readonly IHashAlgorithm _provider;
        public BaseHashAlgorithmProviderTest(IHashAlgorithm provider)
        {
            _provider = provider;
        }
        public virtual void ComputeHash_ReturnsExpectedHash(string expectedhashString)
        {            
            Span<byte> hash = _provider.ComputeHash(_testData);
            Assert.Equal(expectedhashString, BitConverter.ToString(hash.ToArray()).Replace("-", "").ToLower());
            Assert.Equal(_provider.HashByteSize(), hash.Length);
        }
    }
}
