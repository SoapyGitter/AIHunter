using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player.Models
{
    [Serializable]
    public class TakerSettings
    {
        public float Radius;
        public LayerMask LayerMask;

        public bool HasItem = false;
        public float Multiplyer = 10f;
        public float Power = 1f;
        public float MaxPower = 5f;

        public CameraShake CameraShake;

        public bool CanTakeItem = false;
        public Timer Timer = new Timer();
    }
}
