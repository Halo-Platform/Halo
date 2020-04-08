using Halo.Network.P2P;
using Halo.Network.P2P.Payloads;

namespace Halo.Plugins
{
    public interface IP2PPlugin
    {
        bool OnP2PMessage(Message message);
        bool OnConsensusMessage(ConsensusPayload payload);
    }
}
