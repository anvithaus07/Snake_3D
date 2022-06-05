using System;
using System.Collections.Generic;
using UnityEngine;

namespace Snake3D
{
    public class PlayerDataHandler
    {
        private static PlayerDataHandler _instance;

        private int _CurrentScore;
        private string kHighScoreKey;


        public Action OnScoreUpdated;
        public static PlayerDataHandler Instance()
        {
            if (_instance == null)
                _instance = new PlayerDataHandler();

            return _instance;
        }

        public int CurrentScore
        {
            get
            {
                return _CurrentScore;
            }

            set
            {
                _CurrentScore = value;

                if (_CurrentScore > HighScore)
                    HighScore = _CurrentScore;

                OnScoreUpdated?.Invoke();
            }
        }

        public int HighScore
        {
            get
            {
                return PlayerPrefs.GetInt(kHighScoreKey);
            }
            private set
            {
                PlayerPrefs.SetInt(kHighScoreKey, value);
            }
        }
    }
}