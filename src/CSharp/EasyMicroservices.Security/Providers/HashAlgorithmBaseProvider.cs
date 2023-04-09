using EasyMicroservices.Security.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.Security.Providers
{
    public abstract class HashAlgorithmBaseProvider : IHashAlgorithm
    {
        public virtual Span<byte> ComputeHash(Span<byte> buffer)
        {
            throw new NotImplementedException();
        }
    }
}
