using EasyMicroservices.Security.Interfaces;
using EasyMicroservices.Security.IO;
using EasyMicroservices.Utilities.IO;
using EasyMicroservices.Utilities.IO.Interfaces;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace EasyMicroservices.Security.Providers.HashProviders
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseHashProvider : BaseSecurityProvider, IHashProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="streamMiddleware"></param>
        public BaseHashProvider(IStreamMiddleware streamMiddleware = default)
        {
            InnerStreamMiddleware = streamMiddleware;
        }
        /// <summary>
        /// 
        /// </summary>
        public IStreamMiddleware InnerStreamMiddleware { get; set; }

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="streamWriter"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public Task ComputeHashToStream(Stream streamWriter, byte[] buffer)
        {
            WriteToStream(streamWriter, buffer, buffer.Length);
            return TaskHelper.GetCompletedTask();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public Task<Stream> GetReaderStream(Stream stream)
        {
            return new SecurityStream(stream, this).GetMiddlewareReaderStream(InnerStreamMiddleware);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public Task<Stream> GetWriterStream(Stream stream)
        {
            return new SecurityStream(stream, this).GetMiddlewareWriterStream(InnerStreamMiddleware);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="streamWriter"></param>
        /// <param name="data"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public override void WriteToStream(Stream streamWriter, byte[] data, int count)
        {
            var encrypt = ComputeHash(data);
            streamWriter.Write(encrypt, 0, count);
        }
    }
}
