using Assets.Scripts.Player.Models;
using Assets.Scriptss.Models.Particles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public static class Utils
    {
       
        public static ParticlesController GetParticlesController()
        {
            return GameObject.FindGameObjectWithTag(TagEnum.ParticleController).GetComponent<ParticlesController>();
        }
    }
}
