using EasyMicroservices.Security.Interfaces;
using EasyMicroservices.Security.IO;
using EasyMicroservices.Utilities.IO;
using EasyMicroservices.Utilities.IO.Interfaces;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace EasyMicroservices.Security.Providers.SignatureProviders
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseSignatureProvider : BaseSecurityProvider, ISignatureProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="streamMiddleware"></param>
        public BaseSignatureProvider(IStreamMiddleware streamMiddleware = default)
        {
            InnerStreamMiddleware = streamMiddleware;
            _provider = new RSACryptoServiceProvider();
        }
        /// <summary>
        /// 
        /// </summary>
        protected readonly RSACryptoServiceProvider _provider;
        /// <summary>
        /// 
        /// </summary>
        public IStreamMiddleware InnerStreamMiddleware { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual byte[] SignData(byte[] data)
        {
#if (NET45)
            throw new NotImplementedException();
#else
            return _provider.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orginData"></param>
        /// <param name="signatureData"></param>
        /// <returns></returns>
        public virtual bool ValidateSignature(byte[] orginData, byte[] signatureData)
        {
#if (NET45)
            throw new NotImplementedException();
#else
            return _provider.VerifyData(orginData, signatureData, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="streamWriter"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task SignDataToStream(Stream streamWriter, byte[] data)
        {
            WriteToStream(streamWriter, data);
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
        /// <returns></returns>
        public override void WriteToStream(Stream streamWriter, byte[] data)
        {
            var encrypt = SignData(data);
            streamWriter.Write(encrypt, 0, encrypt.Length);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="streamReader"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Task<byte[]> ReadFromStream(Stream streamReader)
        {
            throw new NotImplementedException();
        }
    }
}
