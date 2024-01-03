using EasyMicroservices.Utilities.IO.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace EasyMicroservices.Security.Interfaces
{
    /// <summary>
    /// This technique is used to ensure that data has come from someone you
    ///trust by validating a signature that has been applied to some data against someone's
    ///public key.
    /// </summary>
    public interface ISignatureProvider : IStreamMiddleware, ISecurityProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        byte[] SignData(byte[] data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orginData"></param>
        /// <param name="signatureData"></param>
        /// <returns></returns>
        bool ValidateSignature(byte[] orginData, byte[] signatureData);
        /// <summary>
        /// SignData to a stream method.
        /// </summary>
        /// <param name="streamWriter">stream to write</param>
        /// <param name="data">input data that wants to Encrypt</param>
        /// <returns>crypto-byte</returns>
        Task SignDataToStream(Stream streamWriter, byte[] data);
    }
}
