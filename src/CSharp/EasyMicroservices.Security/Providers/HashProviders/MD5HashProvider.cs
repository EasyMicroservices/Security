using EasyMicroservices.Security.Interfaces;
using System.Security.Cryptography;

namespace EasyMicroservices.Security.Providers.HashProviders
{
    /// <summary>
    /// 
    /// </summary>
    public class MD5HashProvider : BaseHashProvider, IHashProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override HashAlgorithm GetHashAlgorithm()
        {
            return MD5.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int HashByteSize() => 16;
        
    }
}
