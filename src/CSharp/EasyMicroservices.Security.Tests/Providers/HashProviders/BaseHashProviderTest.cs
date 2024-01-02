using EasyMicroservices.Security.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EasyMicroservices.Security.Tests.Providers.HashProviders
{
    public abstract class BaseHashProviderTest
    {
        protected readonly IHashProvider _provider;
        public BaseHashProviderTest(IHashProvider provider)
        {
            _provider = provider;
        }

        public abstract HashAlgorithm GetHashAlgorithm();

        [Theory]
        [InlineData("Hi Easy Microservices")]
        [InlineData("I am Ali")]
        [InlineData("I am Mahdi")]
        [InlineData("من علی هستم")]
        [InlineData("من مهدی هستم")]
        public virtual void ComputeHash_ReturnsExpectedHash(string data)
        {
            var bytes = Encoding.UTF8.GetBytes(data);
            byte[] hash = _provider.ComputeHash(bytes);
            byte[] realHash = GetHashAlgorithm().ComputeHash(bytes);
            Assert.Equal(hash.Length, hash.Length);
            Assert.Equal(BitConverter.ToString(realHash).Replace("-", "").ToLower(), BitConverter.ToString(hash).Replace("-", "").ToLower());
            Assert.True(hash.SequenceEqual(realHash));
            Assert.True(hash.SequenceEqual(_provider.Compute(bytes)));
        }

        [Theory]
        [InlineData("Hi Easy Microservices")]
        [InlineData("I am Ali")]
        [InlineData("I am Mahdi")]
        [InlineData("من علی هستم")]
        [InlineData("من مهدی هستم")]
        public virtual async Task ComputeStreamHash(string data)
        {
            var bytes = Encoding.UTF8.GetBytes(data);
            using var stream = new MemoryStream();
            await _provider.ComputeHashToStream(stream, bytes);
            byte[] hash = stream.ToArray();
            byte[] realHash = GetHashAlgorithm().ComputeHash(bytes);
            Assert.Equal(hash.Length, hash.Length);
            Assert.Equal(BitConverter.ToString(realHash).Replace("-", "").ToLower(), BitConverter.ToString(hash).Replace("-", "").ToLower());
            Assert.True(hash.SequenceEqual(realHash));
            Assert.True(hash.SequenceEqual(_provider.Compute(bytes)));
        }
    }
}
