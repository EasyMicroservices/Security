using EasyMicroservices.Security.Interfaces;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EasyMicroservices.Security.Tests.Providers.EncriptionProviders
{
    public abstract class BaseEncryptionProviderTest
    {
        protected readonly IEncryptionProvider _provider;
        protected readonly IEncryptionProvider _anotherProvider;
        public BaseEncryptionProviderTest(IEncryptionProvider provider, IEncryptionProvider anotherProvider)
        {
            _provider = provider;
            _anotherProvider = anotherProvider;
        }

        public static byte[] Key { get; set; } = Encoding.UTF8.GetBytes("MySecurityKey");
        public static byte[] Key2 { get; set; } = Encoding.UTF8.GetBytes("سلام کلید");

        [Theory]
        [InlineData("Hello Easy-MicroService!")]
        [InlineData("سلام ایزی میکروسرویس")]
        public virtual void Test_Symmetric_ValidData(string originalDataString)
        {
            //Arrange
            byte[] data = Encoding.UTF8.GetBytes(originalDataString);
            // Act
            var encryptedData = _provider.Encrypt(data);
            var decryptedData = _provider.Decrypt(encryptedData);

            // Assert
            Assert.Equal(originalDataString, Encoding.UTF8.GetString(decryptedData));
            Assert.True(decryptedData.SequenceEqual(data));
        }

        [Theory]
        [InlineData("Hello Easy-MicroService!")]
        public virtual void Test_Symmetric_WithDifferentKey(string originalDataString)
        {
            // Arrange           

            var data = Encoding.UTF8.GetBytes(originalDataString);

            // Act
            var encryptedData = _provider.Encrypt(data);
            //convert to array to can use in lambda expersion
            var arrayByte = encryptedData;
            // Assert
            Assert.ThrowsAny<CryptographicException>(() => _anotherProvider.Decrypt(arrayByte));
            Assert.True(encryptedData.SequenceEqual(_provider.Compute(data)));
        }

        [Theory]
        [InlineData("Hello Easy-MicroService!")]
        [InlineData("سلام ایزی میکروسرویس")]
        public virtual async Task Test_Symmetric_StreamData(string originalDataString)
        {
            var data = Encoding.UTF8.GetBytes(originalDataString);
            //Arrange
            using var stream = new MemoryStream();
            // Act
            await _provider.EncryptToStream(stream, data);
            stream.Seek(0, SeekOrigin.Begin);
            var decryptedData = await _provider.DecryptFromStream(stream);

            // Assert
            Assert.Equal(originalDataString, Encoding.UTF8.GetString(decryptedData));
            Assert.True(decryptedData.SequenceEqual(data));
        }
    }
}
