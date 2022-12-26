using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models.Challenges
{
    [Serializable]
    public class MinigamePlayer
    {
        public float Speed;
        public bool Collides;
        [HideInInspector] public Rigidbody2D RigidBody;
        [HideInInspector] public SpriteRenderer SpriteRenderer;
        public float Range = .35f;
    }
}
