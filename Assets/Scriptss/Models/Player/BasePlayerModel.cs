using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Player.Models
{
    [Serializable]
    public class BasePlayerModel
    {
        public float Speed = 1f;
        public float JumpForce = 0f;
        public bool IsDead = false;
    }
}
