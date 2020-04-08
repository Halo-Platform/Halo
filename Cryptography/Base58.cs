using System;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Halo.Cryptography
{
    public static class Base58
    {
        public const string Alphabet = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";

        public static byte[] Decode(string input)
        {
            var bi = BigInteger.Zero;
            for (int i = 0; i < input.Length; i++)
            {
                int digit = Alphabet.IndexOf(input[i]);
                if (digit < 0)
                    throw new FormatException($"Invalid Base58 character '{input[i]}' at position {i}");
                bi = bi * Alphabet.Length + digit;
            }

            int leadingZeroCount = input.TakeWhile(c => c == Alphabet[0]).Count();
            var leadingZeros = new byte[leadingZeroCount];
            var bytesWithoutLeadingZeros = bi.ToByteArray()
                .Reverse()// to big endian
                .SkipWhile(b => b == 0);//strip sign byte
            return leadingZeros.Concat(bytesWithoutLeadingZeros).ToArray();
        }

        public static string Encode(byte[] input)
        {
            BigInteger value = new BigInteger(new byte[1].Concat(input).Reverse().ToArray());

            var sb = new StringBuilder();

            while (value > 0)
            {
                value = BigInteger.DivRem(value, Alphabet.Length, out var remainder);
                sb.Insert(0, Alphabet[(int)remainder]);
            }

            for (int i = 0; i < input.Length && input[i] == 0; i++)
            {
                sb.Insert(0, Alphabet[0]);
            }
            return sb.ToString();
        }
    }
}
