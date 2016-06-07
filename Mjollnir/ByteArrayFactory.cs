using System;
using System.IO;

namespace Mjollnir
{
    public static class ByteArrayFactory
    {
        public static byte[] Create(Action<Stream> action)
        {
            Throw.ArgumentNullException.IfNull(action, nameof(action));

            using (var stream = new MemoryStream())
            {
                action(stream);

                return stream.ToArray();
            }
        }
    }
}
