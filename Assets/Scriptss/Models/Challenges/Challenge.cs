using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player.Models.Challenges
{
    [Serializable]
    public class Challenge
    {
        public ChallengeTypeEnum Type = ChallengeTypeEnum.None;
        [HideInInspector] public CircleCollider2D Collider;
        public GameObject Minigame;
    }
}
