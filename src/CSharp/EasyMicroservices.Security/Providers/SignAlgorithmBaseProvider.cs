using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyMicroservices.Security.Interfaces;

namespace EasyMicroservices.Security.Providers
{
    public abstract class SignAlgorithmBaseProvider : ISignatureAlgorithm
    {
        public virtual ReadOnlySpan<byte> SignData(ReadOnlySpan<byte> data)
        {
            throw new NotImplementedException();
        }

        public virtual bool ValidateSignature(string data, string signature)
        {
            throw new NotImplementedException();
        }
    }
}
