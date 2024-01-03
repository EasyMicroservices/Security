using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.Security.Providers
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseSecurityProvider : ISecurityProvider
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public abstract byte[] Compute(byte[] buffer);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string ComputeHexString(byte[] buffer)
        {
           return  string.Concat(Compute(buffer)
               .Select(item => item.ToString("x2")));
        }  

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string ComputeHexString(string input)
        {
            return ComputeHexString(Encoding.UTF8.GetBytes(input));
        }
    }
}
