using EasyMicroservices.Security.Interfaces;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        }
    }
}
