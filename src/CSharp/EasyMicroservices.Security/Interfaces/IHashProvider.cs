namespace EasyMicroservices.Security.Interfaces
{
    /// <summary>
    /// This is a one-way process to generate a hash value to securely store passwords,
    /// or can be used to detect malicious changes or corruption of your data
    /// </summary>
    public interface IHashProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        byte[] ComputeHash(byte[] buffer);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int HashByteSize();
    }
}
