using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using QRCoder;
using System.Drawing;

namespace admin
{
    class TotpHelper
    {
        // Generate the TOTP URI (for QR code generation)
        public static string GenerateTotpUri(string email, string secret)
        {
            return $"otpauth://totp/{email}?secret={secret}&issuer=MyApp";
        }

        // Generate the QR code image from the TOTP URI
        public static Bitmap GenerateQrCode(string totpUri)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(totpUri, QRCodeGenerator.ECCLevel.Q);
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    Bitmap qrCodeImage = qrCode.GetGraphic(20); // 20 is the pixel size of the QR code
                    return qrCodeImage;
                }
            }
        }

        // Generate a random secret key for TOTP (Base32)
        public static string GenerateSecretKey()
        {
            byte[] key = new byte[10]; // 10-byte secret key
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(key);
            }
            return Base32Encode(key); // Convert to Base32
        }

        // Base32 encode function
        public static string Base32Encode(byte[] data)
        {
            const string base32Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
            StringBuilder result = new StringBuilder((int)(data.Length * 8 / 5));

            int buffer = data[0];
            int bitsLeft = 8;
            foreach (byte b in data.Skip(1))
            {
                bitsLeft += 8;
                buffer <<= 8;
                buffer |= b;

                while (bitsLeft >= 5)
                {
                    bitsLeft -= 5;
                    result.Append(base32Chars[(buffer >> bitsLeft) & 0x1F]);
                    buffer &= (1 << bitsLeft) - 1;
                }
            }

            if (bitsLeft > 0)
            {
                result.Append(base32Chars[(buffer << (5 - bitsLeft)) & 0x1F]);
            }
            return result.ToString();
        }

        // Base32 decode function
        public static byte[] Base32Decode(string base32)
        {
            const string base32Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
            int length = base32.Length;
            byte[] bytes = new byte[length * 5 / 8];
            int byteIndex = 0;
            int buffer = 0;
            int bitsLeft = 0;

            foreach (char c in base32)
            {
                int index = base32Chars.IndexOf(c);
                if (index == -1) break;

                buffer <<= 5;
                buffer |= index;
                bitsLeft += 5;

                if (bitsLeft >= 8)
                {
                    bitsLeft -= 8;
                    bytes[byteIndex++] = (byte)(buffer >> bitsLeft);
                    buffer &= (1 << bitsLeft) - 1;
                }
            }

            return bytes;
        }


        // Generate TOTP code (6 digits) from the secret key
        public static int GenerateTotpCode(string secret)
        {
            byte[] key = Base32Decode(secret); // Decode Base32 secret

            // Get Unix timestamp (seconds since 1970-01-01 00:00:00 UTC)
            DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long counter = (long)(DateTime.UtcNow - epochStart).TotalSeconds / 30; // 30-second TOTP interval

            byte[] counterBytes = BitConverter.GetBytes(counter);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(counterBytes); // Ensure correct byte order
            }

            using (HMACSHA1 hmac = new HMACSHA1(key))
            {
                byte[] hash = hmac.ComputeHash(counterBytes);

                // Dynamic Truncation (RFC 6238)
                int offset = hash[hash.Length - 1] & 0x0F;
                int otp = (hash[offset] & 0x7F) << 24 |
                          (hash[offset + 1] & 0xFF) << 16 |
                          (hash[offset + 2] & 0xFF) << 8 |
                          (hash[offset + 3] & 0xFF);

                otp %= 1000000; // 6-digit code
                return otp;
            }
        }


    }
}
