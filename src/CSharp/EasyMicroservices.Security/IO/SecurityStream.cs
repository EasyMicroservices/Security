using EasyMicroservices.Security.Providers;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EasyMicroservices.Security.IO
{
    /// <summary>
    /// 
    /// </summary>
    internal class SecurityStream : Stream
    {
        Stream _internalStream;
        BaseSecurityProvider _baseSecurityProvider;
        public SecurityStream(Stream stream, BaseSecurityProvider baseSecurityProvider)
        {
            _internalStream = stream;
            _baseSecurityProvider = baseSecurityProvider;
        }

        public override bool CanRead => _internalStream.CanRead;

        public override bool CanSeek => _internalStream.CanSeek;

        public override bool CanWrite => _internalStream.CanWrite;

        public override long Length => _internalStream.Length;

        public override long Position
        {
            get => _internalStream.Position;
            set => _internalStream.Position = value;
        }

        public override void Flush()
        {
            _internalStream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new System.NotImplementedException("Please use ReadAsync");
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            var result = await _baseSecurityProvider.ReadFromStream(_internalStream);
            if (buffer.Length != result.Length)
                Array.Resize(ref buffer, result.Length);
            Array.Copy(result, buffer, result.Length);
            return result.Length;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _internalStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _internalStream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            if (buffer.Length > count)
                Array.Resize(ref buffer, count);
            _baseSecurityProvider.WriteToStream(_internalStream, buffer);
        }
    }
}
