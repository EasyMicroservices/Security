using EasyMicroservices.Security.Providers.EncryptionProviders;
using Xunit;

namespace EasyMicroservices.Security.Tests.Providers.EncriptionProviders
{
    public class DESCryptoEncryptionProviderTest : BaseEncryptionProviderTest
    {
        public DESCryptoEncryptionProviderTest() : base(new DESCryptoEncryptionProvider(Key), new DESCryptoEncryptionProvider(Key2))
        {
        }
    }
}
