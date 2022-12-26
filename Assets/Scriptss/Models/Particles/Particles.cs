using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models.Particles
{
    [Serializable]
    public class Particles
    {
        public string Id = "";
        public ParticleSystem Particle;
        public Transform ParticlePosition;
    }
}
