using System.IO;

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
        /// <param name="streamWriter"></param>
        /// <param name="data"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public abstract void WriteToStream(Stream streamWriter, byte[] data, int count);
    }
}
