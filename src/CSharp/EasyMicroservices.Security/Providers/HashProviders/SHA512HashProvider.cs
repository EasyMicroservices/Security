using EasyMicroservices.Security.Interfaces;
using System.Security.Cryptography;

namespace EasyMicroservices.Security.Providers.HashProviders
{
    /// <summary>
    /// 
    /// </summary>
    public class SHA512HashProvider : BaseHashProvider, IHashProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override HashAlgorithm GetHashAlgorithm()
        {
            return SHA512.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int HashByteSize() => 64;

    }
}
