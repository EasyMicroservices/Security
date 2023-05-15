using EasyMicroservices.Security.Interfaces;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EasyMicroservices.Security.Tests.Providers.SignatureProviders
{
    public abstract class BaseSignatureProviderTest
    {
        private readonly ISignatureProvider _provider;

        public BaseSignatureProviderTest(ISignatureProvider provider)
        {
            this._provider = provider;
        }

        [Theory]
        [InlineData("Hello! easy micro-service")]
        [InlineData("سلام مهدی و علی")]
        public virtual void SignatureAlgorithmSignAndValidateDataSuccess(string dataString)
        {
            //arrange
            var data = Encoding.UTF8.GetBytes(dataString);

            // act
            var signature = _provider.SignData(data);
            var isValid = _provider.ValidateSignature(data, signature);

            // assert
            Assert.True(isValid);
        }

        [Theory]
        [InlineData("Hello! easy micro-service")]
        [InlineData("سلام مهدی و علی")]
        public virtual async Task SignatureAlgorithmSignAndValidateDataSuccessStream(string dataString)
        {
            //arrange
            var data = Encoding.UTF8.GetBytes(dataString);
            using var stream = new MemoryStream();
            await _provider.SignDataToStream(stream, data);
            // act
            var signature = stream.ToArray();
            var isValid = _provider.ValidateSignature(data, signature);

            // assert
            Assert.True(isValid);
        }

        [Theory]
        [InlineData("Hello! easy micro-service")]
        [InlineData("سلام علی و مهدی")]
        public virtual void SignatureAlgorithmSignAndValidateDataFalse(string dataString)
        {
            //arrange
            var data = Encoding.UTF8.GetBytes(dataString);
            var fakeData = Encoding.UTF8.GetBytes(dataString + "-");
            // act
            var signature = _provider.SignData(data);
            var isValid = _provider.ValidateSignature(fakeData, signature);

            // assert
            Assert.False(isValid);
        }

    }
}
