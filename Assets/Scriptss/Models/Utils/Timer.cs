using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Player.Models
{
    [Serializable]
    public class Timer
    {
        public float currentTime = 0f;
        public float maxTime = 0f;

        public bool CheckTime() => currentTime >= maxTime;
    }
}
