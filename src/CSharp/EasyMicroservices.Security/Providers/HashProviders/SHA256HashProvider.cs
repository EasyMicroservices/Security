using EasyMicroservices.Security.Interfaces;
using System.Security.Cryptography;

namespace EasyMicroservices.Security.Providers.HashProviders
{
    /// <summary>
    /// 
    /// </summary>
    public class SHA256HashProvider : BaseHashProvider, IHashProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override HashAlgorithm GetHashAlgorithm()
        {
            return SHA256.Create();
        }
    }
}
