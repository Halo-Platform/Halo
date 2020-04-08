using System;
using System.Globalization;
using System.Linq;

namespace Halo
{
    public class UInt160 : UIntBase, IComparable<UInt160>, IEquatable<UInt160>
    {
        public static readonly UInt160 Zero = new UInt160();

        public UInt160()
            : this(null)
        {
        }

        public UInt160(byte[] value)
            : base(20, value)
        {
        }

        public unsafe int CompareTo(UInt160 other)
        {
            fixed (byte* px = ToArray(), py = other.ToArray())
            {
                uint* lpx = (uint*)px;
                uint* lpy = (uint*)py;
                for (int i = (160 / 32 - 1); i >= 0; i--)
                {
                    if (lpx[i] > lpy[i])
                        return 1;
                    if (lpx[i] < lpy[i])
                        return -1;
                }
            }
            return 0;
        }

        public unsafe bool Equals(UInt160 other)
        {
            fixed (byte* px = ToArray(), py = other.ToArray())
            {
                uint* lpx = (uint*)px;
                uint* lpy = (uint*)py;
                for (int i = (160 / 32 - 1); i >= 0; i--)
                {
                    if (lpx[i] != lpy[i])
                        return false;
                }
            }
            return true;
        }

        public static new UInt160 Parse(string value)
        {
            if (value == null)
                throw new ArgumentNullException();
            if (value.StartsWith("0x"))
                value = value.Substring(2);
            if (value.Length != 40)
                throw new FormatException();
            return new UInt160(value.HexToBytes().Reverse().ToArray());
        }

        public static bool TryParse(string s, out UInt160 result)
        {
            if (s == null)
            {
                result = null;
                return false;
            }
            if (s.StartsWith("0x"))
                s = s.Substring(2);
            if (s.Length != 40)
            {
                result = null;
                return false;
            }
            byte[] data = new byte[20];
            for (int i = 0; i < 20; i++)
                if (!byte.TryParse(s.Substring(i * 2, 2), NumberStyles.AllowHexSpecifier, null, out data[i]))
                {
                    result = null;
                    return false;
                }
            result = new UInt160(data.Reverse().ToArray());
            return true;
        }

        public static bool operator >(UInt160 left, UInt160 right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(UInt160 left, UInt160 right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static bool operator <(UInt160 left, UInt160 right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(UInt160 left, UInt160 right)
        {
            return left.CompareTo(right) <= 0;
        }
    }
}
