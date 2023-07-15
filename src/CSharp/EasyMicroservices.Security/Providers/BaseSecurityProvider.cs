using System.IO;
using System.Threading.Tasks;

namespace EasyMicroservices.Security.Providers
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseSecurityProvider
    {
        /// <summary>
        /// 
        /// </summary>
        public int BufferSize { get; set; } = 4096;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="streamWriter"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public abstract void WriteToStream(Stream streamWriter, byte[] data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="streamReader"></param>
        /// <returns></returns>
        public abstract Task<byte[]> ReadFromStream(Stream streamReader);
    }
}
