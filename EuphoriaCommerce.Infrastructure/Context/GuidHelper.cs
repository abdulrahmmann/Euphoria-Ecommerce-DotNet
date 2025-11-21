using System.Security.Cryptography;
using System.Text;

namespace EuphoriaCommerce.Infrastructure.Context;

public static class GuidHelper
{
    public static Guid CreateGuidFromName(string name)
    {
        using (var sha1 = SHA1.Create())
        {
            var nameBytes = Encoding.UTF8.GetBytes(name);
            var hash = sha1.ComputeHash(nameBytes);

            var guidBytes = new byte[16];
            Array.Copy(hash, guidBytes, 16);

            // Make it UUID v5 compliant
            guidBytes[6] = (byte)((guidBytes[6] & 0x0F) | (5 << 4));
            guidBytes[8] = (byte)((guidBytes[8] & 0x3F) | 0x80);

            return new Guid(guidBytes);
        }
    }
}