using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake3D
{
    public class GameManager
    {
        private static GameManager _Instance;

        public static GameManager Instance()
        {
            if (_Instance == null)
                _Instance = new GameManager();

            return _Instance;
        }

        public PlayMode PlayMode { get; set; }
        
    }
}