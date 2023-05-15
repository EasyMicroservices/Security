using EasyMicroservices.Utilities.IO.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace EasyMicroservices.Security.Interfaces
{
    /// <summary>
    /// These are a two-way process to convert your data from
    ///clear byte into crypto-byte and back again.
    /// </summary>
    public interface IEncryptionProvider : IStreamMiddleware
    {
        /// <summary>
        /// Protection algorithms often use a key.
        /// Keys can be symmetric (also known as shared or secret because the same key is used to encrypt
        /// and decrypt) or asymmetric(a public-private key pair where the public key is used to encrypt
        /// and only the private key can be used to decrypt)
        /// </summary>
        /// <Tip>
        /// Symmetric key encryption algorithms are fast and can encrypt
        /// large amounts of data using a stream.Asymmetric key encryption algorithms
        /// are slow and can only encrypt small byte arrays
        /// </Tip>
        /// <returns> True means algorithm is Symmetric</returns>
        /// <returns> False means algorithm is Asymmetric</returns>
        bool IsSymmetricAlgorithm();
        /// <summary>
        /// Encrypt method.
        /// </summary>
        /// <param name="data">input data that wants to Encrypt</param>
        /// <returns>crypto-byte</returns>
        byte[] Encrypt(byte[] data);
        /// <summary>
        /// Decrypt method.
        /// </summary>
        /// <param name="encryptedData">encryptedData that wants to Decrypt</param>
        /// <returns>original byte data</returns>
        byte[] Decrypt(byte[] encryptedData);
        /// <summary>
        /// Encrypt to a stream method.
        /// </summary>
        /// <param name="streamWriter">stream to write</param>
        /// <param name="data">input data that wants to Encrypt</param>
        /// <returns>crypto-byte</returns>
        Task EncryptToStream(Stream streamWriter, byte[] data);
        /// <summary>
        /// decrypt data from stream
        /// </summary>
        /// <param name="streamWriter">stream to decrypt</param>
        /// <returns>decrypted data</returns>
        Task<byte[]> DecryptFromStream(Stream streamWriter);
    }

}
