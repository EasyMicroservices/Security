using EasyMicroservices.Security.Providers.EncryptionProviders;
using Xunit;

namespace EasyMicroservices.Security.Tests.Providers.EncriptionProviders
{
    public class TripleDESCryptoEncryptionProviderTest : BaseEncryptionProviderTest
    {
        public TripleDESCryptoEncryptionProviderTest() : base(new TripleDESCryptoEncryptionProvider(Key), new TripleDESCryptoEncryptionProvider(Key2))
        {
        }
        [Theory]
        [InlineData("Hello Easy-MicroService!")]
        [InlineData("سلام ایزی میکروسرویس")]
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
