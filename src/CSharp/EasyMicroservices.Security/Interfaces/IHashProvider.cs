using EasyMicroservices.Utilities.IO.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace EasyMicroservices.Security.Interfaces
{
    /// <summary>
    /// This is a one-way process to generate a hash value to securely store passwords,
    /// or can be used to detect malicious changes or corruption of your data
    /// </summary>
    public interface IHashProvider : IStreamMiddleware
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        byte[] ComputeHash(byte[] buffer);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int HashByteSize();
        /// <summary>
        /// Encrypt to a stream method.
        /// </summary>
        /// <param name="streamWriter">stream to write</param>
        /// <param name="buffer">input data that wants to Encrypt</param>
        /// <returns>crypto-byte</returns>
        Task ComputeHashToStream(Stream streamWriter, byte[] buffer);
    }
}
