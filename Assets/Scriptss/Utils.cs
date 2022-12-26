using Assets.Scripts.Player.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public static class Utils <T>
    {
        public static GameObject GetGameObjectByTag(string tag)
        {
            return GameObject.FindGameObjectWithTag(tag);
        }

        public static T GetComponentByTag(string tag)
        {
            return GameObject.FindGameObjectWithTag(tag).GetComponent<T>();
        }
    }
}
