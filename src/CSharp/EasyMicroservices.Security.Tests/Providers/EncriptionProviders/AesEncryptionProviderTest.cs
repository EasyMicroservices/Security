using EasyMicroservices.Security.Providers.EncryptionProviders;
using System.Text;
using Xunit;

namespace EasyMicroservices.Security.Tests.Providers.EncriptionProviders
{
    public class AesEncryptionProviderTest : BaseEncryptionProviderTest
    {
        public AesEncryptionProviderTest() : base(new AesEncryptionProvider(Key), new AesEncryptionProvider(Key2))
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
