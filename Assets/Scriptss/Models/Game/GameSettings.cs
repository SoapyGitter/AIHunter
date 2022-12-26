using Assets.Scripts.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Video;

namespace Assets.Scripts.Models.Game
{
    [Serializable]
    public class GameSettings 
    {
        public UISettings UISettings;
        public bool FoundLight = false;
        public bool Paused = false;
        public VideoPlayer VideoPlayer;
        [HideInInspector] public TimeController TimeController;
        [HideInInspector] public Movement Movement;
    }
}
