using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Player.Models
{
    [Serializable]
    public class RigidBodySettings
    {
        public float AirDrag = 3.5f;
        public float GroundDrag = 5f;

        public float AirGravityScale = 2f;
        public float GroundGravityScale = 1f;
    }
}
