using EasyMicroservices.Security.Interfaces;
using System.Security.Cryptography;

namespace EasyMicroservices.Security.Providers.HashProviders
{
    /// <summary>
    /// 
    /// </summary>
    public class SHA1HashAlgorithm : BaseHashAlgorithmProvider, IHashProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override HashAlgorithm GetHashAlgorithm()
        {
            return SHA1.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int HashByteSize() => 20;
        
    }
}
