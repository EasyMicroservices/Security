namespace EasyMicroservices.Security.Interfaces
{
    /// <summary>
    /// This technique is used to ensure that data has come from someone you
    ///trust by validating a signature that has been applied to some data against someone's
    ///public key.
    /// </summary>
    public interface ISignatureAlgorithm
    {
         ReadOnlySpan<byte> SignData(ReadOnlySpan<byte> data);
         bool ValidateSignature(string data, string signature);
    }
}
