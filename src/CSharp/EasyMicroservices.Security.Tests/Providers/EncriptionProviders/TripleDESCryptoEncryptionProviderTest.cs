using EasyMicroservices.Security.Providers.EncriptionProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EasyMicroservices.Security.Tests.Providers.EncriptionProviders
{
    public class TripleDESCryptoEncryptionProviderTest : BaseEncryptionProviderTest
    {
        public TripleDESCryptoEncryptionProviderTest() : base(new TripleDESCryptoEncryptionProvider())
        {
        }
        [Theory]
        [InlineData("Hello Easy-MicroService!", "MySecurityKey")]
        [InlineData("سلام ایزی میکروسرویس", "کلید امنیتی")]
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
