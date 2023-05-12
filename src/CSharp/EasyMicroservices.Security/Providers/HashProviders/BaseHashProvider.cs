using EasyMicroservices.Security.Interfaces;
using System.Security.Cryptography;

namespace EasyMicroservices.Security.Providers.HashProviders
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseHashProvider : IHashProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public virtual byte[] ComputeHash(byte[] buffer)
        {
            using (var hashAlgorithm = GetHashAlgorithm())
            {
                byte[] hash = hashAlgorithm.ComputeHash(buffer);
                return hash;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int HashByteSize() => 32;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract HashAlgorithm GetHashAlgorithm();
    }
}
