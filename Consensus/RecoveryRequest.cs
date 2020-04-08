using System.IO;

namespace Halo.Consensus
{
    public class RecoveryRequest : ConsensusMessage
    {
        public uint Timestamp;

        public override int Size => base.Size
            + sizeof(uint); //Timestamp
        
        public RecoveryRequest() : base(ConsensusMessageType.RecoveryRequest) { }

        public override void Deserialize(BinaryReader reader)
        {
            base.Deserialize(reader);
            Timestamp = reader.ReadUInt32();
        }

        public override void Serialize(BinaryWriter writer)
        {
            base.Serialize(writer);
            writer.Write(Timestamp);
        }
    }
}
