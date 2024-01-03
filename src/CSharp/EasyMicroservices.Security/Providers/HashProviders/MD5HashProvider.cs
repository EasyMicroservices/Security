using EasyMicroservices.Security.Interfaces;
using System.Security.Cryptography;
using EasyMicroservices.Utilities.IO.Interfaces;

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
        /// <param name="streamMiddleware"></param>
        public MD5HashProvider(IStreamMiddleware streamMiddleware = default) : base(streamMiddleware)
        {

        }

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
