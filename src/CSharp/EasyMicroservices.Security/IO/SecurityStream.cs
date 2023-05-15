using EasyMicroservices.Security.Providers;
using System.IO;

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
            return _internalStream.Read(buffer, offset, count);
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
            _baseSecurityProvider.WriteToStream(_internalStream, buffer, count);
        }
    }
}
