using Assets.Scripts.Models.Player;
using System;
using UnityEngine;

namespace Assets.Scripts.Player.Models
{
    [Serializable]
    public class PlayerSettings : BasePlayerModel
    {
        public GroundChecker GroundChecker = new();
        public RigidBodySettings RigidBodySettings = new();
        public GameObject GFX;
        public ParticlesSettings ParticlesSettings= new ParticlesSettings();

        public int MovingDirection = 0;
    }
}
