using EasyMicroservices.Security.Providers.EncriptionProviders;
using Xunit;

namespace EasyMicroservices.Security.Tests.Providers.EncriptionProviders
{
    public class DESCryptoEncryptionAlgorithmTest : BaseEncryptionAlgorithmProviderTest
    {
        public DESCryptoEncryptionAlgorithmTest() : base(new DESCryptoEncryptionAlgorithm())
        {
        }
        [Theory]
        [InlineData("Hello Easy-MicroService!", "MySecurityKey")]    
        public override void Test_Symmetric_ValidData(string originalDataString, string keyString)
        {
            base.Test_Symmetric_ValidData(originalDataString, keyString);
        }
        [Theory]
        [InlineData("Hello Easy-MicroService!", "MySecurityKey1", "Invalidkey")]
        public override void Test_Symmetric_WithDifferentKey(string originalDataString, string stringKey1, string stringKey2)
        {
            base.Test_Symmetric_WithDifferentKey(originalDataString, stringKey1, stringKey2);
        }
    }
}
