using EasyMicroservices.Security.Providers.EncryptionProviders;
using Xunit;

namespace EasyMicroservices.Security.Tests.Providers.EncriptionProviders
{
    public class TripleDESCryptoEncryptionProviderTest : BaseEncryptionProviderTest
    {
        public TripleDESCryptoEncryptionProviderTest() : base(new TripleDESCryptoEncryptionProvider(Key), new TripleDESCryptoEncryptionProvider(Key2))
        {
        }
    }
}
