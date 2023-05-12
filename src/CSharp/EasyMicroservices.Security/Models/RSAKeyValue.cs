namespace EasyMicroservices.Security.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class RSAKeyValue
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        public RSAKeyValue(byte[] key, byte[] iv)
        {
            Key = key;
            Iv = iv;
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] Key { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public byte[] Iv { get; set; }
    }
}
