using EasyMicroservices.Security.Providers.EncryptionProviders;
using Xunit;

namespace EasyMicroservices.Security.Tests.Providers.EncriptionProviders
{
    public class DESCryptoEncryptionProviderTest : BaseEncryptionProviderTest
    {
        public DESCryptoEncryptionProviderTest() : base(new DESCryptoEncryptionProvider(Key), new DESCryptoEncryptionProvider(Key2))
        {
        }
        [Theory]
        [InlineData("Hello Easy-MicroService!")]
        public override void Test_Symmetric_ValidData(string originalDataString)
        {
            base.Test_Symmetric_ValidData(originalDataString);
        }
        [Theory]
        [InlineData("Hello Easy-MicroService!")]
        public override void Test_Symmetric_WithDifferentKey(string originalDataString)
        {
            base.Test_Symmetric_WithDifferentKey(originalDataString);
        }
    }
}
