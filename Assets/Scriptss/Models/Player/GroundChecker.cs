using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player.Models
{
    [Serializable]
    public class GroundChecker
    {
        public bool IsGrounded = true;
        public Transform Point;
        public float Radius = .2f;
        public LayerMask LayerMask;
    }
}
