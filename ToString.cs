using System;
using System.Text;
using System.Numerics;

namespace OEGen
{
    public static class BigInt
    {
        public static string ToBinaryString(this BigInteger bigint)
        {
            // Беремо байти числа
            var bytes = bigint.ToByteArray();
            var byteI = bytes.Length - 1;
            // Створюємо базу для строку, що будемо повертати
            var bitString = new StringBuilder(bytes.Length * 8);
            // Конвертуємо молодший байт у BIN
            var binary = Convert.ToString(bytes[byteI], 2);
            bitString.Append(binary);
            // Конвертуємо інші байти
            for (byteI--; byteI >= 0; byteI--)
            {
                bitString.Append(Convert.ToString(bytes[byteI], 2).PadLeft(8, '0'));
            }
            return bitString.ToString();
        }
        public static string ToHexadecimalString (this BigInteger bigint)
        {
            return bigint.ToString("X");
        }
        public static string ToOctalString(this BigInteger bigint)
        {
            var bytes = bigint.ToByteArray();
            var byteI = bytes.Length - 1;
            var octString = new StringBuilder(((bytes.Length / 3) + 1) * 8);
            // Рахуємо скільки байт залишається якщо брати по 24 біти
            var extra = bytes.Length % 3;
            if (extra == 0)
            {
                extra = 3;
            }
            // Конвертуємо перші 24 біта у int
            int int24 = 0;
            for (; extra != 0; extra--)
            {
                int24 <<= 8;
                int24 += bytes[byteI--];
            }
            // Записуємо у oct
            var octal = Convert.ToString(int24, 8);
            octString.Append(octal);
            for (; byteI >= 0; byteI -= 3)
            {
                int24 = (bytes[byteI] << 16) + (bytes[byteI - 1] << 8) + bytes[byteI - 2];
                octString.Append(Convert.ToString(int24, 8).PadLeft(8, '0'));
            }
            return octString.ToString();
        }
    }
}
