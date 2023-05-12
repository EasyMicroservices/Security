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
        public BaseEncryptionProviderTest(IEncryptionProvider provider)
        {
            _provider = provider;
        }


        public virtual void Test_Symmetric_ValidData(string originalDataString, string keyString)
        {
            //Arrange
            byte[] key = Encoding.UTF8.GetBytes(keyString);
            byte[] data = Encoding.UTF8.GetBytes(originalDataString);
            // Act
            var encryptedData = _provider.Encrypt(data, key);
            var decryptedData = _provider.Decrypt(encryptedData, key);

            // Assert
            Assert.Equal(originalDataString, Encoding.UTF8.GetString(decryptedData));
            Assert.True(decryptedData.SequenceEqual(data));
        }
        public virtual void Test_Symmetric_WithDifferentKey(string originalDataString, string stringKey1, string stringKey2)
        {
            // Arrange           

            var key1 = Encoding.UTF8.GetBytes(stringKey1);
            var key2 = Encoding.UTF8.GetBytes(stringKey2);
            var data = Encoding.UTF8.GetBytes(originalDataString);

            // Act
            var encryptedData = _provider.Encrypt(data, key1);
            //convert to array to can use in lambda expersion
            var arrayByte = encryptedData;
            // Assert
            Assert.ThrowsAny<CryptographicException>(() => _provider.Decrypt(arrayByte, key2));

        }
    }
}
