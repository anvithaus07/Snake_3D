using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake3D
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameUIHandler m_gameUIHandler;
        [SerializeField] private SnakeHandler m_snakeHandler;
        [SerializeField] private FoodHandler m_foodHandler;
        public static GameManager Instance;
        private bool _hasGameStarted;
        private bool _hasGameEnded;

        private void Awake()
        {
            Instance = this;
        }
       
        private void Start()
        {
            StartGame();
        }

        public void StartGame()
        {
            GameManager.Instance.HasGameStarted = false;

            m_gameUIHandler.ShowGameStartCountDown(3);
            m_snakeHandler.InitailizeSnake();
            m_foodHandler.CalculaterPositionAndSpawnFood();
        }

        public bool HasGameStarted
        {
            get
            {
                return _hasGameStarted;
            }
            set
            {
                _hasGameStarted = value;
            }
        }
        public bool HasGameEnded
        {
            get
            {
                return _hasGameEnded;
            }
            set
            {
                _hasGameEnded = value;
            }
        }
    }
}