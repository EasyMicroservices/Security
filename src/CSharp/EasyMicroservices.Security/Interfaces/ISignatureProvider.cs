namespace EasyMicroservices.Security.Interfaces
{
    /// <summary>
    /// This technique is used to ensure that data has come from someone you
    ///trust by validating a signature that has been applied to some data against someone's
    ///public key.
    /// </summary>
    public interface ISignatureProvider
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
        /// <param name="data"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        bool ValidateSignature(string data, string signature);
    }
}
