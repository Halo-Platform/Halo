using System.IO;

namespace Halo.Consensus
{
    public class ChangeView : ConsensusMessage
    {

        public byte NewViewNumber => (byte)(ViewNumber + 1);
        public uint Timestamp;

        public override int Size => base.Size
            + sizeof(uint); //Timestamp

        public ChangeView() : base(ConsensusMessageType.ChangeView) { }

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
