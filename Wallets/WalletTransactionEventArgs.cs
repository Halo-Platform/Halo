using Halo.Network.P2P.Payloads;
using System;

namespace Halo.Wallets
{
    public class WalletTransactionEventArgs : EventArgs
    {
        public Transaction Transaction;
        public UInt160[] RelatedAccounts;
        public uint? Height;
        public uint Time;
    }
}
