using EasyMicroservices.Security.Interfaces;
using EasyMicroservices.Security.IO;
using EasyMicroservices.Security.Models;
using EasyMicroservices.Utilities.IO;
using EasyMicroservices.Utilities.IO.Interfaces;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.Security.Providers.EncryptionProviders
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseEncryptionProvider : BaseSecurityProvider, IEncryptionProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="streamMiddleware"></param>
        public BaseEncryptionProvider(IStreamMiddleware streamMiddleware = default)
        {
            InnerStreamMiddleware = streamMiddleware;
        }
        /// <summary>
        /// salt size must be at least 8 bytes, we will use 16 bytes
        /// </summary>
        public byte[] Salt { get; set; } = Encoding.Unicode.GetBytes("EasyEasy");
        /// <summary>
        /// iterations must be at least 1000, we will use 2000
        /// </summary>
        public int Iterations { get; set; } = 2000;
        /// <summary>
        /// 
        /// </summary>
        public IStreamMiddleware InnerStreamMiddleware { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encryptedData"></param>
        /// <returns></returns>
        public abstract byte[] Decrypt(byte[] encryptedData);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public abstract byte[] Encrypt(byte[] data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public override byte[] Compute(byte[] buffer)
        {
            return Encrypt(buffer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual bool IsSymmetricAlgorithm()
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="keyByteSize"></param>
        /// <param name="IvByteSize"></param>
        /// <returns></returns>
        public RSAKeyValue GenerateKeyAndIv(byte[] key, int keyByteSize, int IvByteSize)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(key, Salt, Iterations))
            {
                return new RSAKeyValue(pbkdf2.GetBytes(keyByteSize), pbkdf2.GetBytes(IvByteSize));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="streamWriter"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task EncryptToStream(Stream streamWriter, byte[] data)
        {
            WriteToStream(streamWriter, data);
            return TaskHelper.GetCompletedTask();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="streamWriter"></param>
        /// <returns></returns>
        public Task<byte[]> DecryptFromStream(Stream streamWriter)
        {
            return ReadFromStream(streamWriter);
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
        /// <returns></returns>
        public override void WriteToStream(Stream streamWriter, byte[] data)
        {
            var encrypt = Encrypt(data);
            streamWriter.Write(encrypt, 0, encrypt.Length);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="streamWriter"></param>
        /// <returns></returns>
        public override async Task<byte[]> ReadFromStream(Stream streamWriter)
        {
            var allBytes = await streamWriter.StreamToBytesAsync(BufferSize);
            var decrypt = Decrypt(allBytes);
            return decrypt;
        }
    }
}
