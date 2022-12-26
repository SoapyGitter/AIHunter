using Assets.Scriptss.Models.Particles.ParticlesEnums;
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
        public ParticleSystem Particle;
        public Transform ParticlePosition;
    }

    [Serializable]
    public class ParticlesFiller
    {
        public ParticlesEnum Name;
        public ParticleSystem Particle;
        public Transform ParticlePosition;
    }
}
