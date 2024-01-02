namespace EasyMicroservices.Security;
/// <summary>
/// 
/// </summary>
public interface ISecurityProvider
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    string ComputeHexString(byte[] buffer);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    byte[] Compute(byte[] buffer);
}
