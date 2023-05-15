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
    }
}
