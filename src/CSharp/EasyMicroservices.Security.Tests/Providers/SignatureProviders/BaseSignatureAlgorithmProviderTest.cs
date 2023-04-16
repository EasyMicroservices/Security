using EasyMicroservices.Security.Interfaces;
using System.Text;
using Xunit;

namespace EasyMicroservices.Security.Tests.Providers.SignatureProviders
{
    public class BaseSignatureAlgorithmProviderTest
    {
        private readonly ISignatureAlgorithm _provider;

        public BaseSignatureAlgorithmProviderTest(ISignatureAlgorithm provider)
        {
            this._provider = provider;
        }

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
        public virtual void SignatureAlgorithmSignAndValidateDataFalse(string dataString)
        {
            //arrange
            var data = Encoding.UTF8.GetBytes(dataString);            
            var fakeData= Encoding.UTF8.GetBytes(dataString+"-");
            // act
            var signature = _provider.SignData(data);
            var isValid = _provider.ValidateSignature(fakeData, signature);

            // assert
            Assert.False(isValid);
        }
      
    }
}
