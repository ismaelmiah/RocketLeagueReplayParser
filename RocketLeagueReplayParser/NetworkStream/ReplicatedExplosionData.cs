using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLeagueReplayParser.NetworkStream
{
    public class ReplicatedExplosionData
    {
        public ActiveActor Actor { get; private set; } 
        public Vector3D Position { get; private set; }

        public static ReplicatedExplosionData Deserialize(BitReader br, UInt32 netVersion)
        {
            var red = new ReplicatedExplosionData();

            red.DeserializeImpl(br, netVersion);

            return red;
        }

        protected virtual void DeserializeImpl(BitReader br, UInt32 netVersion)
        {
            Actor = ActiveActor.Deserialize(br);
            Position = Vector3D.Deserialize(br, netVersion);
        }

        public virtual void Serialize(BitWriter bw, UInt32 netVersion)
        {
            Actor.Serialize(bw);
            Position.Serialize(bw, netVersion);
        }
    }
}
