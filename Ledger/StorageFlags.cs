using System;

namespace Halo.Ledger
{
    [Flags]
    public enum StorageFlags : byte
    {
        None = 0,
        Constant = 0x01
    }
}
