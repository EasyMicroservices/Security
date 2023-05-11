using EasyMicroservices.Security.Interfaces;
using System.Security.Cryptography;

namespace EasyMicroservices.Security.Providers.HashProviders
{
    /// <summary>
    /// 
    /// </summary>
    public class SHA384HashAlgorithm : BaseHashAlgorithmProvider, IHashProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override HashAlgorithm GetHashAlgorithm()
        {
            return SHA384.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int HashByteSize() => 48;
       
    }
}
