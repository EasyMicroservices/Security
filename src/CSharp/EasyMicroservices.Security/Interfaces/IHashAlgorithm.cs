namespace EasyMicroservices.Security.Interfaces
{
    /// <summary>
    /// This is a one-way process to generate a hash value to securely store passwords,
    /// or can be used to detect malicious changes or corruption of your data
    /// </summary>
    public interface IHashAlgorithm
    {
        Span<byte> ComputeHash(Span<byte> buffer);
    }
}
