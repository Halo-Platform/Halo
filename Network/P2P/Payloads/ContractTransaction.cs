using System;
using System.IO;

namespace Halo.Network.P2P.Payloads
{
    public class ContractTransaction : Transaction
    {
        public ContractTransaction()
            : base(TransactionType.ContractTransaction)
        {
        }

        protected override void DeserializeExclusiveData(BinaryReader reader)
        {
            if (Version != 0) throw new FormatException();
        }
    }
}
